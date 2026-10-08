# Setup Actions in the codebase

I keep the complete optional Setup Actions feature in this folder. The rest of Flyoobe only talks to `SetupActionService`; package parsing, imports, and PowerShell details stay in here.

The public guide for users and action authors lives in [`docs/setup-actions.md`](../../docs/setup-actions.md). If I change the format, that guide should change with the code.

## What belongs where

| File | Job |
|---|---|
| `SetupActionService.cs` | Small entry point for loading, importing, and running actions |
| `SetupActionCatalog.cs` | Reads and validates packages and single scripts; builds option lists |
| `SetupActionImporter.cs` | Copies a package or a single `.ps1` into the Actions folder |
| `PowerShellActionRunner.cs` | Runs exactly one script and streams stdout/stderr |
| `SetupAction.cs` | Plain data model with no file or process work |
| `SetupActionsView.cs` | Native WinForms page |

## The two formats

A proper package looks like this:

```text
Data/Actions/my-action/
|- action.ini
`- run.ps1
```

This is what I use for built-in, translated, or recipe-safe actions. `action.ini` owns the visible metadata. `run.ps1` owns the actual work and may add a `# Options:` header.

A single imported `.ps1` directly under `Data/Actions` is the quick script mode. Its file name becomes the visible name. The catalog reads optional metadata from the first 40 comment lines.

## Intentionally small

The new core supports one dynamic UI field:

```powershell
# Options: First choice; Second choice
```

The selected value is passed as the first positional PowerShell argument. There are no host modes, text input fields, categories, or `(console)` / `(silent)` suffixes.

`Prepare` actions run before the other recipe work. `Finish` actions run afterwards. `Utility` actions are always manual. An action also needs `RecipeAllowed=true` before the recipe code will accept it. Recipes store only the action ID and option value, never script code.

## The error contract

The runner trusts the PowerShell process exit code. A script must return a non-zero code on failure. The clearest pattern is `$ErrorActionPreference = 'Stop'`, a small `try/catch`, and `exit 1` in the catch block.

Both stdout and stderr are streamed to the view while the action is running.
