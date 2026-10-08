using Flyoobe3.Models;
using Flyoobe3.Services;

namespace Flyoobe3.Views;

//checks Bloatware.ini against this pc and removes only confirmed packages
internal partial class BloatwareView : UserControl, INavigationGuard, ISearchableView
{
    private readonly List<BloatwareItem> _items;
    private readonly PackageService _packages;
    private bool _updating;
    private bool _loaded;
    private string _searchText = "";
    public bool CanNavigateAway { get; private set; } = true;

    //empty data keeps this control editable in the WinForms designer
    public BloatwareView() : this(new List<BloatwareItem>(), new PackageService()) { }

    public BloatwareView(List<BloatwareItem> items, PackageService packages)
    {
        _items = items;
        _packages = packages;
        InitializeComponent();
        WireEvents();
        ApplyLocalization();
        FillRows();
    }

    //events live here because the Visual Studio designer may rewrite its own file
    private void WireEvents()
    {
        appsList.ItemChecked += AppsList_ItemChecked;
        appsList.SelectedIndexChanged += AppsList_SelectedIndexChanged;
        removeButton.Click += RemoveButton_Click;
        scanButton.Click += ScanButton_Click;
        selectAllMenuItem.Click += (_, _) => SetAllChecks(true);
        clearAllMenuItem.Click += (_, _) => SetAllChecks(false);
    }

    private void ApplyLocalization()
    {
        titleLabel.Text = Loc.Get("Bloatware_Title");
        statusLabel.Text = Loc.Get("Bloatware_Ready");
        appsList.Columns[0].Text = Loc.Get("Common_ColumnApp");
        appsList.Columns[1].Text = Loc.Get("Common_ColumnCategory");
        appsList.Columns[2].Text = Loc.Get("Common_ColumnStatus");
        detailsBox.Text = Loc.Get("Bloatware_Select");
        removeButton.Text = Loc.Get("Bloatware_RemoveSelected");
        scanButton.Text = Loc.Get("Common_CheckAgain");
        selectAllMenuItem.Text = Loc.Get("Bloatware_SelectAllInstalled");
        clearAllMenuItem.Text = Loc.Get("Common_ClearSelection");
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
        SetBusy(true, Loc.Get("Bloatware_CheckingInstalled"));
        var error = await _packages.ScanBloatwareAsync(_items);
        FillRows();
        SetBusy(false, error ?? Loc.Format("Bloatware_Found", _items.Count(item => item.IsInstalled)));
        if (error != null) MessageBox.Show(this, error, Loc.Get("Bloatware_AppCheckTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void FillRows()
    {
        _updating = true;
        appsList.BeginUpdate();
        appsList.Items.Clear();
        //real matches first, the rest stays grouped and alphabetical
        foreach (var item in _items
                     .Where(MatchesSearch)
                     .OrderByDescending(app => app.IsInstalled)
                     .ThenBy(app => app.Category)
                     .ThenBy(app => app.Name))
        {
            var row = new ListViewItem(item.Name)
            {
                Tag = item,
                Checked = item.Selected && item.IsInstalled,
                ForeColor = item.IsInstalled ? Color.Firebrick : SystemColors.GrayText
            };
            row.SubItems.Add(item.Category);
            row.SubItems.Add(item.IsInstalled ? Loc.Get("Bloatware_Installed") : Loc.Get("Bloatware_NotFound"));
            appsList.Items.Add(row);
        }
        appsList.EndUpdate();
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

    private bool MatchesSearch(BloatwareItem item) =>
        _searchText.Length == 0 ||
        item.Name.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
        item.Category.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
        item.PackageName.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
        item.Description.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0;

    private async void ScanButton_Click(object? sender, EventArgs e) => await ScanAsync();

    private async void RemoveButton_Click(object? sender, EventArgs e)
    {
        SaveChecks();
        var selected = _items.Where(item => item.Selected && item.IsInstalled).ToList();
        //the button acts on the ticked rows, so say so instead of doing nothing
        if (selected.Count == 0)
        {
            MessageBox.Show(this, Loc.Get("Common_NothingSelected"), "Flyoobe",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (MessageBox.Show(this, Loc.Format("Bloatware_RemoveQuestion", selected.Count), "Flyoobe",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

        SetBusy(true, Loc.Get("Bloatware_RemovingSelected"));
        var progress = new Progress<string>(text => statusLabel.Text = text);
        var error = await _packages.RemoveAsync(selected, progress);
        await ScanAsync();
        if (error != null) MessageBox.Show(this, error, Loc.Get("Bloatware_AppRemovalTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void AppsList_ItemChecked(object? sender, ItemCheckedEventArgs e)
    {
        if (_updating || !(e.Item.Tag is BloatwareItem item)) return;
        item.Selected = e.Item.Checked;
    }

    private void AppsList_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (appsList.SelectedItems.Count == 0)
        {
            detailsBox.Text = Loc.Get("Bloatware_Select");
            return;
        }
        var item = (BloatwareItem)appsList.SelectedItems[0].Tag;
        detailsBox.Text = item.Description + Environment.NewLine + Environment.NewLine +
                          Loc.Format("Bloatware_Package", item.PackageName);
    }

    //only installed packages can be removed, so the menu never ticks the greyed-out rows
    private void SetAllChecks(bool value)
    {
        appsList.BeginUpdate();
        foreach (ListViewItem row in appsList.Items)
            if (row.Tag is BloatwareItem item && item.IsInstalled) row.Checked = value;
        appsList.EndUpdate();
    }

    private void SaveChecks()
    {
        foreach (ListViewItem row in appsList.Items)
            if (row.Tag is BloatwareItem item) item.Selected = row.Checked;
    }

    private void SetBusy(bool busy, string text)
    {
        CanNavigateAway = !busy;
        appsList.Enabled = !busy;
        scanButton.Enabled = !busy;
        removeButton.Enabled = !busy;
        progressBar.Visible = busy;
        statusLabel.Text = text;
    }

}
