using Flyoobe3.Features.Upgrade;
using Flyoobe3.Features.SetupActions;
using Flyoobe3.Models;
using Flyoobe3.Services;
using System.Runtime.InteropServices;

namespace Flyoobe3.Views;

//shows the whole Windows setup as one short checklist
internal partial class OverviewView : UserControl, ISearchableView
{
    private readonly SetupCatalog _catalog;
    private readonly RegistryService _registry;
    private readonly PackageService _packages;
    private readonly RecipeRunner _recipeRunner;
    private bool _scanned;
    private bool _loaded;
    private bool _recipeLoaded;
    private RecipeSelectionSnapshot? _beforeRecipe;
    private string _searchText = "";

    public event Action<string>? OpenRequested;

    // --- Setup and lifecycle -------------------------------------------------

    //the designer needs empty data, MainForm supplies the live catalog
    public OverviewView() : this(new SetupCatalog(), new RegistryService(),
        new RecipeRunner(new RegistryService(), new PackageService()), new PackageService()) { }

    public OverviewView(SetupCatalog catalog, RegistryService registry,
        RecipeRunner recipeRunner, PackageService packages)
    {
        _catalog = catalog;
        _registry = registry;
        _packages = packages;
        _recipeRunner = recipeRunner;
        InitializeComponent();
        UpdateDpiMetrics();
        ApplyLocalization();
        BuildRecipeMenu();
    }

    protected override void OnDpiChangedAfterParent(EventArgs e)
    {
        base.OnDpiChangedAfterParent(e);
        UpdateDpiMetrics();
    }

    private void UpdateDpiMetrics()
    {
        if (setupTree == null) return;
        int Scale(int value) => Math.Max(1, (value * DeviceDpi + 48) / 96);
        int textHeight = TextRenderer.MeasureText("Ag", setupTree.Font).Height;

        setupTree.ItemHeight = Math.Max(Scale(22), textHeight + Scale(4));
        setupTree.Indent = Math.Max(Scale(22), textHeight);
    }

    private void ApplyLocalization()
    {
        introTitleLabel.Text = Loc.Get("Overview_Heading");
        introLabel.Text = Loc.Get("Overview_Intro");
        scanButton.Text = Loc.Get("Overview_CheckPc");
        recipeButton.Text = Loc.Get("Recipe_Button");
        applyRecipeButton.Text = Loc.Get("Recipe_Apply");
        discardRecipeButton.Text = Loc.Get("Recipe_Discard");
        detailsLabel.Text = Loc.Get("Overview_SelectArea");
        tipHeading.Text = Loc.Get("Overview_TipHeading");
        detailLink.Text = TipFor(SelectedAreaKey).Text;
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
        if (_loaded) return;
        _loaded = true;
        RefreshRows();
        await ScanAsync();
    }

    // --- Search -------------------------------------------------------------

    //The main window owns the search box; this page only filters its tree rows.
    public void ApplySearch(string text)
    {
        var searchText = text.Trim();
        if (_searchText.Equals(searchText, StringComparison.OrdinalIgnoreCase)) return;
        _searchText = searchText;
        RefreshRows();
    }

