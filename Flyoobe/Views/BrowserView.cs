using Flyoobe3.Models;
using Flyoobe3.Services;

namespace Flyoobe3.Views;

//finds installed browsers and reuses the winget catalog for new ones
internal partial class BrowserView : UserControl, INavigationGuard
{
    private readonly List<AppItem> _browsers;
    private readonly PackageService _packages;
    public bool CanNavigateAway { get; private set; } = true;

    //an empty browser list is enough for Visual Studio to draw the control
    public BrowserView() : this(new List<AppItem>(), new PackageService()) { }

    public BrowserView(List<AppItem> apps, PackageService packages)
    {
        _browsers = apps.Where(item => item.Category.Equals("Browsers", StringComparison.OrdinalIgnoreCase))
            .OrderBy(item => item.Name).ToList();
        _packages = packages;
        InitializeComponent();
        WireEvents();
        ApplyLocalization();
        if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
        LoadInstalledBrowsers();
        installBrowserBox.DisplayMember = nameof(AppItem.Name);
        foreach (var browser in _browsers) installBrowserBox.Items.Add(browser);
        if (installBrowserBox.Items.Count > 0) installBrowserBox.SelectedIndex = 0;
    }

    //events live here because the Visual Studio designer may rewrite its own file
    private void WireEvents()
    {
        defaultBrowserButton.Click += DefaultBrowserButton_Click;
        installButton.Click += InstallButton_Click;
    }

    private void ApplyLocalization()
    {
        titleLabel.Text = Loc.Get("Browser_Title");
        introLabel.Text = Loc.Get("Browser_Intro");
        defaultGroup.Text = Loc.Get("Browser_DefaultBrowser");
        defaultBrowserButton.Text = Loc.Get("Browser_ChooseDefault");
        installGroup.Text = Loc.Get("Browser_InstallBrowser");
        installButton.Text = Loc.Get("Browser_Install");
        statusLabel.Text = Loc.Get("Browser_WindowsConfirm");
    }

    private void LoadInstalledBrowsers()
    {
        installedBrowserBox.Items.Clear();
        var installed = BrowserService.FindInstalled(_browsers);
        foreach (var browser in installed) installedBrowserBox.Items.Add(browser);
        if (installedBrowserBox.Items.Count == 0) return;

        var currentId = BrowserService.ReadDefaultBrowserId(_browsers);
        var current = installed.FirstOrDefault(item =>
            item.App.WingetId.Equals(currentId, StringComparison.OrdinalIgnoreCase));
        installedBrowserBox.SelectedItem = current ?? installed[0];
    }

    private void DefaultBrowserButton_Click(object? sender, EventArgs e)
    {
        var browser = installedBrowserBox.SelectedItem as RegisteredBrowser;
        WindowsActions.OpenDefaultApps(browser?.RegisteredName, browser?.IsUserRegistration == true);
        statusLabel.Text = Loc.Get("Browser_ChooseLinks");
    }

    private async void InstallButton_Click(object? sender, EventArgs e)
    {
        if (!(installBrowserBox.SelectedItem is AppItem browser)) return;
        SetBusy(true, Loc.Format("Common_Installing", browser.Name));
        var error = await _packages.InstallAsync(new[] { browser });
        SetBusy(false, error ?? Loc.Format("Browser_InstallFinished", browser.Name));
        if (error != null) MessageBox.Show(this, error, Loc.Get("Browser_InstallTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        else LoadInstalledBrowsers();
    }

    private void SetBusy(bool busy, string text)
    {
        CanNavigateAway = !busy;
        installButton.Enabled = !busy;
        defaultBrowserButton.Enabled = !busy;
        progressBar.Visible = busy;
        statusLabel.Text = text;
    }

}
