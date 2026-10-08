using System.Reflection;

namespace Flyoobe3;

//reads Flyoobe's display version from the assembly so every view shows the same identity
internal static class AppInfo
{
    //a product name is never translated, so it lives here and not in the language files
    public const string Name = "Flyoobe";

    //keep the same digits used by release tags, .NET drops leading zeroes
    public static string DisplayVersion
    {
        get
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return version == null ? "0.00.00" : $"{version.Major}.{version.Minor:D2}.{version.Build:D2}";
        }
    }
}
