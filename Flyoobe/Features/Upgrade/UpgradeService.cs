using Flyoobe3.Services;
using Microsoft.Win32;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;

namespace Flyoobe3.Features.Upgrade;

//collects the read-only Windows 11 upgrade assessment shown on the upgrade page
//it checks hardware and free space, but Windows Setup still makes the final compatibility decision
internal sealed class UpgradeService
{
    public UpgradeSettings Settings { get; } = LoadSettings();

    public UpgradeAssessment Assess()
    {
        //Windows Setup still makes the final call, this only picks a sensible route
        var version = Environment.OSVersion.Version;
        return new UpgradeAssessment
        {
            WindowsName = version.Major == 10 && version.Build >= 22000 ? "Windows 11"
                : version.Major == 10 ? "Windows 10" : "Windows",
            WindowsBuild = version.Build,
            IsWindows10 = version.Major == 10 && version.Build < 22000,
            IsWindows11 = version.Major == 10 && version.Build >= 22000,
            Is64Bit = Environment.Is64BitOperatingSystem,
            MemoryGB = ReadMemoryGB(),
            FreeSpaceGB = ReadFreeSpaceGB(),
            HasTpm20 = ReadTpm20(),
            SecureBootEnabled = ReadSecureBoot(),
            ProcessorName = ReadProcessorName(),
            Settings = Settings
        };
    }

    public void OpenWindowsUpdate() => Open("ms-settings:windowsupdate-action");

    public void OpenOfficialDownload() => AppLinks.Open(AppLinks.Windows11Download);

    private static UpgradeSettings LoadSettings()
    {
        var settings = new UpgradeSettings();
        var section = IniFile.Read(AppPaths.Upgrade)
            .FirstOrDefault(item => item.Name.Equals("Windows11", StringComparison.OrdinalIgnoreCase));
        if (section == null) return settings;

        settings.MinimumRamGB = ReadInt(section.Get("MinimumRamGB"), settings.MinimumRamGB);
        settings.RecommendedFreeSpaceGB = ReadInt(section.Get("RecommendedFreeSpaceGB"), settings.RecommendedFreeSpaceGB);
        settings.MinimumMediaBuild = ReadInt(section.Get("MinimumMediaBuild"), settings.MinimumMediaBuild);
        settings.Require64Bit = ReadBool(section.Get("Require64Bit"), settings.Require64Bit);
        settings.RequireTpm20 = ReadBool(section.Get("RequireTpm20"), settings.RequireTpm20);
        settings.RequireSecureBoot = ReadBool(section.Get("RequireSecureBoot"), settings.RequireSecureBoot);
        return settings;
    }

    private static int ReadInt(string value, int fallback) =>
        int.TryParse(value, out var parsed) && parsed > 0 ? parsed : fallback;

    private static bool ReadBool(string value, bool fallback) =>
        bool.TryParse(value, out var parsed) ? parsed : fallback;

    private static double ReadMemoryGB()
    {
        var status = new MemoryStatus { Length = (uint)Marshal.SizeOf(typeof(MemoryStatus)) };
        return GlobalMemoryStatusEx(ref status) ? status.TotalPhysical / 1024d / 1024d / 1024d : 0;
    }

    private static double? ReadFreeSpaceGB()
    {
        try
        {
            var root = Path.GetPathRoot(Environment.SystemDirectory);
            return root == null ? null : new DriveInfo(root).AvailableFreeSpace / 1024d / 1024d / 1024d;
        }
        catch { return null; }
    }

    private static bool? ReadTpm20()
    {
        try
        {
            using var searcher = new ManagementObjectSearcher(
                @"root\CIMV2\Security\MicrosoftTpm", "SELECT SpecVersion FROM Win32_Tpm");
            using var results = searcher.Get();
            foreach (ManagementObject item in results)
            {
                var version = item["SpecVersion"]?.ToString() ?? "";
                return version.Split(',').Any(part => part.Trim().StartsWith("2.0", StringComparison.OrdinalIgnoreCase));
            }
            return false;
        }
        catch { return null; }
    }

    private static bool? ReadSecureBoot()
    {
        try
        {
            using var key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\SecureBoot\State");
            var value = key?.GetValue("UEFISecureBootEnabled");
            return value == null ? (bool?)null : Convert.ToInt32(value) == 1;
        }
        catch { return null; }
    }

    private static string ReadProcessorName()
    {
        try
        {
            using var key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");
            return key?.GetValue("ProcessorNameString")?.ToString()?.Trim() ?? "";
        }
        catch { return ""; }
    }

    private static void Open(string target) =>
        Process.Start(new ProcessStartInfo(target) { UseShellExecute = true });

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    //all fields belong to the native structure even if Flyoobe only reads the total ram
    private struct MemoryStatus
    {
        public uint Length;
        public uint MemoryLoad;
        public ulong TotalPhysical;
        public ulong AvailablePhysical;
        public ulong TotalPageFile;
        public ulong AvailablePageFile;
        public ulong TotalVirtual;
        public ulong AvailableVirtual;
        public ulong AvailableExtendedVirtual;
    }

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GlobalMemoryStatusEx(ref MemoryStatus status);
}
