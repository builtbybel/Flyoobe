using Flyoobe3.Models;
using Flyoobe3.Services;

namespace Flyoobe3.Views;

//shows the Apps.ini catalog and installs checked entries with winget
internal partial class AppsView : UserControl, INavigationGuard, ISearchableView
{
    private readonly List<AppItem> _apps;
    private readonly PackageService _packages;
    private bool _updating;
    private bool _loaded;
    private int _sortColumn;
    private bool _sortAscending = true;
    private string _searchText = "";
    public bool CanNavigateAway { get; private set; } = true;

    //kept for the WinForms designer, the app passes the shared catalog below
    public AppsView() : this(new List<AppItem>(), new PackageService()) { }

    public AppsView(List<AppItem> apps, PackageService packages)
    {
        _apps = apps;
        _packages = packages;
        InitializeComponent();
        ApplyLocalization();
        LoadCategories();
        WireEvents();
        FillRows();
    }

    //kept outside the designer so saving the layout cannot break the page again
    private void WireEvents()
    {
        categoryBox.SelectedIndexChanged += CategoryBox_SelectedIndexChanged;
        appsList.ItemCheck += AppsList_ItemCheck;
        appsList.ColumnClick += AppsList_ColumnClick;
        appsList.SelectedIndexChanged += AppsList_SelectedIndexChanged;
        installButton.Click += InstallButton_Click;
        scanButton.Click += ScanButton_Click;
        selectAllMenuItem.Click += (_, _) => SetAllChecks(true);
        clearAllMenuItem.Click += (_, _) => SetAllChecks(false);
    }

    private void ApplyLocalization()
    {
        titleLabel.Text = Loc.Get("Apps_Title");
        categoryLabel.Text = Loc.Get("Apps_Category");
        appsList.Columns[0].Text = Loc.Get("Common_ColumnApp");
        appsList.Columns[1].Text = Loc.Get("Common_ColumnCategory");
        appsList.Columns[2].Text = Loc.Get("Apps_ColumnWingetId");
        appsList.Columns[3].Text = Loc.Get("Common_ColumnStatus");
        installButton.Text = Loc.Get("Apps_InstallSelected");
        scanButton.Text = Loc.Get("Apps_CheckInstalled");
        detailsBox.Text = Loc.Get("Apps_SelectApp");
        selectAllMenuItem.Text = Loc.Get("Common_SelectAll");
        clearAllMenuItem.Text = Loc.Get("Common_ClearSelection");
    }

    private void LoadCategories()
    {
        categoryBox.Items.Clear();
        categoryBox.Items.Add(Loc.Get("Apps_AllCategories"));
        foreach (var category in _apps.Select(item => item.Category).Distinct().OrderBy(value => value))
            categoryBox.Items.Add(category);
        categoryBox.SelectedIndex = 0;
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
        if (_loaded) return;
        _loaded = true;
        await ScanInstalledAsync();
    }

