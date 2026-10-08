using Flyoobe3.Services;

namespace Flyoobe3.Views;

//keeps account setup simple and lets Windows handle the sensitive parts
internal partial class AccountView : UserControl
{
    public AccountView()
    {
        InitializeComponent();
        ApplyLocalization();
    }

    private void ApplyLocalization()
    {
        titleLabel.Text = Loc.Get("Account_Title");
        introLabel.Text = Loc.Get("Account_Intro");
        accountGroup.Text = Loc.Get("Account_Group");
        accountSettingsButton.Text = Loc.Get("Account_Settings");
        otherUsersButton.Text = Loc.Get("Account_OtherUsers");
        localAccountButton.Text = Loc.Get("Account_CreateLocalAccount");
        detailsBox.Text = Loc.Get("Account_Details");
    }

    private void AccountSettingsButton_Click(object? sender, EventArgs e) => WindowsActions.OpenAccounts();
    private void OtherUsersButton_Click(object? sender, EventArgs e) => WindowsActions.OpenOtherUsers();

    private void LocalAccountButton_Click(object? sender, EventArgs e)
    {
        try { WindowsActions.OpenLocalAccountWizard(); }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, Loc.Get("Account_SetupTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
