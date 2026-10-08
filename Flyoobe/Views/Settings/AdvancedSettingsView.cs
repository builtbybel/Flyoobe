using System.Diagnostics;
using Flyoobe3.Services;

namespace Flyoobe3.Views.Settings;

//Optional features live here so the normal Flyoobe path stays as small as before.
internal partial class AdvancedSettingsView : UserControl
{
    private bool _loading;

    public AdvancedSettingsView()
    {
        InitializeComponent();
        ApplyLocalization();
        _loading = true;
        setupActionsCheck.Checked = AppSettings.Instance.SetupActionsEnabled;
        changeLogCheck.Checked = AppSettings.Instance.ChangeLogEnabled;
        _loading = false;
        UpdateState();
    }

    private void ApplyLocalization()
    {
        sectionLabel.Text = Loc.Get("Settings_OptionalFeatures");
        setupActionsCheck.Text = Loc.Get("Settings_SetupActionsEnabled");
        descriptionLabel.Text = Loc.Get("Settings_SetupActionsDescription");
        warningLabel.Text = Loc.Get("Settings_SetupActionsWarning");
        openFolderButton.Text = Loc.Get("Settings_OpenActionsFolder");
        logSectionLabel.Text = Loc.Get("Settings_SectionChangeLog");
        changeLogCheck.Text = Loc.Get("Settings_ChangeLogEnabled");
        logDescriptionLabel.Text = Loc.Get("Settings_ChangeLogDescription");
        openLogButton.Text = Loc.Get("Settings_OpenChangeLog");
    }

    private void SetupActionsCheck_CheckedChanged(object? sender, EventArgs e)
    {
        if (_loading) return;
        AppSettings.Instance.SetupActionsEnabled = setupActionsCheck.Checked;
        AppSettings.Instance.Save();
        UpdateState();
    }

    private void ChangeLogCheck_CheckedChanged(object? sender, EventArgs e)
    {
        if (_loading) return;
        AppSettings.Instance.ChangeLogEnabled = changeLogCheck.Checked;
        AppSettings.Instance.Save();
    }

    private void UpdateState() => openFolderButton.Enabled = setupActionsCheck.Checked;

    //the log only exists once Flyoobe has actually changed something
    private void OpenLogButton_Click(object? sender, EventArgs e)
    {
        if (!ChangeLog.Exists)
        {
            MessageBox.Show(this, Loc.Get("Settings_ChangeLogEmpty"), "Flyoobe",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        try { Process.Start(new ProcessStartInfo(ChangeLog.LogPath) { UseShellExecute = true }); }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Flyoobe", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}
