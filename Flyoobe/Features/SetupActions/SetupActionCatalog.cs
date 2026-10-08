using Flyoobe3.Services;
using System.Text.RegularExpressions;

namespace Flyoobe3.Features.SetupActions;

/// <summary>
/// Finds action packages and turns their small INI/script headers into SetupAction objects.
/// Nothing is copied or executed here; this class only reads the catalog.
/// </summary>
internal static class SetupActionCatalog
{
    private static readonly Regex ValidId = new Regex("^[a-z0-9][a-z0-9._-]*$", RegexOptions.IgnoreCase);

    public static List<SetupAction> Load(string actionsFolder)
    {
        var actions = new List<SetupAction>();
        if (!Directory.Exists(actionsFolder)) return actions;

        // A proper package is one folder containing action.ini and its PowerShell script.
        foreach (var folder in Directory.GetDirectories(actionsFolder).OrderBy(Path.GetFileName))
            AddIfUnique(actions, ReadPackage(folder));

        // Simple mode: a single imported .ps1 can be used without building a package first.
        foreach (var script in Directory.GetFiles(actionsFolder, "*.ps1").OrderBy(Path.GetFileName))
            AddIfUnique(actions, ReadLooseScript(script));

        return actions;
    }

    public static SetupAction? ReadPackage(string folder)
    {
        try
        {
            var manifest = Path.Combine(folder, "action.ini");
            var section = IniFile.Read(manifest).FirstOrDefault();
            if (section == null) return null;

            var id = section.Get("Id").Trim();
            var name = section.Get("Name").Trim();
            var scriptName = section.Get("Script").Trim();
            if (!ValidId.IsMatch(id) || name.Length == 0 || scriptName.Length == 0) return null;

            // A manifest must never escape its own package folder or point to anything but a .ps1 file.
            var folderPath = Path.GetFullPath(folder).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            var scriptPath = Path.GetFullPath(Path.Combine(folder, scriptName));
            if (!scriptPath.StartsWith(folderPath, StringComparison.OrdinalIgnoreCase) ||
                !scriptPath.EndsWith(".ps1", StringComparison.OrdinalIgnoreCase) || !File.Exists(scriptPath)) return null;

            if (!Enum.TryParse(section.Get("Phase"), true, out SetupActionPhase phase)) return null;
            var action = new SetupAction
            {
                Id = id,
                Name = section.Get("Name." + Loc.CurrentLocale, name),
                Description = section.Get("Description." + Loc.CurrentLocale, section.Get("Description")),
                Version = section.Get("Version", "1.0"),
                Author = section.Get("Author"),
                ScriptPath = scriptPath,
                Phase = phase,
                RequiresAdmin = IsTrue(section.Get("RequiresAdmin")),
                RecipeAllowed = IsTrue(section.Get("RecipeAllowed")) && phase != SetupActionPhase.Utility,
                Warning = section.Get("Warning." + Loc.CurrentLocale, section.Get("Warning"))
            };

            ApplyScriptOptions(action, ReadHeaders(File.ReadAllText(scriptPath)));
            return action;
        }
        catch
        {
            // A broken third-party package is skipped; it must not prevent Flyoobe from starting.
            return null;
        }
    }

    public static SetupAction? ReadLooseScript(string path)
    {
        try
        {
            var text = File.ReadAllText(path);
            var headers = ReadHeaders(text);
            var name = Path.GetFileNameWithoutExtension(path);
            var id = Slug(Value(headers, "Id", name));
            if (id.Length == 0) return null;

            var action = new SetupAction
            {
                Id = id,
                Name = name,
                Description = Value(headers, "Description", name),
                Version = Value(headers, "Version", "script"),
                Author = Value(headers, "Author", "Local script"),
                ScriptPath = Path.GetFullPath(path),
                Phase = ReadPhase(Value(headers, "Phase", "Utility")),
                RequiresAdmin = IsTrue(Value(headers, "RequiresAdmin", "false")),
                Warning = Value(headers, "Warning", "")
            };

            ApplyScriptOptions(action, headers);
            action.RecipeAllowed = IsTrue(Value(headers, "RecipeAllowed", "false")) &&
                                   action.Phase != SetupActionPhase.Utility;
            return action;
        }
        catch
        {
            return null;
        }
    }

    private static void AddIfUnique(List<SetupAction> actions, SetupAction? action)
    {
        if (action == null || actions.Any(item => item.Id.Equals(action.Id, StringComparison.OrdinalIgnoreCase))) return;
        actions.Add(action);
    }

    private static Dictionary<string, string> ReadHeaders(string text)
    {
        var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        using var reader = new StringReader(text);
        for (var lineNumber = 0; lineNumber < 40; lineNumber++)
        {
            var line = reader.ReadLine();
            if (line == null) break;
            var match = Regex.Match(line, @"^\s*#\s*([^:]+):\s*(.*)$");
            if (match.Success) headers[match.Groups[1].Value.Trim()] = match.Groups[2].Value.Trim();
        }
        return headers;
    }

    private static void ApplyScriptOptions(SetupAction action, Dictionary<string, string> headers)
    {
        // These header lines are what create the native dropdown dynamically:
        // # Options: First choice; Second choice
        foreach (var option in Value(headers, "Options", "").Split(';')
                     .Select(item => item.Trim()).Where(item => item.Length > 0))
            action.Options.Add(option);
        if (action.Options.Count > 0) action.SelectedOption = action.Options[0];
    }

    private static string Value(Dictionary<string, string> values, string key, string fallback) =>
        values.TryGetValue(key, out var value) && value.Length > 0 ? value : fallback;

    private static string Slug(string value)
    {
        var slug = Regex.Replace(value.Trim().ToLowerInvariant(), @"[^a-z0-9._-]+", "-").Trim('-');
        return ValidId.IsMatch(slug) ? slug : "";
    }

    private static SetupActionPhase ReadPhase(string value) =>
        Enum.TryParse(value, true, out SetupActionPhase phase) ? phase : SetupActionPhase.Utility;

    private static bool IsTrue(string value) =>
        value.Equals("true", StringComparison.OrdinalIgnoreCase) || value == "1";
}
