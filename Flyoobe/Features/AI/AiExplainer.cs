using Flyoobe3.Models;
using Flyoobe3.Services;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Flyoobe3.Features.AI;

//sends one prepared explanation request to the selected AI provider and caches the reply
//this feature is read-only: it never scans, applies or restores a Windows setting
internal static class AiExplainer
{
    private static readonly HttpClient Client = new() { Timeout = TimeSpan.FromSeconds(45) };
    private static readonly Dictionary<string, string> Cache = new(StringComparer.OrdinalIgnoreCase);

    private static (string Endpoint, string Model) ProviderInfo(
        string provider, string? customEndpoint = null, string? customModel = null) => provider switch
    {
        "OpenAI" => (AppLinks.OpenAiChat, "gpt-4o-mini"),
        "Anthropic" => (AppLinks.AnthropicMessages, "claude-haiku-4-5-20251001"),
        "OpenAI-compatible" => (customEndpoint ?? AppSettings.Instance.OpenAiCompatibleEndpoint,
            customModel ?? AppSettings.Instance.OpenAiCompatibleModel),
        _ => (AppLinks.GroqChat, "openai/gpt-oss-120b")
    };

    private static string? ApiKey(string provider) => provider switch
    {
        "OpenAI" => AppSettings.Instance.OpenAiApiKey ?? Environment.GetEnvironmentVariable("OPENAI_API_KEY"),
        "Anthropic" => AppSettings.Instance.AnthropicApiKey ?? Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY"),
        "OpenAI-compatible" => AppSettings.Instance.OpenAiCompatibleApiKey
            ?? Environment.GetEnvironmentVariable("OPENROUTER_API_KEY")
            ?? Environment.GetEnvironmentVariable("OPENAI_API_KEY"),
        _ => AppSettings.Instance.GroqApiKey ?? Environment.GetEnvironmentVariable("GROQ_API_KEY")
    };

    public static async Task<string> ExplainAsync(SetupRule rule)
    {
        var provider = AppSettings.Instance.AiProvider;
        var (endpoint, model) = ProviderInfo(provider);
        var prompt = RulePromptBuilder.Build(rule);
        var cacheKey = provider + "\n" + endpoint + "\n" + model + "\n" + Loc.CurrentLocale + "\n" + prompt;
        if (Cache.TryGetValue(cacheKey, out var cached)) return cached;

        var apiKey = ApiKey(provider);
        if (string.IsNullOrWhiteSpace(apiKey)) return Loc.Format("Ai_NoApiKey", provider);
        var system = "You are a careful Windows registry expert. Explain the supplied setting accurately and plainly. " +
                     "Do not invent effects and do not provide unrelated commands." + LanguageInstruction();
        var (answer, error) = await SendChatAsync(provider, apiKey!, system, prompt, 450);
        if (error != null) return Loc.Format("Ai_ApiError", provider, error);
        answer = answer!.Replace("**", "");
        Cache[cacheKey] = answer;
        return answer;
    }

    public static async Task<string> TestKeyAsync(
        string apiKey, string provider, string? customEndpoint = null, string? customModel = null)
    {
        var prompt = "Reply with one short sentence confirming that the Flyoobe AI connection works." + LanguageInstruction();
        var (answer, error) = await SendChatAsync(provider, apiKey, null, prompt, 100, customEndpoint, customModel);
        return error != null ? "✗ " + error : "✓ " + answer;
    }

    private static async Task<(string? Answer, string? Error)> SendChatAsync(
        string provider, string apiKey, string? systemPrompt, string prompt, int maxTokens,
        string? customEndpoint = null, string? customModel = null)
    {
        var (baseUrl, model) = ProviderInfo(provider, customEndpoint, customModel);
        if (string.IsNullOrWhiteSpace(model)) return (null, Loc.Get("Ai_ModelRequired"));
        if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var endpoint) ||
            (endpoint.Scheme != Uri.UriSchemeHttp && endpoint.Scheme != Uri.UriSchemeHttps))
            return (null, Loc.Get("Ai_InvalidEndpoint"));
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            object body;
            if (provider == "Anthropic")
            {
                request.Headers.Add("x-api-key", apiKey);
                request.Headers.Add("anthropic-version", "2023-06-01");
                var messages = new[] { new { role = "user", content = prompt } };
                body = systemPrompt == null
                    ? new { model, max_tokens = maxTokens, messages }
                    : new { model, max_tokens = maxTokens, system = systemPrompt, messages };
            }
            else
            {
                request.Headers.Add("Authorization", "Bearer " + apiKey);
                var messages = systemPrompt == null
                    ? new[] { new { role = "user", content = prompt } }
                    : new[] { new { role = "system", content = systemPrompt }, new { role = "user", content = prompt } };
                body = provider == "Groq"
                    ? new { model, max_completion_tokens = maxTokens, reasoning_effort = "low", reasoning_format = "hidden", messages }
                    : (object)new { model, max_tokens = maxTokens, messages };
            }

            request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            using var response = await Client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            using var document = JsonDocument.Parse(json);
            var root = document.RootElement;
            if (root.TryGetProperty("error", out var apiError))
            {
                var message = apiError.ValueKind == JsonValueKind.Object && apiError.TryGetProperty("message", out var detail)
                    ? detail.GetString() : apiError.GetString();
                return (null, message ?? Loc.Get("Ai_UnknownError"));
            }

            var text = provider == "Anthropic"
                ? root.GetProperty("content")[0].GetProperty("text").GetString()
                : root.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
            return string.IsNullOrWhiteSpace(text) ? (null, Loc.Get("Ai_NoResponse")) : (text, null);
        }
        catch (Exception ex) { return (null, Loc.Format("Ai_NetworkError", provider, ex.Message)); }
    }

    private static string LanguageInstruction()
    {
        if (Loc.CurrentLocale.StartsWith("en", StringComparison.OrdinalIgnoreCase)) return "";
        try { return " Please respond in " + CultureInfo.GetCultureInfo(Loc.CurrentLocale).EnglishName + "."; }
        catch { return ""; }
    }
}
