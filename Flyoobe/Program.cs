namespace Flyoobe3;

using Flyoobe3.Services;

//starts the app, nothing clever belongs here
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Loc.Init(AppSettings.Instance.UiLanguage);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}
