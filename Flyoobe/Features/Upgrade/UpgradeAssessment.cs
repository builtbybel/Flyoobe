namespace Flyoobe3.Features.Upgrade;

//carries the read-only pc check from the upgrade service to the view
internal sealed class UpgradeAssessment
{
    public string WindowsName { get; set; } = "Windows";
    public int WindowsBuild { get; set; }
    public bool IsWindows10 { get; set; }
    public bool IsWindows11 { get; set; }
    public bool Is64Bit { get; set; }
    public double MemoryGB { get; set; }
    public double? FreeSpaceGB { get; set; }
    public bool? HasTpm20 { get; set; }
    public bool? SecureBootEnabled { get; set; }
    public string ProcessorName { get; set; } = "";
    public UpgradeSettings Settings { get; set; } = new UpgradeSettings();

    //unknown checks stay neutral, only known mismatches suggest Flyby11
    public bool HasKnownRequirementMismatch =>
        Settings.Require64Bit && !Is64Bit ||
        MemoryGB > 0 && MemoryGB < Settings.MinimumRamGB ||
        Settings.RequireTpm20 && HasTpm20 == false ||
        Settings.RequireSecureBoot && SecureBootEnabled == false ||
        FreeSpaceGB.HasValue && FreeSpaceGB.Value < Settings.RecommendedFreeSpaceGB;
}

//reads the harmless thresholds from Data\Upgrade.ini
internal sealed class UpgradeSettings
{
    public int MinimumRamGB { get; set; } = 4;
    public int RecommendedFreeSpaceGB { get; set; } = 25;
    public int MinimumMediaBuild { get; set; } = 22000;
    public bool Require64Bit { get; set; } = true;
    public bool RequireTpm20 { get; set; } = true;
    public bool RequireSecureBoot { get; set; } = true;
}
