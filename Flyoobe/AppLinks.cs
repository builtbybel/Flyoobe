using System.Diagnostics;

namespace Flyoobe3;

//keeps every fixed project, donation, download and AI provider address out of the views
internal static class AppLinks
{
    public const string GitHub = "https://github.com/builtbybel/FlyOOBE";
    public const string Releases = GitHub + "/releases";
    public const string Issues = GitHub + "/issues";
    public const string Donation = "https://www.paypal.com/donate?hosted_button_id=MY7HX4QLYR4KG";
    public const string Windows11Download = "https://www.microsoft.com/software-download/windows11";

    public const string GroqKeys = "https://console.groq.com/keys";
    public const string OpenAiKeys = "https://platform.openai.com/api-keys";
    public const string AnthropicKeys = "https://console.anthropic.com/settings/keys";

    public const string GroqChat = "https://api.groq.com/openai/v1/chat/completions";
    public const string OpenAiChat = "https://api.openai.com/v1/chat/completions";
    public const string AnthropicMessages = "https://api.anthropic.com/v1/messages";
    public const string OpenRouterChat = "https://openrouter.ai/api/v1/chat/completions";

    public static bool Open(string url)
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) ||
            (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)) return false;

        try
        {
            Process.Start(new ProcessStartInfo(uri.AbsoluteUri) { UseShellExecute = true });
            return true;
        }
        catch { return false; }
    }
}
