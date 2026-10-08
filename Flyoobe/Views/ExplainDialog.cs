using Flyoobe3.Features.AI;
using Flyoobe3.Models;
using Flyoobe3.Services;

namespace Flyoobe3.Views;

//opens immediately and fills the selected rule explanation when ai is done
internal partial class ExplainDialog : Form
{
    public ExplainDialog() : this("Windows setting")
    {
        //the empty constructor keeps the WinForms designer happy
    }

    public ExplainDialog(string ruleName)
    {
        InitializeComponent();
        closeButton.Text = Loc.Get("Ai_Close");
        bodyBox.Text = Loc.Get("Ai_Thinking");
        Text = Loc.Format("Ai_Title", ruleName);
    }

    public async Task LoadAsync(SetupRule rule)
    {
        var answer = await AiExplainer.ExplainAsync(rule);
        if (!IsDisposed) bodyBox.Text = answer;
    }
}
