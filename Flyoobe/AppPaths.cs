namespace Flyoobe3;

//I keep all loose file names here so views never have to guess where their data lives
internal static class AppPaths
{
    public static string DataFolder => Path.Combine(AppContext.BaseDirectory, "Data");
    public static string Rules => Path.Combine(DataFolder, "Flyoobe.ini");
    public static string Apps => Path.Combine(DataFolder, "Apps.ini");
    public static string Bloatware => Path.Combine(DataFolder, "Bloatware.ini");
    public static string Upgrade => Path.Combine(DataFolder, "Upgrade.ini");
    public static string ActionsFolder => Path.Combine(DataFolder, "Actions");

    //one tiny convention replaces a plugin system: Flyoobe*.ini means "load me too"
    public static IReadOnlyList<string> RuleDatabases()
    {
        var files = new List<string> { Rules };
        if (!Directory.Exists(DataFolder)) return files;

        files.AddRange(Directory.GetFiles(DataFolder, "*.ini")
            .Where(path => Path.GetFileName(path).StartsWith("Flyoobe", StringComparison.OrdinalIgnoreCase))
            .Where(path => !Path.GetFullPath(path).Equals(Path.GetFullPath(Rules), StringComparison.OrdinalIgnoreCase))
            .OrderBy(path => Path.GetFileName(path), StringComparer.OrdinalIgnoreCase));
        return files;
    }
}
