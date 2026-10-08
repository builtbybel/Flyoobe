using System.Diagnostics;
using Flyoobe3.Services;

namespace Flyoobe3.Features.SetupActions;

//A deliberately plain native page: inspect a package, import one, or run exactly one after confirmation.
internal partial class SetupActionsView : UserControl, INavigationGuard, ISearchableView
{
    private readonly List<SetupAction> _actions;
    private string _searchText = "";
    public bool CanNavigateAway { get; private set; } = true;
    public SetupActionsView() : this(new List<SetupAction>()) { }

    public SetupActionsView(List<SetupAction> actions)
    {
        _actions = actions;
        InitializeComponent();
        ApplyLocalization();
        RefreshList();
    }

    private void ApplyLocalization()
    {
        titleLabel.Text = Loc.Get("Actions_Title");
        introLabel.Text = Loc.Get("Actions_Intro");
        nameColumn.Text = Loc.Get("Actions_ColumnName");
        phaseColumn.Text = Loc.Get("Actions_ColumnPhase");
        adminColumn.Text = Loc.Get("Actions_ColumnAdmin");
        recipeColumn.Text = Loc.Get("Actions_ColumnRecipe");
        runButton.Text = Loc.Get("Actions_RunSelected");
        importButton.Text = Loc.Get("Actions_Import");
        openFolderButton.Text = Loc.Get("Settings_OpenActionsFolder");
        optionLabel.Text = Loc.Get("Actions_Option");
    }

    private void RefreshList(string? selectId = null)
    {
        actionList.BeginUpdate();
        actionList.Items.Clear();
        foreach (var action in _actions.Where(MatchesSearch).OrderBy(item => item.Name))
        {
            var row = new ListViewItem(action.Name) { Tag = action };
            row.SubItems.Add(Loc.Get("Actions_Phase_" + action.Phase));
            row.SubItems.Add(Loc.Get(action.RequiresAdmin ? "Common_Yes" : "Common_No"));
            row.SubItems.Add(Loc.Get(action.RecipeAllowed ? "Common_Yes" : "Common_No"));
            actionList.Items.Add(row);
            if (action.Id.Equals(selectId, StringComparison.OrdinalIgnoreCase)) row.Selected = true;
        }
        actionList.EndUpdate();
        UpdateDetails();
    }

    // --- Search -------------------------------------------------------------

    //The main window supplies the query; the page keeps ownership of filtering.
    public void ApplySearch(string text)
    {
        var searchText = text.Trim();
        if (_searchText.Equals(searchText, StringComparison.OrdinalIgnoreCase)) return;
        _searchText = searchText;
        RefreshList();
    }

    private bool MatchesSearch(SetupAction action) =>
        _searchText.Length == 0 ||
        action.Name.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
        action.Description.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
        action.Id.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
        action.Author.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0;

    private void ActionList_SelectedIndexChanged(object? sender, EventArgs e) => UpdateDetails();

    private void UpdateDetails()
    {
        runButton.Enabled = actionList.SelectedItems.Count > 0;
        if (actionList.SelectedItems.Count == 0)
        {
            detailsBox.Text = Loc.Get("Actions_SelectOne");
            optionLabel.Visible = optionBox.Visible = false;
            return;
        }
        var action = (SetupAction)actionList.SelectedItems[0].Tag;
        detailsBox.Text = action.Description + Environment.NewLine + Environment.NewLine;
        if (action.Warning.Length > 0)
            detailsBox.Text += Loc.Format("Actions_Warning", action.Warning) + Environment.NewLine + Environment.NewLine;
        detailsBox.Text += Loc.Format("Actions_Metadata", action.Id, action.Version, action.Author);

        optionBox.Items.Clear();
        foreach (var option in action.Options) optionBox.Items.Add(option);
        if (optionBox.Items.Count > 0)
        {
            var selected = Math.Max(0, action.Options.FindIndex(item => item.Equals(
                action.SelectedOption, StringComparison.OrdinalIgnoreCase)));
            optionBox.SelectedIndex = selected;
        }
        optionLabel.Visible = optionBox.Visible = action.Options.Count > 0;
    }

    private void OptionBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (actionList.SelectedItems.Count == 0 || optionBox.SelectedItem is not string option) return;
        ((SetupAction)actionList.SelectedItems[0].Tag).SelectedOption = option;
    }

    private async void RunButton_Click(object? sender, EventArgs e)
    {
        if (actionList.SelectedItems.Count == 0) return;
        var action = (SetupAction)actionList.SelectedItems[0].Tag;
        var question = action.Warning.Length == 0
            ? Loc.Format("Actions_RunQuestion", action.Name)
            : Loc.Format("Actions_RunWarningQuestion", action.Name, action.Warning);
        if (MessageBox.Show(this, question, Loc.Get("Actions_Title"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        SetBusy(true, Loc.Format("Actions_Running", action.Name));
        detailsBox.Text = Loc.Format("Actions_LiveOutput", action.Name) + Environment.NewLine;
        var progress = new Progress<string>(text => statusLabel.Text = text);
        var output = new Progress<string>(AppendOutputLine);
        var error = await SetupActionService.RunAsync(new[] { action }, null, progress, output);
        SetBusy(false, error == null ? Loc.Get("Actions_Finished") : Loc.Format("Actions_Stopped", error));
        if (error != null)
            MessageBox.Show(this, error, Loc.Get("Actions_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void AppendOutputLine(string line)
    {
        detailsBox.AppendText(line + Environment.NewLine);
        detailsBox.SelectionStart = detailsBox.TextLength;
        detailsBox.ScrollToCaret();
    }

    private void ImportButton_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Filter = Loc.Get("Actions_ImportFilter"),
            Title = Loc.Get("Actions_Import")
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            var imported = SetupActionService.Import(dialog.FileName);
            _actions.Add(imported);
            RefreshList(imported.Id);
            statusLabel.Text = Loc.Format("Actions_Imported", imported.Name);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, Loc.Get("Actions_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void OpenFolderButton_Click(object? sender, EventArgs e)
    {
        try
        {
            Directory.CreateDirectory(AppPaths.ActionsFolder);
            Process.Start(new ProcessStartInfo(AppPaths.ActionsFolder) { UseShellExecute = true });
        }
        catch { }
    }

    private void SetBusy(bool busy, string status)
    {
        CanNavigateAway = !busy;
        actionList.Enabled = !busy;
        runButton.Enabled = !busy && actionList.SelectedItems.Count > 0;
        importButton.Enabled = !busy;
        openFolderButton.Enabled = !busy;
        optionBox.Enabled = !busy;
        statusLabel.Text = status;
    }
}
