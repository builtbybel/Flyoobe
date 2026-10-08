using Flyoobe3.Features.AI;
using Flyoobe3.Services;

namespace Flyoobe3.Views.Settings;

//owns the optional ai provider fields and saves them when its page is left
internal partial class AiSettingsView : UserControl
{
    private bool _loading;
    private string _groqKey = "";
    private string _openAiKey = "";
    private string _anthropicKey = "";
    private string _compatibleKey = "";
    private string _compatibleEndpoint = "";
    private string _compatibleModel = "";
    private string _currentProvider = "Groq";

    public AiSettingsView()
    {
        InitializeComponent();
        ApplyLocalization();
        LoadSettings();
    }

    private void ApplyLocalization()
    {
        aiDescriptionLabel.Text = Loc.Get("Ai_Description");
        providerLabel.Text = Loc.Get("Ai_Provider");
        endpointLabel.Text = Loc.Get("Ai_Endpoint");
        modelLabel.Text = Loc.Get("Ai_Model");
        testButton.Text = Loc.Get("Ai_Test");
    }

    private void LoadSettings()
    {
        _loading = true;
        try
        {
            var settings = AppSettings.Instance;
            _groqKey = settings.GroqApiKey ?? "";
            _openAiKey = settings.OpenAiApiKey ?? "";
            _anthropicKey = settings.AnthropicApiKey ?? "";
            _compatibleKey = settings.OpenAiCompatibleApiKey ?? "";
            _compatibleEndpoint = settings.OpenAiCompatibleEndpoint;
            _compatibleModel = settings.OpenAiCompatibleModel;
            _currentProvider = settings.AiProvider is "OpenAI" or "Anthropic" or "OpenAI-compatible"
                ? settings.AiProvider : "Groq";
            providerBox.SelectedItem = _currentProvider;
            ApplyProviderToUi();
        }
        finally { _loading = false; }
    }

    public void Save()
    {
        KeepCurrentProviderValues();
        var settings = AppSettings.Instance;
        settings.AiProvider = _currentProvider;
        settings.GroqApiKey = EmptyToNull(_groqKey);
        settings.OpenAiApiKey = EmptyToNull(_openAiKey);
        settings.AnthropicApiKey = EmptyToNull(_anthropicKey);
        settings.OpenAiCompatibleApiKey = EmptyToNull(_compatibleKey);
        settings.OpenAiCompatibleEndpoint = _compatibleEndpoint;
        settings.OpenAiCompatibleModel = _compatibleModel;
        settings.Save();
    }

    private void ProviderBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_loading) return;
        KeepCurrentProviderValues();
        _currentProvider = providerBox.SelectedItem as string ?? "Groq";
        ApplyProviderToUi();
    }

    private void KeepCurrentProviderValues()
    {
        switch (_currentProvider)
        {
            case "OpenAI": _openAiKey = apiKeyBox.Text.Trim(); break;
            case "Anthropic": _anthropicKey = apiKeyBox.Text.Trim(); break;
            case "OpenAI-compatible":
                _compatibleKey = apiKeyBox.Text.Trim();
                _compatibleEndpoint = endpointBox.Text.Trim();
                _compatibleModel = modelBox.Text.Trim();
                break;
            default: _groqKey = apiKeyBox.Text.Trim(); break;
        }
    }

    private void ApplyProviderToUi()
    {
        (apiKeyBox.Text, apiKeyLabel.Text, getKeyLink.Text) = _currentProvider switch
        {
            "OpenAI" => (_openAiKey, Loc.Get("Ai_OpenAiKey"), Loc.Get("Ai_GetOpenAiKey")),
            "Anthropic" => (_anthropicKey, Loc.Get("Ai_AnthropicKey"), Loc.Get("Ai_GetAnthropicKey")),
            "OpenAI-compatible" => (_compatibleKey, Loc.Get("Ai_ApiKey"), ""),
            _ => (_groqKey, Loc.Get("Ai_GroqKey"), Loc.Get("Ai_GetGroqKey"))
        };
        var custom = _currentProvider == "OpenAI-compatible";
        endpointLabel.Visible = endpointBox.Visible = modelLabel.Visible = modelBox.Visible = custom;
        getKeyLink.Visible = !custom;
        if (custom)
        {
            endpointBox.Text = _compatibleEndpoint;
            modelBox.Text = _compatibleModel;
        }
        statusLabel.Text = "";
    }

    private async void TestButton_Click(object? sender, EventArgs e)
    {
        var key = apiKeyBox.Text.Trim();
        if (key.Length == 0) { statusLabel.Text = Loc.Get("Ai_EnterKey"); return; }
        if (_currentProvider == "OpenAI-compatible" &&
            (endpointBox.Text.Trim().Length == 0 || modelBox.Text.Trim().Length == 0))
        {
            statusLabel.Text = Loc.Get("Ai_EnterEndpointModel");
            return;
        }

        SetTesting(true);
        try
        {
            statusLabel.Text = await AiExplainer.TestKeyAsync(
                key, _currentProvider, endpointBox.Text.Trim(), modelBox.Text.Trim());
        }
        finally { SetTesting(false); }
    }

    private void SetTesting(bool testing)
    {
        testButton.Enabled = providerBox.Enabled = apiKeyBox.Enabled = !testing;
        endpointBox.Enabled = modelBox.Enabled = !testing;
        if (testing) statusLabel.Text = Loc.Get("Ai_Testing");
    }

    private void GetKeyLink_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        var url = _currentProvider switch
        {
            "OpenAI" => AppLinks.OpenAiKeys,
            "Anthropic" => AppLinks.AnthropicKeys,
            _ => AppLinks.GroqKeys
        };
        AppLinks.Open(url);
    }

    private static string? EmptyToNull(string value) => value.Length == 0 ? null : value;
}
