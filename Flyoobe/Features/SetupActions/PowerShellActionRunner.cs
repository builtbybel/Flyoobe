using Flyoobe3.Services;
using System.Diagnostics;
using System.Text;

namespace Flyoobe3.Features.SetupActions;

/// <summary>
/// Runs exactly one local action script and streams its output line by line.
/// Process handling stays here so neither the catalog nor the WinForms page needs PowerShell details.
/// </summary>
internal static class PowerShellActionRunner
{
    public static async Task<string?> RunAsync(SetupAction action,
        IProgress<string>? liveOutput = null)
    {
        using var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = BuildArguments(action),
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            }
        };

        var combinedOutput = new StringBuilder();
        var errors = new StringBuilder();
        var outputLock = new object();

        process.OutputDataReceived += (_, eventArgs) =>
            CaptureLine(eventArgs.Data, null, combinedOutput, outputLock, liveOutput);
        process.ErrorDataReceived += (_, eventArgs) =>
            CaptureLine(eventArgs.Data, errors, combinedOutput, outputLock, liveOutput);

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        await Task.Run(() => process.WaitForExit());

        lock (outputLock)
        {
            var allText = combinedOutput.ToString().Trim();
            if (process.ExitCode == 0) return null;

            var errorText = errors.ToString().Trim();
            if (errorText.Length == 0) errorText = allText;
            if (errorText.Length == 0) errorText = Loc.Format("Actions_ExitCode", process.ExitCode);
            return errorText;
        }
    }

    private static string BuildArguments(SetupAction action)
    {
        // -File is intentional: unlike -EncodedCommand it does not turn PowerShell progress into CLIXML.
        var arguments = "-NoLogo -NoProfile -NonInteractive -ExecutionPolicy Bypass -File " +
                        QuoteArgument(action.ScriptPath);
        if (action.Options.Count > 0)
            // Positional binding works with param($choice), param($Option), or any other first parameter name.
            arguments += " " + QuoteArgument(action.SelectedOption);
        return arguments;
    }

    private static void CaptureLine(string? line, StringBuilder? errorStream, StringBuilder combined,
        object outputLock, IProgress<string>? liveOutput)
    {
        if (line == null) return;
        lock (outputLock)
        {
            errorStream?.AppendLine(line);
            combined.AppendLine(line);
        }
        liveOutput?.Report(line);
    }

    private static string QuoteArgument(string value)
    {
        // Quote one Windows command-line argument without allowing spaces or quotes to start another one.
        var result = new StringBuilder("\"");
        var slashes = 0;
        foreach (var character in value)
        {
            if (character == '\\') { slashes++; continue; }
            if (character == '"') result.Append('\\', slashes * 2 + 1).Append('"');
            else result.Append('\\', slashes).Append(character);
            slashes = 0;
        }
        result.Append('\\', slashes * 2).Append('"');
        return result.ToString();
    }
}
