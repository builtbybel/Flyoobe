using Flyoobe3.Models;
using Flyoobe3.Services;

namespace Flyoobe3.Views;

//edits one rule category with the same small list for every loaded database
internal partial class RulesView : UserControl, INavigationGuard, ISearchableView
{
    private readonly List<SetupRule> _rules;
    private readonly RegistryService _registry;
    private bool _updating;
    private bool _loaded;
    private string _searchText = "";
    public bool CanNavigateAway { get; private set; } = true;

    //gives Visual Studio a harmless empty page to render at design time
    public RulesView() : this("Windows choices", new List<SetupRule>(), new RegistryService()) { }

    public RulesView(string category, List<SetupRule> rules, RegistryService registry)
    {
        _rules = rules;
        _registry = registry;
        InitializeComponent();
        ApplyLocalization(category);
    }

    private void ApplyLocalization(string category)
    {
        titleLabel.Text = Loc.RuleCategory(category);
        rulesList.Columns[0].Text = Loc.Get("Rules_Choice");
        rulesList.Columns[1].Text = Loc.Get("Common_ColumnStatus");
        rulesList.Columns[2].Text = Loc.Get("Rules_Current");
        checkButton.Text = Loc.Get("Common_CheckAgain");
        applyButton.Text = Loc.Get("Common_ApplySelected");
        restoreButton.Text = Loc.Get("Rules_RestoreDefaults");
        applyRuleMenuItem.Text = Loc.Get("Rules_ApplyChoice");
        restoreRuleMenuItem.Text = Loc.Get("Rules_RestoreDefault");
        explainRuleMenuItem.Text = Loc.Get("Rules_ExplainWithAI");
        selectAllMenuItem.Text = Loc.Get("Common_SelectAll");
        clearAllMenuItem.Text = Loc.Get("Common_ClearSelection");
        detailsBox.Text = Loc.Get("Rules_SelectChoice");
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
        if (_loaded) return;
        _loaded = true;
        await ScanAsync();
    }

    private async Task ScanAsync()
    {
        SetBusy(true, Loc.Get("Rules_CheckingValues"));
        await _registry.ScanAsync(_rules);
        FillRows();
        SetBusy(false, Loc.Format("Rules_ReadyCount", _rules.Count(rule => rule.IsApplied), _rules.Count));
    }

    private void FillRows()
    {
        _updating = true;
        rulesList.BeginUpdate();
        rulesList.Items.Clear();
        foreach (var rule in _rules.Where(MatchesSearch))
        {
            var row = new ListViewItem(Loc.RuleName(rule.Name))
            {
                Tag = rule,
                Checked = rule.Selected
            };
            row.SubItems.Add("");
            row.SubItems.Add(rule.CurrentValue);
            UpdateRowState(row, rule);
            rulesList.Items.Add(row);
        }
        rulesList.EndUpdate();
        _updating = false;
    }

    // --- Search -------------------------------------------------------------

    //The main window supplies the query; the page keeps ownership of filtering.
    public void ApplySearch(string text)
    {
        var searchText = text.Trim();
        if (_searchText.Equals(searchText, StringComparison.OrdinalIgnoreCase)) return;
        _searchText = searchText;
        FillRows();
    }

    private bool MatchesSearch(SetupRule rule) =>
        _searchText.Length == 0 ||
        Loc.RuleName(rule.Name).IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
        Loc.RuleDescription(rule.Name, rule.Description).IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
        rule.CurrentValue.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0;

    private async void CheckButton_Click(object? sender, EventArgs e) => await ScanAsync();

    private async void ApplyButton_Click(object? sender, EventArgs e)
    {
        SaveChecks();
        await ChangeAsync(_rules.Where(rule => rule.Selected).ToList(), restore: false);
    }

    private async void RestoreButton_Click(object? sender, EventArgs e)
    {
        SaveChecks();
        await ChangeAsync(_rules.Where(rule => rule.Selected).ToList(), restore: true);
    }

    private void RulesList_ItemChecked(object? sender, ItemCheckedEventArgs e)
    {
        if (_updating || !(e.Item.Tag is SetupRule rule)) return;
        SetRecipeChoice(rule, e.Item.Checked);
    }

    private void RulesList_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (rulesList.SelectedItems.Count == 0)
        {
            detailsBox.Text = Loc.Get("Rules_SelectChoice");
            return;
        }

