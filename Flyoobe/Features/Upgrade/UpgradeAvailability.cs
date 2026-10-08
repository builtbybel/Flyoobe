namespace Flyoobe3.Features.Upgrade;

//contains the single visibility gate for the isolated Windows 10 to 11 feature
//the test flag is here too, so no normal view needs to fake the current Windows version
internal static class UpgradeAvailability
{
    //set this to false before a public build
    public const bool Windows11TestMode = false;

    public static bool ShouldOffer
    {
        get
        {
            var version = Environment.OSVersion.Version;
            return (version.Major == 10 && version.Build < 22000) || Windows11TestMode;
        }
    }

    public static bool CanUseIso(UpgradeAssessment? assessment) =>
        assessment?.IsWindows10 == true || Windows11TestMode;
}