    private void FillRows()
    {
        _updating = true;
        appsList.BeginUpdate();
        appsList.Items.Clear();
        var filter = _searchText;
        var category = categoryBox.SelectedIndex > 0 ? categoryBox.SelectedItem?.ToString() : null;
        var visible = _apps.Where(item => filter.Length == 0 ||
            item.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
            item.Category.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
            item.WingetId.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
        if (category != null)
            visible = visible.Where(item => item.Category.Equals(category, StringComparison.OrdinalIgnoreCase));

        foreach (var app in SortRows(visible))
        {
            var row = new ListViewItem(app.Name)
            {
                Tag = app,
                Checked = app.Selected && !app.IsInstalled,
                ForeColor = app.IsInstalled ? SystemColors.GrayText : SystemColors.WindowText
            };
            row.SubItems.Add(app.Category);
            row.SubItems.Add(app.WingetId);
            row.SubItems.Add(Loc.Get(app.IsInstalled ? "Apps_Installed" : "Apps_NotInstalled"));
            appsList.Items.Add(row);
        }
        appsList.EndUpdate();
        _updating = false;
        UpdateStatus();
    }

    private async void InstallButton_Click(object? sender, EventArgs e)
    {
        SaveChecks();
        var selected = _apps.Where(item => item.Selected).ToList();
        //the button acts on the ticked rows, so say so instead of doing nothing
        if (selected.Count == 0)
        {
            MessageBox.Show(this, Loc.Get("Common_NothingSelected"), "Flyoobe",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (MessageBox.Show(this, Loc.Format("Apps_InstallQuestion", selected.Count), "Flyoobe",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        SetBusy(true);
        var progress = new Progress<string>(text => statusLabel.Text = text);
        var error = await _packages.InstallAsync(selected, progress);
        foreach (var app in selected.Where(item => item.IsInstalled)) app.Selected = false;
        FillRows();
        SetBusy(false);
        statusLabel.Text = error ?? Loc.Get("Apps_Finished");
        if (error != null) MessageBox.Show(this, error, Loc.Get("Apps_InstallTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void AppsList_ItemCheck(object? sender, ItemCheckEventArgs e)
    {
        if (_updating || !(appsList.Items[e.Index].Tag is AppItem app)) return;
        if (app.IsInstalled && e.NewValue == CheckState.Checked)
            e.NewValue = CheckState.Unchecked;
        app.Selected = e.NewValue == CheckState.Checked;
        BeginInvoke((Action)UpdateStatus);
    }

    private void AppsList_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (appsList.SelectedItems.Count == 0)
        {
            detailsBox.Text = Loc.Get("Apps_SelectApp");
            return;
        }
        var app = (AppItem)appsList.SelectedItems[0].Tag;
        detailsBox.Text = app.Description + Environment.NewLine + Environment.NewLine +
                          Loc.Get(app.IsInstalled ? "Apps_Installed" : "Apps_NotInstalled") +
                          Environment.NewLine + "winget: " + app.WingetId;
    }

    // --- Search -------------------------------------------------------------

    //The shared search box replaces the former page-local search control.
    public void ApplySearch(string text)
    {
        var searchText = text.Trim();
        if (_searchText.Equals(searchText, StringComparison.OrdinalIgnoreCase)) return;
        _searchText = searchText;
        FillRows();
    }

    private void CategoryBox_SelectedIndexChanged(object? sender, EventArgs e) => FillRows();

    private void AppsList_ColumnClick(object? sender, ColumnClickEventArgs e)
    {
        if (_sortColumn == e.Column) _sortAscending = !_sortAscending;
        else
        {
            _sortColumn = e.Column;
            //installed apps are the useful first view for the status column
            _sortAscending = e.Column != 3;
        }
        FillRows();
    }

    private async void ScanButton_Click(object? sender, EventArgs e) => await ScanInstalledAsync();

    //already installed apps cannot be installed again, so the menu skips those rows
    private void SetAllChecks(bool value)
    {
        appsList.BeginUpdate();
        foreach (ListViewItem row in appsList.Items)
            if (row.Tag is AppItem app && !app.IsInstalled) row.Checked = value;
        appsList.EndUpdate();
    }

    private void SaveChecks()
    {
        foreach (ListViewItem row in appsList.Items)
            if (row.Tag is AppItem app) app.Selected = row.Checked;
    }

    private IEnumerable<AppItem> SortRows(IEnumerable<AppItem> items)
    {
        string Key(AppItem item) => _sortColumn switch
        {
            1 => item.Category,
            2 => item.WingetId,
            3 => item.IsInstalled ? "1" : "0",
            _ => item.Name
        };

        var comparer = StringComparer.CurrentCultureIgnoreCase;
        var sorted = _sortAscending
            ? items.OrderBy(Key, comparer)
            : items.OrderByDescending(Key, comparer);
        return sorted.ThenBy(item => item.Name, comparer);
    }

    private async Task ScanInstalledAsync()
    {
        SetBusy(true);
        statusLabel.Text = Loc.Get("Apps_CheckingInstalled");
        var error = await _packages.ScanInstalledAppsAsync(_apps);
        FillRows();
        SetBusy(false);
        if (error != null) statusLabel.Text = Loc.Format("Apps_CheckFailed", error);
    }

    private void UpdateStatus() =>
        statusLabel.Text = Loc.Format("Apps_Status", _apps.Count(item => item.Selected),
            appsList.Items.Count, _apps.Count(item => item.IsInstalled), _apps.Count);

    private void SetBusy(bool busy)
    {
        CanNavigateAway = !busy;
        appsList.Enabled = !busy;
        installButton.Enabled = !busy;
        scanButton.Enabled = !busy;
        progressBar.Visible = busy;
    }

}
