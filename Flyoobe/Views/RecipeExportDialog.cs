using Flyoobe3.Models;
using Flyoobe3.Services;

namespace Flyoobe3.Views;

//lets the user choose the optional parts of one recipe export
internal partial class RecipeExportDialog : Form
{
    private readonly SetupCatalog _catalog;
    private readonly PersonalizationChoices _current;

    public RecipeExportPlan? Plan { get; private set; }

    public RecipeExportDialog() : this(new SetupCatalog(), new PersonalizationChoices())
    {
        //keeps the WinForms designer independent from the live catalog
    }

    public RecipeExportDialog(SetupCatalog catalog, PersonalizationChoices current)
    {
        _catalog = catalog;
        _current = current;
        InitializeComponent();
        if (System.ComponentModel.LicenseManager.UsageMode ==
            System.ComponentModel.LicenseUsageMode.Designtime) return;

        ApplyLocalization();
        WireEvents();
        LoadChoices();
    }

    private void ApplyLocalization()
    {
        Text = Loc.Get("Recipe_ExportTitle");
        introLabel.Text = Loc.Get("Recipe_ExportIntro");
        preferencesGroup.Text = Loc.Get("Recipe_ExportPreferences");
        appsGroup.Text = Loc.Get("Recipe_ExportApps");
        bloatwareGroup.Text = Loc.Get("Recipe_ExportBloatware");
        actionsGroup.Text = Loc.Get("Recipe_ExportActions");
        exportButton.Text = Loc.Get("Recipe_ExportButton");
        cancelButton.Text = Loc.Get("Recipe_ExportCancel");
        selectAllMenuItem.Text = Loc.Get("Common_SelectAll");
        clearAllMenuItem.Text = Loc.Get("Common_ClearSelection");
    }

    private void WireEvents()
    {
        exportButton.Click += ExportButton_Click;
        selectAllMenuItem.Click += (_, _) => SetAllChecks(true);
        clearAllMenuItem.Click += (_, _) => SetAllChecks(false);
        actionList.ItemCheck += ActionList_ItemCheck;
    }

    private void LoadChoices()
    {
        if (_current.DarkApps.HasValue || _current.DarkWindows.HasValue)
        {
            var apps = ThemeName(_current.DarkApps);
            var windows = ThemeName(_current.DarkWindows);
            preferenceList.Items.Add(new ExportChoice(Preference.Theme,
                Loc.Format("Recipe_ExportTheme", apps, windows)), true);
        }

        if (_current.TaskbarLeft.HasValue)
        {
            var alignment = Loc.Get(_current.TaskbarLeft == true
                ? "Personalization_Left" : "Personalization_Center");
            preferenceList.Items.Add(new ExportChoice(Preference.Taskbar,
                Loc.Format("Recipe_ExportTaskbar", alignment)), true);
        }

        if (_current.Transparency.HasValue)
        {
            var state = Loc.Get(_current.Transparency == true
                ? "Recipe_ExportEnabled" : "Recipe_ExportDisabled");
            preferenceList.Items.Add(new ExportChoice(Preference.Transparency,
                Loc.Format("Recipe_ExportTransparency", state)), true);
        }

        var browser = _catalog.Apps.FirstOrDefault(item =>
            item.WingetId.Equals(_current.DefaultBrowserId, StringComparison.OrdinalIgnoreCase));
        if (browser != null)
            preferenceList.Items.Add(new ExportChoice(Preference.Browser,
                Loc.Format("Recipe_ExportBrowser", browser.Name)), true);

        //SetupCatalog loads this list from Data\Apps.ini; the stable winget id is kept behind the visible name
        foreach (var app in _catalog.Apps.OrderBy(item => item.Name))
            appList.Items.Add(new ExportEntry(app.Name, app.WingetId), app.Selected);

        //this list comes from Data\Bloatware.ini; PackageName is the portable removal id written to the recipe
        foreach (var app in _catalog.Bloatware.OrderBy(item => item.Name))
            bloatwareList.Items.Add(new ExportEntry(app.Name, app.PackageName), app.Selected);

        //Only locally installed actions that explicitly opt into recipes are offered here.
        foreach (var action in _catalog.Actions.Where(item => item.RecipeAllowed).OrderBy(item => item.Name))
        {
            if (action.Options.Count == 0)
            {
                actionList.Items.Add(new ExportEntry(action.Name, action.Id, "true"), action.Selected);
                continue;
            }

            foreach (var option in action.Options)
                actionList.Items.Add(new ExportEntry(action.Name + " — " + option, action.Id, option),
                    action.Selected && action.SelectedOption.Equals(option, StringComparison.OrdinalIgnoreCase));
        }
        ConfigureActionsArea(actionList.Items.Count > 0);
    }