    private void FilterAreaNodes(TreeNode group)
    {
        for (var index = group.Nodes.Count - 1; index >= 0; index--)
            if (group.Nodes[index].Text.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) < 0)
                group.Nodes.RemoveAt(index);
    }

    // --- Scan and overview tree ---------------------------------------------

    public void RefreshRows()
    {
        var selectedKey = SelectedAreaKey;
        var foundBloatware = _catalog.Bloatware.Count(item => item.IsInstalled);
        var attentionExpanded = setupTree.Nodes["group:attention"]?.IsExpanded ?? true;
        var choicesExpanded = setupTree.Nodes["group:choices"]?.IsExpanded ?? true;
        var matchingExpanded = setupTree.Nodes["group:matching"]?.IsExpanded ?? false;

        setupTree.BeginUpdate();
        setupTree.Nodes.Clear();
        var attention = setupTree.Nodes.Add("group:attention", "");
        var choices = setupTree.Nodes.Add("group:choices", Loc.Get("Overview_GroupChoices"));
        var matching = setupTree.Nodes.Add("group:matching", "");
        attention.ForeColor = SystemColors.HotTrack;
        choices.ForeColor = SystemColors.HotTrack;
        matching.ForeColor = SystemColors.HotTrack;

        //the mark is made from measured values, so it only exists after a scan, but it leads the group
        if (_scanned)
            AddArea(choices, Loc.Get("Rating_Title"),
                Loc.Format("Rating_BaseScoreValue", SetupRating.BaseScore(_catalog)), "rating");
        AddArea(choices, Loc.Get("Overview_Device"), Loc.Get("Overview_DeviceSettings"), "device");
        AddArea(choices, Loc.Get("Overview_Network"), Loc.Get("Overview_NetworkSettings"), "network");
        AddArea(choices, Loc.Get("Account_Title"), Loc.Get("Account_Choice"), "account");
        AddArea(choices, Loc.Get("Browser_Title"),
            Loc.Format("Overview_BrowsersAvailable", _catalog.Apps.Count(item => item.Category.Equals("Browsers", StringComparison.OrdinalIgnoreCase))),
            "browser");
        AddArea(choices, Loc.Get("Personalization_Title"), Loc.Get("Personalization_Summary"), "personalization");

        if (_scanned)
        {
            foreach (var group in _catalog.Rules.GroupBy(rule => rule.Category).OrderBy(group => group.Key))
            {
                var rules = group.ToList();
                var ready = rules.Count(rule => rule.IsApplied);
                var target = ready == rules.Count ? matching : attention;
                AddArea(target, Loc.RuleCategory(group.Key), Loc.Format("Rules_Match", ready, rules.Count),
                    "rules:" + group.Key, ready == rules.Count ? RowTone.Match : RowTone.Difference);
            }
        }

        AddArea(choices, Loc.Get("Apps_Title"), Loc.Format("Apps_Selected", _catalog.Apps.Count(item => item.Selected)), "apps");
        //installed matches need a look, but nothing is removed here
        AddArea(_scanned && foundBloatware > 0 ? attention : choices,
            Loc.Get("Bloatware_Title"), Loc.Format("Overview_RemovalChoices", foundBloatware), "bloatware",
            _scanned && foundBloatware > 0 ? RowTone.Difference : RowTone.Normal);
        if (AppSettings.Instance.SetupActionsEnabled)
            AddArea(choices, Loc.Get("Actions_Title"), Loc.Format("Actions_Available", _catalog.Actions.Count), "actions");
        AddArea(choices, Loc.Get("Overview_WindowsUpdate"), Loc.Get("Overview_WindowsHandlesUpdates"), "update");

        //Flyby11 stays isolated and only appears where an upgrade makes sense
        if (UpgradeAvailability.ShouldOffer)
            AddArea(choices, "Windows upgrade", "Windows 10 → Windows 11", "upgrade");

        if (_searchText.Length > 0)
        {
            FilterAreaNodes(attention);
            FilterAreaNodes(choices);
            FilterAreaNodes(matching);
        }

        attention.Text = Loc.Format("Overview_GroupAttention", attention.Nodes.Count);
        matching.Text = Loc.Format("Overview_GroupMatching", matching.Nodes.Count);
        if (_searchText.Length > 0)
        {
            if (attention.Nodes.Count == 0) setupTree.Nodes.Remove(attention);
            if (choices.Nodes.Count == 0) setupTree.Nodes.Remove(choices);
            if (matching.Nodes.Count == 0) setupTree.Nodes.Remove(matching);
        }
        if (attentionExpanded) attention.Expand();
        if (choicesExpanded) choices.Expand();
        if (matchingExpanded) matching.Expand();
        setupTree.EndUpdate();

        if (selectedKey != null)
        {
            var node = setupTree.Nodes.Find(selectedKey, true).FirstOrDefault();
            if (node != null) setupTree.SelectedNode = node;
        }
        else if (_scanned)
        {
            if (attention.Nodes.Count > 0) setupTree.SelectedNode = attention.Nodes[0];
        }
        UpdateSelectedArea();
        UpdateSummary();
        UpdateRecipeBanner();
    }

    private async Task ScanAsync()
    {
        SetBusy(true, Loc.Get("Overview_CheckingRules"));
        await _registry.ScanAsync(_catalog.Rules);
        var appScanError = await _packages.ScanBloatwareAsync(_catalog.Bloatware);
        _scanned = true;
        SetBusy(false, Loc.Get("Overview_CheckComplete"));
        RefreshRows();
        if (appScanError != null)
            summaryLabel.Text = Loc.Format("Overview_AppScanFailed", appScanError);
    }

    private async void ScanButton_Click(object? sender, EventArgs e)
    {
        if (_recipeLoaded && MessageBox.Show(this, Loc.Get("Recipe_DiscardForScan"), Loc.Get("Recipe_Title"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        if (_recipeLoaded) LeaveRecipeMode(true);
        await ScanAsync();
    }

    private static void AddArea(TreeNode group, string name, string result, string key,
        RowTone tone = RowTone.Normal)
    {
        var node = group.Nodes.Add(key, Loc.Format("Overview_AreaLine", name, result));
        //color follows measured state, never translated display text
        if (tone == RowTone.Difference) node.ForeColor = Color.Firebrick;
        else if (tone == RowTone.Match) node.ForeColor = SystemColors.GrayText;
    }

    private void UpdateSummary()
    {
        if (!_scanned)
        {
            summaryLabel.Text = Loc.Get("Overview_ReadyToCheck");
            return;
        }

        summaryLabel.Text = Loc.Format("Overview_CheckSummary",
            _catalog.Rules.Count(rule => rule.IsApplied), _catalog.Rules.Count);

        //preinstalled apps have no recommended value, so they are named next to the rules, never added to them
        //same text as the bloatware row below, so both places can never disagree
        var found = _catalog.Bloatware.Count(item => item.IsInstalled);
        if (found > 0) summaryLabel.Text += " · " + Loc.Format("Overview_RemovalChoices", found);
    }

    // --- Selection and navigation -------------------------------------------

    private void SetupTree_AfterSelect(object? sender, TreeViewEventArgs e)
        => UpdateSelectedArea();

    private void UpdateSelectedArea()
    {
        var node = setupTree.SelectedNode;
        var key = SelectedAreaKey;
        configureButton.Enabled = key != null;
        detailLink.Text = TipFor(key).Text;
        //the reading pane stays open without a selection, it then explains what to do
        if (node == null || key == null)
        {
            detailsLabel.Text = Loc.Get("Overview_SelectArea");
            configureButton.Text = Loc.Get("Overview_OpenSelected");
            return;
        }

        //the selected row is right above, so repeating its text here would only cost space
        detailsLabel.Text = DetailFor(key);
        configureButton.Text = ButtonTextFor(node, key);
    }

    private static string ButtonTextFor(TreeNode node, string key)
    {
        if (key == "browser") return Loc.Get("Overview_ChooseBrowser");
        if (key == "apps") return Loc.Get("Overview_ChooseApps");
        if (key == "bloatware") return Loc.Get("Overview_ReviewApps");
        var area = key.StartsWith("rules:", StringComparison.OrdinalIgnoreCase)
            ? Loc.RuleCategory(key.Substring("rules:".Length)) : AreaName(key);
        return Loc.Format(node.Parent?.Name == "group:attention"
            ? "Overview_ReviewArea" : "Overview_OpenArea", area);
    }

    private static string AreaName(string key)
    {
        if (key == "device") return Loc.Get("Overview_Device");
        if (key == "network") return Loc.Get("Overview_Network");
        if (key == "account") return Loc.Get("Account_Title");
        if (key == "personalization") return Loc.Get("Personalization_Title");
        if (key == "actions") return Loc.Get("Actions_Title");
        if (key == "update") return Loc.Get("Overview_WindowsUpdate");
        if (key == "upgrade") return "Windows upgrade";
        if (key == "rating") return Loc.Get("Rating_Title");
        return Loc.Get("Overview_OpenSelected");
    }

    private string DetailFor(string? key)
    {
        if (key == "apps") return Loc.Get("Overview_DetailApps");
        if (key == "bloatware") return Loc.Get("Overview_DetailBloatware");
        if (key == "actions") return Loc.Get("Actions_OverviewDetail");
        if (key == "browser") return Loc.Get("Overview_DetailBrowser");
        if (key == "personalization") return Loc.Get("Overview_DetailPersonalization");
        if (key == "account") return Loc.Get("Overview_DetailAccount");
        if (key == "device") return Loc.Get("Overview_DetailDevice");
        if (key == "network") return Loc.Get("Overview_DetailNetwork");
        if (key == "update") return Loc.Get("Overview_DetailUpdate");
        //the rating page carries the same sentence at its top, so it is not written twice
        if (key == "rating") return Loc.Get("Rating_Disclaimer");
        if (key == "upgrade") return "Check this Windows 10 PC, then choose standard Setup or the isolated Flyby11 compatibility path.";
        if (_scanned && key != null && key.StartsWith("rules:", StringComparison.OrdinalIgnoreCase))
            return RuleDifferences(key.Substring("rules:".Length));
        return Loc.Get("Overview_DetailRules");
    }

    //the generic database sentence says nothing about this pc, so lets us just name the rules that differ
    private string RuleDifferences(string category)
    {
        //Loc.RuleName reads the translated name from the rule database, same as the rules page
        var names = _catalog.Rules
            .Where(rule => rule.Category == category && !rule.IsApplied)
            .Select(rule => Loc.RuleName(rule.Name)).ToList();
        if (names.Count == 0) return Loc.Get("Overview_DetailRules");

        //a long list would push the tip link out of view, so only the first few are named
        var text = string.Join(Environment.NewLine, names.Take(3).Select(name => "• " + name));
        if (names.Count > 3)
            text += Environment.NewLine + Loc.Format("Overview_MoreDifferences", names.Count - 3);
        return Loc.Get("Overview_DifferencesHeader") + Environment.NewLine + Environment.NewLine + text;
    }

    //the link is a hint, not navigation: it points at a feature the selected area does not show
    //by itself. the button next to it is the one that opens the area.
    private static (string Text, string Target) TipFor(string? key)
    {
        //while setup actions are off the whole plugin side of flyoobe stays invisible, so it comes first
        if (!AppSettings.Instance.SetupActionsEnabled)
            return (Loc.Get("Overview_TipEnableActions"), "settings");

        //in the rule areas every single entry can be explained in plain words by the ai
        if (key == null || key.StartsWith("rules:", StringComparison.OrdinalIgnoreCase))
            return (Loc.Get("Overview_TipExplain"), "settings");

        return (Loc.Get("Overview_TipActions"), "actions");
    }

    private void DetailLink_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        => OpenRequested?.Invoke(TipFor(SelectedAreaKey).Target);

    private void ConfigureButton_Click(object? sender, EventArgs e) => OpenSelected();

    private void SetupTree_NodeMouseDoubleClick(object? sender, TreeNodeMouseClickEventArgs e) => OpenSelected();

    private void OpenSelected()
    {
        if (SelectedAreaKey != null) OpenRequested?.Invoke(SelectedAreaKey);
    }

    private string? SelectedAreaKey
    {
        get
        {
            var key = setupTree.SelectedNode?.Name ?? "";
            if (key.Length == 0) return null;
            return key.StartsWith("group:", StringComparison.OrdinalIgnoreCase) ? null : key;
        }
    }

    // --- Recipes -------------------------------------------------------------

    private async void ApplyRecipeButton_Click(object? sender, EventArgs e)
    {
        var rules = _catalog.Rules.Where(item => item.Selected).ToList();
        var defaults = _catalog.Rules.Where(item => !item.Selected && item.RestoreWithRecipe).ToList();
        var apps = _catalog.Apps.Where(item => item.Selected).ToList();
        var removalChoices = _catalog.Bloatware.Where(item => item.Selected).ToList();
        var foundRemovals = removalChoices.Count(item => item.IsInstalled);
        var preferences = _catalog.RecipePreferences?.PreferenceCount ?? 0;
        var confirmations = _catalog.RecipePreferences?.ConfirmationCount ?? 0;
        var actions = _catalog.Actions.Where(item => item.Selected && item.RecipeAllowed).ToList();
        if (rules.Count + defaults.Count + preferences + apps.Count + removalChoices.Count + confirmations + actions.Count == 0) return;

        if ((rules.Concat(defaults).Any(item => item.RequiresAdmin) || actions.Any(item => item.RequiresAdmin)) &&
            !WindowsActions.IsAdministrator())
        {
            MessageBox.Show(this, Loc.Get("Recipe_Admin"), Loc.Get("Common_AdminTitle"),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var question = Loc.Format("Recipe_ApplyQuestion", rules.Count, defaults.Count, preferences,
            apps.Count, removalChoices.Count, foundRemovals, actions.Count, confirmations);
        if (MessageBox.Show(this, question, Loc.Get("Recipe_Apply"), MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

        SetBusy(true, Loc.Get("Recipe_Starting"));
        var progress = new Progress<string>(text => summaryLabel.Text = text);
        var error = await _recipeRunner.ApplyAsync(_catalog, progress);

        if (error == null)
        {
            LeaveRecipeMode(false);
        }

        SetBusy(false, "");
        RefreshRows();
        summaryLabel.Text = error == null
            ? Loc.Get("Recipe_Finished")
            : Loc.Format("Recipe_Stopped", error);
        if (error != null)
            MessageBox.Show(this, error, Loc.Get("Recipe_StoppedTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void BuildRecipeMenu()
    {
        var menu = new ContextMenuStrip();
        menu.Items.Add(Loc.Get("Recipe_Import"), null, (_, _) => ImportRecipe());
        menu.Items.Add(Loc.Get("Recipe_Export"), null, async (_, _) => await ExportRecipeAsync());
        recipeButton.Click += (_, _) => menu.Show(recipeButton, new Point(0, recipeButton.Height));
    }

    private void ImportRecipe()
    {
        using var dialog = new OpenFileDialog { Filter = Loc.Get("Recipe_OpenFilter") };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;

        //a new recipe starts from the choices that existed before the old one
        if (_recipeLoaded) LeaveRecipeMode(true);
        var previous = new RecipeSelectionSnapshot(_catalog);
        try
        {
            _recipeLoaded = RecipeService.Import(dialog.FileName, _catalog);
            _beforeRecipe = _recipeLoaded ? previous : null;
            if (!_recipeLoaded) previous.Restore();
            RefreshRows();
            if (!_recipeLoaded)
                MessageBox.Show(this, Loc.Get("Recipe_Unknown"), Loc.Get("Recipe_Title"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            previous.Restore();
            _recipeLoaded = false;
            _beforeRecipe = null;
            RefreshRows();
            MessageBox.Show(this, ex.Message, Loc.Get("Recipe_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DiscardRecipeButton_Click(object? sender, EventArgs e)
    {
        LeaveRecipeMode(true);
        RefreshRows();
    }

    private void LeaveRecipeMode(bool restorePrevious)
    {
        if (restorePrevious) _beforeRecipe?.Restore();
        else _catalog.RecipePreferences = null;
        _beforeRecipe = null;
        _recipeLoaded = false;
        UpdateRecipeBanner();
    }

    private void UpdateRecipeBanner()
    {
        recipeBanner.Visible = _recipeLoaded;
        applyRecipeButton.Visible = _recipeLoaded;
        applyRecipeButton.Enabled = _recipeLoaded;
        applyRecipeButton.Text = Loc.Get("Recipe_Apply");
        if (!_recipeLoaded) return;

        recipeBannerLabel.Text = Loc.Format("Recipe_Banner",
            _catalog.Rules.Count(item => item.Selected),
            _catalog.Rules.Count(item => !item.Selected && item.RestoreWithRecipe),
            _catalog.RecipePreferences?.PreferenceCount ?? 0,
            _catalog.Apps.Count(item => item.Selected),
            _catalog.Bloatware.Count(item => item.Selected),
            _catalog.Bloatware.Count(item => item.Selected && item.IsInstalled),
            _catalog.Actions.Count(item => item.Selected && item.RecipeAllowed),
            _catalog.RecipePreferences?.ConfirmationCount ?? 0);
    }

    private async Task ExportRecipeAsync()
    {
        try
        {
            //tweaks come from Windows, everything optional is chosen in the next window
            SetBusy(true, Loc.Get("Recipe_ReadingCurrent"));
            await _registry.ScanAsync(_catalog.Rules);
            _scanned = true;

            var current = PersonalizationService.Read();
            current.DefaultBrowserId = BrowserService.ReadDefaultBrowserId(_catalog.Apps);
            using var choices = new RecipeExportDialog(_catalog, current);
            if (choices.ShowDialog(this) != DialogResult.OK || choices.Plan == null) return;

            using var dialog = new SaveFileDialog
            {
                Filter = Loc.Get("Recipe_SaveFilter"),
                FileName = Loc.Get("Recipe_FileName")
            };
            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            RecipeService.Export(dialog.FileName, _catalog, choices.Plan);
            RefreshRows();
            summaryLabel.Text = Loc.Get("Recipe_Saved");
        }
        catch (Exception ex) { MessageBox.Show(this, ex.Message, Loc.Get("Recipe_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        finally { SetBusy(false, summaryLabel.Text); }
    }

    // --- Shared UI state -----------------------------------------------------

    private void SetBusy(bool busy, string text)
    {
        scanButton.Enabled = !busy;
        configureButton.Enabled = !busy && SelectedAreaKey != null;
        applyRecipeButton.Enabled = !busy && _recipeLoaded;
        recipeButton.Enabled = !busy;
        discardRecipeButton.Enabled = !busy;
        setupTree.Enabled = !busy;
        summaryLabel.Text = text;
        progress.Visible = busy;
        progress.Style = busy ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
    }

    // --- Native ---------------------------------------------------------------

    //without this the tree keeps the old +/- boxes; explorer themes its own tree the same way
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        SetWindowTheme(setupTree.Handle, "Explorer", null);
    }

    [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
    private static extern int SetWindowTheme(IntPtr window, string appName, string? idList);

    // --- Internal types ------------------------------------------------------

    private enum RowTone { Normal, Match, Difference }

    //restores the user's selections if an imported recipe is discarded
    private sealed class RecipeSelectionSnapshot
    {
        private readonly SetupCatalog _catalog;
        private readonly Dictionary<SetupRule, (bool Selected, bool Restore)> _rules;
        private readonly Dictionary<AppItem, bool> _apps;
        private readonly Dictionary<BloatwareItem, bool> _bloatware;
        private readonly Dictionary<SetupAction, (bool Selected, string Option)> _actions;
        private readonly PersonalizationChoices? _preferences;

        public RecipeSelectionSnapshot(SetupCatalog catalog)
        {
            _catalog = catalog;
            _rules = catalog.Rules.ToDictionary(item => item,
                item => (item.Selected, item.RestoreWithRecipe));
            _apps = catalog.Apps.ToDictionary(item => item, item => item.Selected);
            _bloatware = catalog.Bloatware.ToDictionary(item => item, item => item.Selected);
            _actions = catalog.Actions.ToDictionary(item => item,
                item => (item.Selected, item.SelectedOption));
            _preferences = catalog.RecipePreferences?.Clone();
        }

        public void Restore()
        {
            foreach (var pair in _rules)
            {
                pair.Key.Selected = pair.Value.Selected;
                pair.Key.RestoreWithRecipe = pair.Value.Restore;
            }
            foreach (var pair in _apps) pair.Key.Selected = pair.Value;
            foreach (var pair in _bloatware) pair.Key.Selected = pair.Value;
            foreach (var pair in _actions)
            {
                pair.Key.Selected = pair.Value.Selected;
                pair.Key.SelectedOption = pair.Value.Option;
            }
            _catalog.RecipePreferences = _preferences?.Clone();
        }
    }
}
