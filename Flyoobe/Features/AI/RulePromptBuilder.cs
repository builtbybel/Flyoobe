using Flyoobe3.Models;
using System.Text;

namespace Flyoobe3.Features.AI;

//turns one known SetupRule into the short technical prompt used by AiExplainer
//keeping prompt creation separate makes it obvious which local data leaves the app
internal static class RulePromptBuilder
{
    public static string Build(SetupRule rule)
    {
        var text = new StringBuilder();
        text.AppendLine($"Explain the Windows registry setting \"{rule.Name}\".");
        if (rule.Description.Length > 0) text.AppendLine("Database description: " + rule.Description);
        text.AppendLine("Registry changes:");
        foreach (var entry in rule.Entries)
        {
            text.AppendLine($"- {entry.Hive}\\{entry.Key}\\{entry.ValueName}");
            text.AppendLine($"  type={entry.ValueType}, recommended={entry.RecommendedValue}, Windows default={entry.DefaultValue}");
        }
        if (rule.RequiresAdmin) text.AppendLine("Administrator rights are required.");
        text.AppendLine("Explain what it changes, the practical benefit and possible trade-offs in 3-5 short sentences.");
        return text.ToString();
    }
}
