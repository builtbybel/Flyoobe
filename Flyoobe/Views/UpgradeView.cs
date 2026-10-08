using Flyoobe3.Features.Upgrade;
using Flyoobe3.Services;
using System.Globalization;

namespace Flyoobe3.Views;

//gives the isolated Flyby11 engine one small native Flyoobe page
internal partial class UpgradeView : UserControl, INavigationGuard
{
    private const string Title = "Windows 11 upgrade";
    private const string SelectCheck = "Select a check to see why it matters.";
    private readonly UpgradeService _upgrade;
    private readonly IsoUpgradeService _isoUpgrade;
    private UpgradeAssessment? _assessment;
    private bool _loaded;
    public bool CanNavigateAway { get; private set; } = true;

    public UpgradeView() : this(new UpgradeService()) { }

    internal UpgradeView(UpgradeService upgrade)
    {
        _upgrade = upgrade;
        _isoUpgrade = new IsoUpgradeService(upgrade.Settings);
        InitializeComponent();
        ApplyText();
    }

    //the upgrade add-on stays English and independent from Flyoobe localization
    private void ApplyText()
    {
        titleLabel.Text = Title;
        introLabel.Text = "Check this PC, then choose the official or isolated Flyby11 ISO path. Nothing starts without confirmation.";
        checksList.Columns[0].Text = "Check";
        checksList.Columns[1].Text = "Status";
        checksList.Columns[2].Text = "Current / details";
        checkButton.Text = "Check again";
        windowsUpdateButton.Text = "Open Windows Update";
        downloadButton.Text = "Download Windows 11";
        isoButton.Text = "Use ISO ▾";
        standardIsoMenuItem.Text = "Standard Windows Setup...";
        flybyIsoMenuItem.Text = "Flyby11 compatibility path...";
        detailsBox.Text = SelectCheck;
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
        if (_loaded) return;
        _loaded = true;
        await CheckAsync();
    }

    private async Task CheckAsync()
    {
        SetBusy(true, "Checking the Windows 11 upgrade basics...");
        _assessment = await Task.Run(() => _upgrade.Assess());
        FillRows(_assessment);
        SetBusy(false, SummaryFor(_assessment));
        progress.Value = 100;
        isoButton.Enabled = UpgradeAvailability.CanUseIso(_assessment);
    }

    private void FillRows(UpgradeAssessment result)
    {
        checksList.BeginUpdate();
        checksList.Items.Clear();
        AddCheck("windows", "Windows version",
            result.IsWindows10 || result.IsWindows11 ? CheckTone.Pass : CheckTone.Review,
            $"{result.WindowsName} · build {result.WindowsBuild}");
        AddCheck("architecture", "Architecture",
            !result.Settings.Require64Bit || result.Is64Bit ? CheckTone.Pass : CheckTone.Review,
            result.Is64Bit ? "64-bit" : "32-bit");
        AddCheck("memory", "Memory",
            result.MemoryGB <= 0 ? CheckTone.Unknown
            : result.MemoryGB >= result.Settings.MinimumRamGB ? CheckTone.Pass : CheckTone.Review,
            result.MemoryGB <= 0 ? "Could not be verified" : FormatGB(result.MemoryGB));
        AddCheck("tpm", "TPM 2.0", ToneFor(result.HasTpm20, result.Settings.RequireTpm20),
            ValueFor(result.HasTpm20));
        AddCheck("secureboot", "Secure Boot",
            ToneFor(result.SecureBootEnabled, result.Settings.RequireSecureBoot), ValueFor(result.SecureBootEnabled));
        AddCheck("space", "Free system space",
            !result.FreeSpaceGB.HasValue ? CheckTone.Unknown
            : result.FreeSpaceGB.Value >= result.Settings.RecommendedFreeSpaceGB ? CheckTone.Pass : CheckTone.Review,
            result.FreeSpaceGB.HasValue ? FormatGB(result.FreeSpaceGB.Value) : "Could not be verified");
        AddCheck("processor", "Processor", CheckTone.Info,
            result.ProcessorName.Length == 0 ? "Could not be verified" : result.ProcessorName);
        checksList.EndUpdate();
    }

    private void AddCheck(string id, string name, CheckTone tone, string value)
    {
        var row = new ListViewItem(name) { Tag = id };
        row.SubItems.Add(tone switch
        {
            CheckTone.Pass => "Ready",
            CheckTone.Review => "Review",
            CheckTone.Unknown => "Unknown",
            _ => "Info"
        });
        row.SubItems.Add(value);
        row.ForeColor = tone == CheckTone.Review ? Color.Firebrick
            : tone == CheckTone.Pass ? SystemColors.GrayText : SystemColors.WindowText;
        checksList.Items.Add(row);
    }

