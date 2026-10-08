using Flyoobe3.Services;
using System.Diagnostics;

namespace Flyoobe3.Views.Settings;

//I keep this page informational: language, paths and the databases Flyoobe actually found
internal partial class GeneralSettingsView : UserControl
{
    private bool _loading;

    public GeneralSettingsView()
    {
        InitializeComponent();
        ApplyLocalization();
        LoadLanguages();
    }

    private void ApplyLocalization()
    {
        languageLabel.Text = Loc.Get("Settings_Language");
        openLocalizationButton.Text = Loc.Get("Settings_OpenLocalizationFolder");
        openDataButton.Text = Loc.Get("Settings_OpenDataFolder");
        settingsFileTitleLabel.Text = Loc.Get("Settings_File");
        settingsFileLabel.Text = AppSettings.SettingsPath;
        databasesTitleLabel.Text = Loc.Get("Settings_Databases");
        databasesDescriptionLabel.Text = Loc.Get("Settings_DatabasesDescription");
        RefreshDatabases();
    }

    private void RefreshDatabases()
    {
        databaseList.Items.Clear();
        foreach (var path in AppPaths.RuleDatabases())
        {
            var count = IniFile.Read(path).Count(section => section.Get("Path").Length > 0);
            databaseList.Items.Add(Loc.Format("Settings_DatabaseEntry", Path.GetFileName(path), count));
        }
    }

    private void LoadLanguages()
    {
        _loading = true;
        languageBox.Items.Clear();
        languageBox.Items.Add(new LanguageChoice("", Loc.Get("Settings_SystemDefault")));
        foreach (var language in Loc.GetAvailableLanguages())
            languageBox.Items.Add(new LanguageChoice(language.Locale, language.DisplayName));

        var current = AppSettings.Instance.UiLanguage ?? "";
        languageBox.SelectedItem = languageBox.Items.Cast<LanguageChoice>()
            .FirstOrDefault(item => item.Locale.Equals(current, StringComparison.OrdinalIgnoreCase));
        if (languageBox.SelectedIndex < 0) languageBox.SelectedIndex = 0;
        _loading = false;
    }

    private void LanguageBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_loading || !(languageBox.SelectedItem is LanguageChoice selected)) return;
        if (selected.Locale.Equals(AppSettings.Instance.UiLanguage ?? "", StringComparison.OrdinalIgnoreCase)) return;

        AppSettings.Instance.UiLanguage = selected.Locale;
        AppSettings.Instance.Save();
        if (MessageBox.Show(this, Loc.Get("Settings_LanguageRestartPrompt"), Loc.Get("Settings_LanguageRestartTitle"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        try
        {
            Process.Start(new ProcessStartInfo(Application.ExecutablePath)
            {
                WorkingDirectory = AppContext.BaseDirectory,
                UseShellExecute = true
            });
            FindForm()?.Close();
        }
        catch { }
    }

    private void OpenDataButton_Click(object? sender, EventArgs e)
    {
        Directory.CreateDirectory(AppPaths.DataFolder);
        OpenPath(AppPaths.DataFolder);
    }

    private void OpenLocalizationButton_Click(object? sender, EventArgs e)
    {
        Directory.CreateDirectory(Loc.LocalizationFolder);
        OpenPath(Loc.LocalizationFolder);
    }

    private static void OpenPath(string target)
    {
        try { Process.Start(new ProcessStartInfo(target) { UseShellExecute = true }); }
        catch { }
    }

    //one simple combo box item, no locale logic belongs in the ui
    private sealed class LanguageChoice
    {
        public LanguageChoice(string locale, string name) { Locale = locale; Name = name; }
        public string Locale { get; }
        public string Name { get; }
        public override string ToString() => Name;
    }
}
