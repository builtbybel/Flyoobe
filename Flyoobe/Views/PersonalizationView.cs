using Flyoobe3.Models;
using Flyoobe3.Services;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Flyoobe3.Views;

//handles the few personal choices people usually make on a fresh Windows install
internal partial class PersonalizationView : UserControl
{
    public PersonalizationView()
    {
        InitializeComponent();
        ApplyLocalization();
        appModeBox.Items.AddRange(new object[] { Loc.Get("Personalization_Light"), Loc.Get("Personalization_Dark") });
        windowsModeBox.Items.AddRange(new object[] { Loc.Get("Personalization_Light"), Loc.Get("Personalization_Dark") });
        taskbarBox.Items.AddRange(new object[] { Loc.Get("Personalization_Left"), Loc.Get("Personalization_Center") });
        if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            LoadSettings();
    }

    private void ApplyLocalization()
    {
        titleLabel.Text = Loc.Get("Personalization_Title");
        introLabel.Text = Loc.Get("Personalization_Intro");
        choicesGroup.Text = Loc.Get("Personalization_Group");
        appModeLabel.Text = Loc.Get("Personalization_AppMode");
        windowsModeLabel.Text = Loc.Get("Personalization_WindowsMode");
        taskbarLabel.Text = Loc.Get("Personalization_TaskbarAlignment");
        transparencyBox.Text = Loc.Get("Personalization_Transparency");
        wallpaperTitleLabel.Text = Loc.Get("Personalization_Wallpaper");
        applyButton.Text = Loc.Get("Common_ApplySelected");
        wallpaperButton.Text = Loc.Get("Personalization_ChooseWallpaper");
        windowsSettingsButton.Text = Loc.Get("Personalization_MoreWindowsSettings");
        statusLabel.Text = Loc.Get("Personalization_Loaded");
    }

    private void LoadSettings()
    {
        var choices = PersonalizationService.Read();
        appModeBox.SelectedIndex = choices.DarkApps == true ? 1 : 0;
        windowsModeBox.SelectedIndex = choices.DarkWindows == true ? 1 : 0;
        transparencyBox.Checked = choices.Transparency == true;
        taskbarBox.SelectedIndex = choices.TaskbarLeft == true ? 0 : 1;

        using (var key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop"))
            wallpaperLabel.Text = key?.GetValue("WallPaper")?.ToString() ?? Loc.Get("Personalization_WindowsDefault");
    }

    private void ApplyButton_Click(object? sender, EventArgs e)
    {
        var choices = new PersonalizationChoices
        {
            DarkApps = appModeBox.SelectedIndex == 1,
            DarkWindows = windowsModeBox.SelectedIndex == 1,
            TaskbarLeft = taskbarBox.SelectedIndex == 0,
            Transparency = transparencyBox.Checked
        };
        var error = PersonalizationService.Apply(choices);
        if (error == null) statusLabel.Text = Loc.Get("Personalization_Applied");
        else MessageBox.Show(this, error, Loc.Get("Personalization_Title"),
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void WallpaperButton_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Filter = Loc.Get("Personalization_ImageFilter")
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;

        if (!SystemParametersInfo(20, 0, dialog.FileName, 0x01 | 0x02))
        {
            MessageBox.Show(this, Loc.Get("Personalization_WallpaperFailed"), Loc.Get("Personalization_Title"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        wallpaperLabel.Text = dialog.FileName;
        statusLabel.Text = Loc.Get("Personalization_WallpaperChanged");
    }

    private void WindowsSettingsButton_Click(object? sender, EventArgs e) =>
        WindowsActions.OpenPersonalization();

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool SystemParametersInfo(int action, int parameter, string value, int flags);
}
