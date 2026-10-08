using Flyoobe3.Services;

namespace Flyoobe3.Features.SetupActions;

/// <summary>
/// Copies a selected action into Flyoobe's Actions folder.
/// Keeping file changes here makes the read-only catalog much easier to understand.
/// </summary>
internal static class SetupActionImporter
{
    public static SetupAction Import(string selectedFile, string actionsFolder)
    {
        Directory.CreateDirectory(actionsFolder);

        if (Path.GetExtension(selectedFile).Equals(".ps1", StringComparison.OrdinalIgnoreCase))
            return ImportLooseScript(selectedFile, actionsFolder);

        return ImportPackage(selectedFile, actionsFolder);
    }

    private static SetupAction ImportLooseScript(string source, string actionsFolder)
    {
        var target = Path.Combine(actionsFolder, Path.GetFileName(source));
        if (File.Exists(target))
            throw new IOException(Loc.Format("Actions_ScriptAlreadyInstalled", Path.GetFileName(source)));

        File.Copy(source, target, false);
        return SetupActionCatalog.ReadLooseScript(target) ??
               throw new InvalidDataException(Loc.Get("Actions_InvalidScript"));
    }

    private static SetupAction ImportPackage(string manifestPath, string actionsFolder)
    {
        var sourceFolder = Path.GetDirectoryName(Path.GetFullPath(manifestPath))!;
        var action = SetupActionCatalog.ReadPackage(sourceFolder) ??
                     throw new InvalidDataException(Loc.Get("Actions_InvalidPackage"));
        var targetFolder = Path.Combine(actionsFolder, action.Id);
        if (Directory.Exists(targetFolder))
            throw new IOException(Loc.Format("Actions_AlreadyInstalled", action.Id));

        Directory.CreateDirectory(targetFolder);
        CopyFolder(sourceFolder, targetFolder);
        return SetupActionCatalog.ReadPackage(targetFolder) ??
               throw new InvalidDataException(Loc.Get("Actions_InvalidPackage"));
    }

    private static void CopyFolder(string source, string target)
    {
        foreach (var directory in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
            Directory.CreateDirectory(Path.Combine(target, directory.Substring(source.Length).TrimStart('\\')));
        foreach (var file in Directory.GetFiles(source, "*", SearchOption.AllDirectories))
        {
            var relative = file.Substring(source.Length).TrimStart('\\');
            File.Copy(file, Path.Combine(target, relative), false);
        }
    }
}
