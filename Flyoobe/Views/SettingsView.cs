using Flyoobe3.Services;
using Flyoobe3.Views.Settings;

namespace Flyoobe3.Views;

//only the settings shell, each sidebar item owns its small subpage
internal partial class SettingsView : UserControl
{
    private readonly GeneralSettingsView _general = new GeneralSettingsView();
    private readonly AiSettingsView _ai = new AiSettingsView();
    private readonly AdvancedSettingsView _advanced = new AdvancedSettingsView();
    private readonly AboutSettingsView _about = new AboutSettingsView();
    private readonly NavigationManager _subNav;
    private Control? _currentPage;

    public SettingsView()
    {
        InitializeComponent();
        _subNav = new NavigationManager(contentHost);
        ApplyLocalization();
        navigationList.Items[0].Selected = true;
        ShowPage(_general, Loc.Get("Settings_General"));
    }

    private void ApplyLocalization()
    {
        titleLabel.Text = Loc.Get("Settings_Title");
        helpLink.AccessibleName = Loc.Get("Common_Help");
        navigationList.Items.Clear();
        navigationList.Items.Add(new ListViewItem(Loc.Get("Settings_General")) { Tag = "general" });
        navigationList.Items.Add(new ListViewItem(Loc.Get("Settings_AI")) { Tag = "ai" });
        navigationList.Items.Add(new ListViewItem(Loc.Get("Settings_Advanced")) { Tag = "advanced" });
        navigationList.Items.Add(new ListViewItem(Loc.Get("Settings_About")) { Tag = "about" });
    }

    public void Save() => _ai.Save();

    private void HelpLink_Click(object? sender, EventArgs e)
        => AppLinks.Open(AppLinks.GitHub);

    private void NavigationList_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (navigationList.SelectedItems.Count == 0) return;
        switch (navigationList.SelectedItems[0].Tag as string)
        {
            case "ai": ShowPage(_ai, Loc.Get("Settings_AI")); break;
            case "advanced": ShowPage(_advanced, Loc.Get("Settings_Advanced")); break;
            case "about": ShowPage(_about, Loc.Get("Settings_About")); break;
            default: ShowPage(_general, Loc.Get("Settings_General")); break;
        }
    }

    private void ShowPage(Control page, string title)
    {
        if (ReferenceEquals(_currentPage, page)) return;
        if (ReferenceEquals(_currentPage, _ai)) _ai.Save();
        contentGroup.Text = title;
        _subNav.SwitchView(page);
        _currentPage = page;
    }
}
