using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Flyoobe3.Features.Upgrade;

//mounts a chosen Windows ISO, starts the correct Setup executable and unmounts it again on failure
//the isolated Flyby11 switch lives here so the complete upgrade path can be removed as one feature
internal sealed class IsoUpgradeService
{
    private readonly UpgradeSettings _settings;

    public IsoUpgradeService(UpgradeSettings settings) => _settings = settings;

    public async Task<string?> StartAsync(string isoPath, bool flybyMode, IProgress<string>? progress = null)
    {
        if (!File.Exists(isoPath) || !Path.GetExtension(isoPath).Equals(".iso", StringComparison.OrdinalIgnoreCase))
            return "Choose an existing .iso file.";

        progress?.Report("Mounting the Windows ISO...");
        var mount = await MountAsync(isoPath);
        if (mount.Error != null) return "The ISO could not be mounted: " + mount.Error;

        var rootSetup = Path.Combine(mount.Root!, "setup.exe");
        var flybySetup = Path.Combine(mount.Root!, "sources", "setupprep.exe");
        if (!File.Exists(rootSetup) || !File.Exists(flybySetup))
            return "The mounted image does not contain the expected Windows Setup files.";

        var build = ReadMediaBuild(rootSetup);
        if (build > 0 && build < _settings.MinimumMediaBuild)
            return $"The selected media reports build {build}. Choose a Windows 11 ISO.";

        var setup = flybyMode ? flybySetup : rootSetup;
        progress?.Report($"Starting Windows Setup from media build {(build > 0 ? build.ToString() : "?")}...");
        try
        {
            Process.Start(new ProcessStartInfo(setup, flybyMode ? "/Product Server" : "")
            {
                WorkingDirectory = Path.GetDirectoryName(setup),
                UseShellExecute = true,
                Verb = "runas"
            });
            return null;
        }
        catch (Win32Exception ex) when (ex.NativeErrorCode == 1223)
        {
            return "The administrator prompt was canceled.";
        }
        catch (Exception ex) { return ex.Message; }
    }

    private static async Task<(string? Root, string? Error)> MountAsync(string path)
    {
        var escaped = path.Replace("'", "''");
        var script = "$image=Mount-DiskImage -ImagePath '" + escaped +
                     "' -PassThru -ErrorAction Stop; " +
                     "Get-Volume -DiskImage $image | Where-Object DriveLetter | Select-Object -First 1 -ExpandProperty DriveLetter";
        var encoded = Convert.ToBase64String(Encoding.Unicode.GetBytes(script));
        var info = new ProcessStartInfo("powershell.exe", "-NoProfile -NonInteractive -EncodedCommand " + encoded)
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        try
        {
            using var process = Process.Start(info);
            if (process == null) return (null, "Windows PowerShell could not be started.");
            var outputTask = process.StandardOutput.ReadToEndAsync();
            var errorTask = process.StandardError.ReadToEndAsync();
            await Task.Run(() => process.WaitForExit());
            var output = await outputTask;
            var error = await errorTask;
            if (process.ExitCode != 0) return (null, Clean(error));

            var drive = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim())
                .LastOrDefault(line => Regex.IsMatch(line, "^[A-Za-z]$"));
            return drive == null ? (null, "Windows mounted the image without returning a drive letter.") : (drive + @":\", null);
        }
        catch (Exception ex) { return (null, ex.Message); }
    }

    private static int ReadMediaBuild(string setupPath)
    {
        try
        {
            var version = FileVersionInfo.GetVersionInfo(setupPath);
            if (version.FileBuildPart > 0) return version.FileBuildPart;
            var match = Regex.Match(version.ProductVersion ?? "", @"10\.0\.(\d+)");
            return match.Success ? int.Parse(match.Groups[1].Value) : 0;
        }
        catch { return 0; }
    }

    private static string Clean(string text)
    {
        var value = string.Join(" ", text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
        return value.Length == 0 ? "Unknown mount error" : value.Trim();
    }
}
