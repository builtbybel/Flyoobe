namespace Flyoobe3.Views.Settings;

//draws the ai provider fields without a layout grid
partial class AiSettingsView
{
    private System.ComponentModel.IContainer components = null!;
    private Label aiDescriptionLabel = null!;
    private Label providerLabel = null!;
    private ComboBox providerBox = null!;
    private Label apiKeyLabel = null!;
    private TextBox apiKeyBox = null!;
    private Button testButton = null!;
    private LinkLabel getKeyLink = null!;
    private Label endpointLabel = null!;
    private TextBox endpointBox = null!;
    private Label modelLabel = null!;
    private TextBox modelBox = null!;
    private Label statusLabel = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.aiDescriptionLabel = new System.Windows.Forms.Label();
            this.providerLabel = new System.Windows.Forms.Label();
            this.providerBox = new System.Windows.Forms.ComboBox();
            this.apiKeyLabel = new System.Windows.Forms.Label();
            this.apiKeyBox = new System.Windows.Forms.TextBox();
            this.testButton = new System.Windows.Forms.Button();
            this.getKeyLink = new System.Windows.Forms.LinkLabel();
            this.endpointLabel = new System.Windows.Forms.Label();
            this.endpointBox = new System.Windows.Forms.TextBox();
            this.modelLabel = new System.Windows.Forms.Label();
            this.modelBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aiDescriptionLabel
            // 
            this.aiDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aiDescriptionLabel.Location = new System.Drawing.Point(18, 18);
            this.aiDescriptionLabel.Name = "aiDescriptionLabel";
            this.aiDescriptionLabel.Size = new System.Drawing.Size(724, 48);
            this.aiDescriptionLabel.TabIndex = 0;
            this.aiDescriptionLabel.Text = "Optional AI explanations for Windows settings. Nothing is changed by the AI.";
            // 
            // providerLabel
            // 
            this.providerLabel.Location = new System.Drawing.Point(18, 76);
            this.providerLabel.Name = "providerLabel";
            this.providerLabel.Size = new System.Drawing.Size(140, 28);
            this.providerLabel.TabIndex = 1;
            this.providerLabel.Text = "Provider:";
            this.providerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // providerBox
            // 
            this.providerBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.providerBox.Items.AddRange(new object[] {
            "Groq",
            "OpenAI",
            "Anthropic",
            "OpenAI-compatible"});
            this.providerBox.Location = new System.Drawing.Point(164, 79);
            this.providerBox.Name = "providerBox";
            this.providerBox.Size = new System.Drawing.Size(190, 23);
            this.providerBox.TabIndex = 2;
            this.providerBox.SelectedIndexChanged += new System.EventHandler(this.ProviderBox_SelectedIndexChanged);
            // 
            // apiKeyLabel
            // 
            this.apiKeyLabel.Location = new System.Drawing.Point(18, 116);
            this.apiKeyLabel.Name = "apiKeyLabel";
            this.apiKeyLabel.Size = new System.Drawing.Size(140, 28);
            this.apiKeyLabel.TabIndex = 3;
            this.apiKeyLabel.Text = "API key:";
            this.apiKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // apiKeyBox
            // 
            this.apiKeyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.apiKeyBox.Location = new System.Drawing.Point(164, 119);
            this.apiKeyBox.Name = "apiKeyBox";
            this.apiKeyBox.PasswordChar = '●';
            this.apiKeyBox.Size = new System.Drawing.Size(450, 23);
            this.apiKeyBox.TabIndex = 4;
            // 
            // testButton
            // 
            this.testButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.testButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.testButton.Location = new System.Drawing.Point(626, 116);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(100, 28);
            this.testButton.TabIndex = 5;
            this.testButton.Text = "Test";
            this.testButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // getKeyLink
            // 
            this.getKeyLink.AutoSize = true;
            this.getKeyLink.Location = new System.Drawing.Point(164, 158);
            this.getKeyLink.Name = "getKeyLink";
            this.getKeyLink.Size = new System.Drawing.Size(67, 15);
            this.getKeyLink.TabIndex = 6;
            this.getKeyLink.TabStop = true;
            this.getKeyLink.Text = "Get API key";
            this.getKeyLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GetKeyLink_LinkClicked);
            // 
            // endpointLabel
            // 
            this.endpointLabel.Location = new System.Drawing.Point(18, 196);
            this.endpointLabel.Name = "endpointLabel";
            this.endpointLabel.Size = new System.Drawing.Size(140, 28);
            this.endpointLabel.TabIndex = 7;
            this.endpointLabel.Text = "Endpoint:";
            this.endpointLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // endpointBox
            // 
            this.endpointBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endpointBox.Location = new System.Drawing.Point(164, 199);
            this.endpointBox.Name = "endpointBox";
            this.endpointBox.Size = new System.Drawing.Size(562, 23);
            this.endpointBox.TabIndex = 8;
            // 
            // modelLabel
            // 
            this.modelLabel.Location = new System.Drawing.Point(18, 236);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(140, 28);
            this.modelLabel.TabIndex = 9;
            this.modelLabel.Text = "Model:";
            this.modelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // modelBox
            // 
            this.modelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelBox.Location = new System.Drawing.Point(164, 239);
            this.modelBox.Name = "modelBox";
            this.modelBox.Size = new System.Drawing.Size(450, 23);
            this.modelBox.TabIndex = 10;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.Location = new System.Drawing.Point(18, 282);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(708, 42);
            this.statusLabel.TabIndex = 11;
            // 
            // AiSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.modelBox);
            this.Controls.Add(this.modelLabel);
            this.Controls.Add(this.endpointBox);
            this.Controls.Add(this.endpointLabel);
            this.Controls.Add(this.getKeyLink);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.apiKeyBox);
            this.Controls.Add(this.apiKeyLabel);
            this.Controls.Add(this.providerBox);
            this.Controls.Add(this.providerLabel);
            this.Controls.Add(this.aiDescriptionLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "AiSettingsView";
            this.Size = new System.Drawing.Size(760, 460);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
