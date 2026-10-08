using Flyoobe3.Features.SetupActions;
using Flyoobe3.Services;
using Flyoobe3.Views;
using System.Runtime.InteropServices;

namespace Flyoobe3;

//owns the shared data and opens one small view at a time
public partial class MainForm : Form
{
    private readonly SetupCatalog _catalog = new SetupCatalog();          //everything the app knows: rules, apps, bloatware, actions
    private readonly RegistryService _registry = new RegistryService();   //reads and writes the registry values behind the rules
    private readonly PackageService _packages = new PackageService();     //installs and removes store packages
    private readonly RecipeRunner _recipeRunner;                          //applies a whole recipe in one go
    private readonly NavigationManager _navigation;                       //swaps the one visible view inside the host panel
    private readonly OverviewView _overview;                              //the home page, kept alive so its scan survives a detour
    private Control? _currentView;                                        //whatever is on screen right now
    private string _currentSectionKey = "overview";                       //its stable id, drives breadcrumb and back button
    private string? _forwardSectionKey;                                   //the page we just left, so forward can return to it
    private const int EmSetCueBanner = 0x1501;                            //win32 message for the grey hint inside a text box

    // --- Setup ---------------------------------------------------------------

    public MainForm()
    {
        InitializeComponent();                                                
        ApplyLocalization();                                                    //put the current language on that chrome
        LoadWindowIcon();                                               
        _catalog.Load();                                                        //read the databases before any view asks for them

        _recipeRunner = new RecipeRunner(_registry, _packages);                 //services first, the views depend on them
        _navigation = new NavigationManager(viewHost);                          //give the navigator the panel it is allowed to fill
        _overview = new OverviewView(_catalog, _registry, _recipeRunner, _packages);
        _overview.OpenRequested += OpenSection;                                 //the only way a view asks to go somewhere
        _navigation.SetHome(_overview);                                         //home is the one page that is never disposed
        _currentView = _overview;                                               //we start there, so say so out loud
        UpdateNavigationBar();                                                  //breadcrumb and arrows match that starting point
        RestoreWindowState();                                                   //last, so size and position win over any layout pass
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        //the constructor already ran this, but the search box had no window handle yet,
        //so its grey hint was skipped. this is the first moment it can be written.
        UpdateSearchBox();
    }

    //the icon file inside the exe carries every size, so title bar and taskbar both stay sharp
    private void LoadWindowIcon()
    {
        using var stream = typeof(MainForm).Assembly
            .GetManifestResourceStream("Flyoobe3.Assets.AppIcon.ico");
        if (stream != null) Icon = new Icon(stream);
    }

    private void ApplyLocalization()
    {
        statusLeft.Text = Loc.Get("Main_Donate");
        statusRight.Text = AppInfo.DisplayVersion;
        navigationTips.SetToolTip(backButton, Loc.Get("Common_Back"));
        navigationTips.SetToolTip(forwardButton, Loc.Get("Main_Forward"));
        navigationTips.SetToolTip(settingsButton, Loc.Get("Settings_Title"));
    }

    // --- Navigation ----------------------------------------------------------

    //reachable from every page; once there it does nothing, so it cannot stack up in the history
    private void SettingsButton_Click(object? sender, EventArgs e)
    {
        if (_currentSectionKey != "settings") OpenSection("settings");
    }

