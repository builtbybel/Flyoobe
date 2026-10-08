namespace Flyoobe3.Features.SetupActions;

/// <summary>
/// The plain data read from action.ini and run.ps1. This class deliberately contains no file or process code.
/// Recipes remember an action id and optional choice; they never embed PowerShell code.
/// </summary>
internal sealed class SetupAction
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Version { get; set; } = "";
    public string Author { get; set; } = "";
    public string ScriptPath { get; set; } = "";
    public SetupActionPhase Phase { get; set; }
    public bool RequiresAdmin { get; set; }
    public bool RecipeAllowed { get; set; }
    public bool Selected { get; set; }
    public List<string> Options { get; } = new List<string>();
    public string SelectedOption { get; set; } = "";
    public string Warning { get; set; } = "";
}

internal enum SetupActionPhase
{
    Prepare,
    Finish,
    Utility
}