    private string ThemeName(bool? dark) => dark == true
        ? Loc.Get("Personalization_Dark") : Loc.Get("Personalization_Light");

    private void ExportButton_Click(object? sender, EventArgs e)
    {
        var plan = new RecipeExportPlan();
        foreach (ExportChoice choice in preferenceList.CheckedItems)
        {
            switch (choice.Value)
            {
                case Preference.Theme:
                    plan.Preferences.DarkApps = _current.DarkApps;
                    plan.Preferences.DarkWindows = _current.DarkWindows;
                    break;
                case Preference.Taskbar:
                    plan.Preferences.TaskbarLeft = _current.TaskbarLeft;
                    break;
                case Preference.Transparency:
                    plan.Preferences.Transparency = _current.Transparency;
                    break;
                case Preference.Browser:
                    plan.Preferences.DefaultBrowserId = _current.DefaultBrowserId;
                    break;
            }
        }

        //only checked rows become recipe actions; display names are never used as ids
        foreach (ExportEntry item in appList.CheckedItems)
            plan.AppIds.Add(item.Id); //winget id from Apps.ini
        foreach (ExportEntry item in bloatwareList.CheckedItems)
            plan.BloatwareIds.Add(item.Id); //PackageName from Bloatware.ini
        foreach (ExportEntry item in actionList.CheckedItems)
            plan.ActionChoices[item.Id] = item.Value; //stable id plus the selected dynamic option
        Plan = plan;
        DialogResult = DialogResult.OK;
    }

    private void SetAllChecks(bool value)
    {
        //the same menu serves both lists; SourceControl tells us where the user clicked
        if (!(listMenu.SourceControl is CheckedListBox list)) return;
        for (var index = 0; index < list.Items.Count; index++)
            list.SetItemChecked(index, value);
    }

    private void ActionList_ItemCheck(object? sender, ItemCheckEventArgs e)
    {
        if (e.NewValue != CheckState.Checked || !(actionList.Items[e.Index] is ExportEntry selected)) return;
        //One script is one recipe step. Its option rows are mutually exclusive.
        for (var index = 0; index < actionList.Items.Count; index++)
        {
            if (index == e.Index || !(actionList.Items[index] is ExportEntry item)) continue;
            if (item.Id.Equals(selected.Id, StringComparison.OrdinalIgnoreCase))
                actionList.SetItemChecked(index, false);
        }
    }

    private void ConfigureActionsArea(bool visible)
    {
        actionsGroup.Visible = visible;
        if (visible)
        {
            MinimumSize = new Size(690, 600);
            return;
        }

        //With the optional feature off the dialog keeps its old compact shape.
        MinimumSize = new Size(690, 480);
        ClientSize = new Size(760, 552);
        appsGroup.Location = new Point(12, 188);
        bloatwareGroup.Location = new Point(386, 188);
        appsGroup.Size = new Size(362, 310);
        bloatwareGroup.Size = new Size(362, 310);
        exportButton.Location = new Point(503, 510);
        cancelButton.Location = new Point(648, 510);
    }

    private enum Preference { Theme, Taskbar, Transparency, Browser }

    private sealed class ExportChoice
    {
        public Preference Value { get; }
        private string Text { get; }

        public ExportChoice(Preference value, string text)
        {
            Value = value;
            Text = text;
        }

        public override string ToString() => Text;
    }

    private sealed class ExportEntry
    {
        public string Id { get; }
        public string Value { get; }
        private string Text { get; }

        public ExportEntry(string text, string id, string value = "true")
        {
            Text = text;
            Id = id;
            Value = value;
        }

        public override string ToString() => Text;
    }
}