        var rule = (SetupRule)rulesList.SelectedItems[0].Tag;
        detailsBox.Text = Loc.RuleDescription(rule.Name, rule.Description) + Environment.NewLine + Environment.NewLine +
                          Loc.Format("Rules_CurrentRecommended", rule.CurrentValue, rule.Entries[0].RecommendedValue);
    }

    private void RulesList_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        var row = rulesList.GetItemAt(e.X, e.Y);
        if (row == null) return;
        rulesList.SelectedIndices.Clear();
        row.Selected = true;
        row.Focused = true;
    }

    //select all and clear work without a row, so only the row actions are greyed out
    private void RuleMenu_Opening(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        var hasRow = SelectedRule != null;
        applyRuleMenuItem.Enabled = hasRow;
        restoreRuleMenuItem.Enabled = hasRow;
        explainRuleMenuItem.Enabled = hasRow;
    }

    private async void ApplyRuleMenuItem_Click(object? sender, EventArgs e)
    {
        var rule = SelectedRule;
        if (rule != null) await ChangeAsync(new[] { rule }, restore: false);
    }

    private async void RestoreRuleMenuItem_Click(object? sender, EventArgs e)
    {
        var rule = SelectedRule;
        if (rule != null) await ChangeAsync(new[] { rule }, restore: true);
    }

    private void ExplainRuleMenuItem_Click(object? sender, EventArgs e)
    {
        var rule = SelectedRule;
        if (rule == null) return;
        using var dialog = new ExplainDialog(Loc.RuleName(rule.Name));
        dialog.Shown += async (_, _) => await dialog.LoadAsync(rule);
        dialog.ShowDialog(FindForm());
    }

    private void SelectAllMenuItem_Click(object? sender, EventArgs e) => SetAllChecks(true);

    private void ClearAllMenuItem_Click(object? sender, EventArgs e) => SetAllChecks(false);

    //ticking is a recipe choice, so this only moves the boxes and never touches the registry
    private void SetAllChecks(bool value)
    {
        rulesList.BeginUpdate();
        foreach (ListViewItem row in rulesList.Items) row.Checked = value;
        rulesList.EndUpdate();
    }

    //one path for toolbar and right-click actions keeps the safety checks identical
    private async Task ChangeAsync(IReadOnlyCollection<SetupRule> selected, bool restore)
    {
        //the buttons act on the ticked rows, so say so instead of doing nothing
        if (selected.Count == 0)
        {
            MessageBox.Show(this, Loc.Get("Common_NothingSelected"), "Flyoobe",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (selected.Any(rule => rule.RequiresAdmin) && !WindowsActions.IsAdministrator())
        {
            MessageBox.Show(this, Loc.Get("Rules_AdminMessage"), Loc.Get("Common_AdminTitle"),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var choice = selected.First();
        var question = selected.Count == 1
            ? restore ? Loc.Format("Rules_RestoreOneQuestion", Loc.RuleName(choice.Name))
                : Loc.Format("Rules_ApplyOneQuestion", Loc.RuleName(choice.Name))
            : restore ? Loc.Format("Rules_RestoreManyQuestion", selected.Count)
                : Loc.Format("Rules_ApplyManyQuestion", selected.Count);
        if (MessageBox.Show(this, question, "Flyoobe", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

        SetBusy(true, restore ? Loc.Get("Rules_RestoringChoices") : Loc.Get("Rules_ApplyingChoices"));
        var error = restore
            ? await _registry.RestoreAsync(selected)
            : await _registry.ApplyAsync(selected);
        await ScanAsync();
        if (error != null) MessageBox.Show(this, error, "Flyoobe", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private SetupRule? SelectedRule =>
        rulesList.SelectedItems.Count == 0 ? null : rulesList.SelectedItems[0].Tag as SetupRule;

    private void SaveChecks()
    {
        foreach (ListViewItem row in rulesList.Items)
            if (row.Tag is SetupRule rule) SetRecipeChoice(rule, row.Checked);
    }

    private static void SetRecipeChoice(SetupRule rule, bool selected)
    {
        if (rule.Selected && !selected) rule.RestoreWithRecipe = true;
        else if (selected) rule.RestoreWithRecipe = false;
        rule.Selected = selected;
    }

    //status is what the scan measured, so a tick never changes it; the tick is a recipe choice
    private static void UpdateRowState(ListViewItem row, SetupRule rule)
    {
        row.SubItems[1].Text = rule.IsApplied ? Loc.Get("Rules_Ready") : Loc.Get("Rules_Review");
        row.ForeColor = rule.IsApplied ? SystemColors.GrayText : Color.Firebrick;
    }

    private void SetBusy(bool busy, string text)
    {
        CanNavigateAway = !busy;
        rulesList.Enabled = !busy;
        checkButton.Enabled = !busy;
        applyButton.Enabled = !busy;
        restoreButton.Enabled = !busy;
        statusLabel.Text = text;
    }

}