    private static CheckTone ToneFor(bool? value, bool required) => !required ? CheckTone.Info
        : !value.HasValue ? CheckTone.Unknown : value.Value ? CheckTone.Pass : CheckTone.Review;

    private static string ValueFor(bool? value) => !value.HasValue ? "Could not be verified"
        : value.Value ? "Available" : "Not available";

    private static string FormatGB(double value) =>
        value.ToString("N1", CultureInfo.InvariantCulture) + " GB";

    private static string SummaryFor(UpgradeAssessment result)
    {
        if (result.IsWindows11) return "This PC is already running Windows 11.";
        if (!result.IsWindows10) return "The native upgrade mode is intended for Windows 10 PCs.";
        return result.HasKnownRequirementMismatch
            ? "One or more core requirements differ. Review them first; the isolated Flyby11 ISO path is available."
            : "The checked core requirements look good. Try Windows Update first; Windows makes the final compatibility decision.";
    }

    private void ChecksList_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (checksList.SelectedItems.Count == 0)
        {
            detailsBox.Text = SelectCheck;
            return;
        }

        detailsBox.Text = checksList.SelectedItems[0].Tag as string switch
        {
            "windows" => "This page is intended for Windows 10. Windows 11 systems do not need the Flyby11 path.",
            "architecture" => "Windows 11 installation media requires a 64-bit processor. Flyoobe only reports the detected operating-system architecture.",
            "memory" => "The minimum comes from Data\\Upgrade.ini and can be updated without rebuilding Flyoobe.",
            "tpm" => "TPM is checked read-only through Windows Management Instrumentation. An unknown result is not treated as a failure.",
            "secureboot" => "Flyoobe reads the Secure Boot state from Windows. It does not change firmware settings.",
            "space" => "This is free space on the Windows drive. Upgrade.ini provides practical setup headroom, not a promise from Windows Setup.",
            "processor" => "The processor name is informational. Windows Update or Setup makes the final compatibility decision.",
            _ => SelectCheck
        };
    }

    private async void CheckButton_Click(object? sender, EventArgs e) => await CheckAsync();
    private void WindowsUpdateButton_Click(object? sender, EventArgs e) => _upgrade.OpenWindowsUpdate();
    private void DownloadButton_Click(object? sender, EventArgs e) => _upgrade.OpenOfficialDownload();

    private void IsoButton_Click(object? sender, EventArgs e) =>
        isoMenu.Show(isoButton, new Point(0, isoButton.Height));

    private async void StandardIsoMenuItem_Click(object? sender, EventArgs e) =>
        await SelectAndStartAsync(false);

    private async void FlybyIsoMenuItem_Click(object? sender, EventArgs e) =>
        await SelectAndStartAsync(true);

    private async Task SelectAndStartAsync(bool flybyMode)
    {
        if (!UpgradeAvailability.CanUseIso(_assessment))
        {
            MessageBox.Show(this, "The ISO upgrade page is only enabled while Flyoobe is running on Windows 10.", Title,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new OpenFileDialog { Filter = "Windows ISO (*.iso)|*.iso" };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        var question = flybyMode
            ? "Use the Flyby11 compatibility path with this ISO?\n\nThis route is intended for unsupported PCs. Microsoft does not support installations that fail its requirements. Back up important files first. Nothing is installed until you continue in Windows Setup."
            : "Start standard Windows Setup from this ISO?\n\nBack up important files first. Nothing is installed until you continue in Windows Setup.";
        if (MessageBox.Show(this, question, Title, MessageBoxButtons.YesNo,
                flybyMode ? MessageBoxIcon.Warning : MessageBoxIcon.Question) != DialogResult.Yes) return;

        SetBusy(true, "Preparing the selected ISO...");
        var report = new Progress<string>(text => summaryLabel.Text = text);
        var error = await _isoUpgrade.StartAsync(dialog.FileName, flybyMode, report);
        SetBusy(false, error == null
            ? flybyMode ? "The isolated Flyby11 path was started. Continue in Windows Setup."
                : "Standard Windows Setup was started. Continue in Windows Setup."
            : "Windows Setup was not started: " + error);
        if (error != null)
            MessageBox.Show(this, error, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void SetBusy(bool busy, string status)
    {
        CanNavigateAway = !busy;
        checkButton.Enabled = !busy;
        windowsUpdateButton.Enabled = !busy;
        downloadButton.Enabled = !busy;
        isoButton.Enabled = !busy && UpgradeAvailability.CanUseIso(_assessment);
        checksList.Enabled = !busy;
        summaryLabel.Text = status;
        progress.Style = busy ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
    }

    private enum CheckTone { Info, Pass, Review, Unknown }
}
