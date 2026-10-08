using Flyoobe3.Services;

namespace Flyoobe3.Features.SetupActions;

/// <summary>
/// The one small entry point used by the rest of Flyoobe.
/// Loading, importing and PowerShell execution deliberately live in their own helpers below this facade.
/// </summary>
internal static class SetupActionService
{
    public static List<SetupAction> Load()
    {
        if (!AppSettings.Instance.SetupActionsEnabled) return new List<SetupAction>();
        return SetupActionCatalog.Load(AppPaths.ActionsFolder);
    }

    public static SetupAction Import(string selectedFile) =>
        SetupActionImporter.Import(selectedFile, AppPaths.ActionsFolder);

    public static async Task<string?> RunAsync(IEnumerable<SetupAction> actions, SetupActionPhase? phase,
        IProgress<string> progress, IProgress<string>? outputProgress = null)
    {
        var pending = actions.Where(action => phase == null || action.Phase == phase).ToList();
        if (pending.Count == 0) return null;
        if (!AppSettings.Instance.SetupActionsEnabled) return Loc.Get("Actions_DisabledError");

        foreach (var action in pending)
        {
            if (action.RequiresAdmin && !WindowsActions.IsAdministrator())
                return Loc.Format("Common_AdminRequired", action.Name);

            progress.Report(Loc.Format("Actions_Running", action.Name));
            var error = await PowerShellActionRunner.RunAsync(action, outputProgress);
            if (error != null)
                return Loc.Format("Actions_RunFailed", action.Name, error);
            //only a finished run is logged, and with the chosen option because that is what ran
            ChangeLog.Add("Action", action.Id, action.Options.Count > 0 ? action.SelectedOption : "ran");
        }

        return null;
    }
}