    private void OpenSection(string key)
    {
        if (key.StartsWith("rules:", StringComparison.OrdinalIgnoreCase))
        {
            var category = key.Substring("rules:".Length);
            var view = new RulesView(category,
                _catalog.Rules.Where(rule => rule.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList(),
                _registry);
            ShowSection(view, key);
            return;
        }

        if (key == "apps")
        {
            var view = new AppsView(_catalog.Apps, _packages);
            ShowSection(view, key);
        }
        else if (key == "bloatware")
        {
            var view = new BloatwareView(_catalog.Bloatware, _packages);
            ShowSection(view, key);
        }
        else if (key == "actions" && AppSettings.Instance.SetupActionsEnabled)
        {
            var view = new SetupActionsView(_catalog.Actions);
            ShowSection(view, key);
        }
        else if (key == "browser")
        {
            var view = new BrowserView(_catalog.Apps, _packages);
            ShowSection(view, key);
        }
        else if (key == "personalization")
        {
            var view = new PersonalizationView();
            ShowSection(view, key);
        }
        else if (key == "account")
        {
            var view = new AccountView();
            ShowSection(view, key);
        }
        else if (key == "rating")
        {
            var view = new RatingView(_catalog);
            view.OpenRequested += OpenSection;              //its review button jumps to the weakest area
            ShowSection(view, key);
        }
        else if (key == "settings")
        {
            ShowSection(new SettingsView(), key);
        }
        else if (key == "device")
        {
            WindowsActions.OpenAbout();
        }
        else if (key == "network")
        {
            WindowsActions.OpenNetwork();
        }
        else if (key == "update")
        {
            WindowsActions.OpenWindowsUpdate();
        }
        else if (key == "upgrade")
        {
            var view = new UpgradeView();
            ShowSection(view, key);
        }
    }

    private void ShowSection(Control view, string key)
    {
        view.BackColor = SystemColors.Window;
        _navigation.Show(view);
        _currentView = view;
        _currentSectionKey = key;
        _forwardSectionKey = null;
        ApplySearchToCurrentView();
        UpdateNavigationBar();
    }

    private void BackHome()
    {
        if (_currentSectionKey != "overview") _forwardSectionKey = _currentSectionKey;
        _overview.RefreshRows();
        _navigation.Back();
        _currentView = _overview;
        _currentSectionKey = "overview";
        ApplySearchToCurrentView();
        UpdateNavigationBar();
    }

    //the settings page is the one detour that has to save itself before it closes
    private void SettingsBackHome()
    {
        if (_currentView is SettingsView settingsView) settingsView.Save();
        //Enabling or disabling Setup Actions takes effect as soon as the settings page closes.
        _catalog.ReloadActions();
        BackHome();
    }

    private void BackButton_Click(object? sender, EventArgs e)
    {
        if (_currentView is INavigationGuard guard && !guard.CanNavigateAway) return;
        if (_currentSectionKey == "settings") SettingsBackHome();
        else BackHome();
    }

    //the first crumb is the same door as the back arrow, but it stays quiet once we are home
    private void CrumbRootButton_Click(object? sender, EventArgs e)
    {
        if (_currentSectionKey != "overview") BackButton_Click(sender, e);
    }

    private void ForwardButton_Click(object? sender, EventArgs e)
    {
        if (_currentSectionKey != "overview" || _forwardSectionKey == null) return;
        var key = _forwardSectionKey;
        _forwardSectionKey = null;
        OpenSection(key);
    }

    private void UpdateNavigationBar()
    {
        backButton.Enabled = _currentSectionKey != "overview";
        forwardButton.Enabled = _currentSectionKey == "overview" && _forwardSectionKey != null;
        crumbCurrentLabel.Text = "›  " + SectionTitle(_currentSectionKey);
        UpdateSearchBox();
    }

    private static string SectionTitle(string key)
    {
        if (key.StartsWith("rules:", StringComparison.OrdinalIgnoreCase))
            return Loc.RuleCategory(key.Substring("rules:".Length));
        if (key == "apps") return Loc.Get("Apps_Title");
        if (key == "bloatware") return Loc.Get("Bloatware_Title");
        if (key == "actions") return Loc.Get("Actions_Title");
        if (key == "browser") return Loc.Get("Browser_Title");
        if (key == "personalization") return Loc.Get("Personalization_Title");
        if (key == "account") return Loc.Get("Account_Title");
        if (key == "rating") return Loc.Get("Rating_Title");
        if (key == "settings") return Loc.Get("Settings_Title");
        if (key == "upgrade") return "Windows upgrade";
        return Loc.Get("Overview_Title");
    }

    // --- Shared page search -------------------------------------------------

    //runs on every page change: a disabled text box greys itself, so the field greys with it
    //and stays one control, and the grey hint names the page that is searched
    private void UpdateSearchBox()
    {
        searchBox.Enabled = _currentView is ISearchableView;
        searchField.BackColor = searchBox.Enabled
            ? SystemColors.Window : SystemColors.Control;

        //control panel names the place that is searched; the overview stands for the whole app.
        //word order differs per language, so the translation carries the whole sentence
        var hint = Loc.Format("Apps_Search",
            _currentSectionKey == "overview" ? AppInfo.Name : SectionTitle(_currentSectionKey));
        //the cue banner needs the native edit control, which does not exist yet during startup
        if (searchBox.IsHandleCreated)
            SendMessage(searchBox.Handle, EmSetCueBanner, (IntPtr)1, hint);
        navigationTips.SetToolTip(searchBox, hint);
    }

    private void SearchBox_TextChanged(object? sender, EventArgs e)
    {
        //explorer shows the clear cross only while there is something to clear
        clearSearchButton.Visible = searchBox.Text.Length > 0;
        ApplySearchToCurrentView();
    }

    private void ClearSearchButton_Click(object? sender, EventArgs e)
    {
        searchBox.Clear();
        searchBox.Focus();
    }

    private void ApplySearchToCurrentView()
    {
        if (_currentView is ISearchableView searchable)
            searchable.ApplySearch(searchBox.Text);
    }

    // --- Window state --------------------------------------------------------

    private void RestoreWindowState()
    {
        var settings = AppSettings.Instance;
        Size = new Size(Math.Max(settings.WindowWidth, MinimumSize.Width),
            Math.Max(settings.WindowHeight, MinimumSize.Height));
        var bounds = new Rectangle(settings.WindowX, settings.WindowY, Width, Height);
        if (settings.WindowX >= 0 && settings.WindowY >= 0 &&
            Screen.AllScreens.Any(screen => screen.WorkingArea.IntersectsWith(bounds)))
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(settings.WindowX, settings.WindowY);
        }
        if (settings.WindowState == (int)FormWindowState.Maximized)
            WindowState = FormWindowState.Maximized;
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (_currentView is SettingsView settingsView) settingsView.Save();
        var bounds = WindowState == FormWindowState.Normal ? Bounds : RestoreBounds;
        var appSettings = AppSettings.Instance;
        appSettings.WindowWidth = bounds.Width;
        appSettings.WindowHeight = bounds.Height;
        appSettings.WindowX = bounds.X;
        appSettings.WindowY = bounds.Y;
        appSettings.WindowState = WindowState == FormWindowState.Maximized
            ? (int)FormWindowState.Maximized : (int)FormWindowState.Normal;
        appSettings.Save();
        base.OnFormClosing(e);
    }

    // --- Shell links and visuals --------------------------------------------

    private void StatusLeft_Click(object? sender, EventArgs e)
        => AppLinks.Open(AppLinks.Donation);

    //raw Win32 call, WinForms has no property for this; used to set the search box's cue banner
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr SendMessage(IntPtr window, int message, IntPtr parameter, string text);
}