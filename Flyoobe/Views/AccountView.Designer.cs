namespace Flyoobe3.Views;

//draws the small account page with normal designer-friendly controls
partial class AccountView
{
    private System.ComponentModel.IContainer components = null!;
    private Label titleLabel = null!;
    private Label introLabel = null!;
    private GroupBox accountGroup = null!;
    private Button accountSettingsButton = null!;
    private Button otherUsersButton = null!;
    private Button localAccountButton = null!;
    private TextBox detailsBox = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.titleLabel = new System.Windows.Forms.Label();
            this.introLabel = new System.Windows.Forms.Label();
            this.accountGroup = new System.Windows.Forms.GroupBox();
            this.accountSettingsButton = new System.Windows.Forms.Button();
            this.otherUsersButton = new System.Windows.Forms.Button();
            this.localAccountButton = new System.Windows.Forms.Button();
            this.detailsBox = new System.Windows.Forms.TextBox();
            this.accountGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.titleLabel.Location = new System.Drawing.Point(8, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(66, 21);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Account";
            // 
            // introLabel
            // 
            this.introLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.introLabel.Location = new System.Drawing.Point(8, 48);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(924, 42);
            this.introLabel.TabIndex = 2;
            this.introLabel.Text = "Choose how this PC is used. Windows still owns passwords, sign-in and account sec" +
    "urity.";
            this.introLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // accountGroup
            // 
            this.accountGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountGroup.Controls.Add(this.accountSettingsButton);
            this.accountGroup.Controls.Add(this.otherUsersButton);
            this.accountGroup.Controls.Add(this.localAccountButton);
            this.accountGroup.Location = new System.Drawing.Point(8, 96);
            this.accountGroup.Name = "accountGroup";
            this.accountGroup.Size = new System.Drawing.Size(924, 88);
            this.accountGroup.TabIndex = 3;
            this.accountGroup.TabStop = false;
            this.accountGroup.Text = "Windows account setup";
            // 
            // accountSettingsButton
            // 
            this.accountSettingsButton.Location = new System.Drawing.Point(12, 30);
            this.accountSettingsButton.Name = "accountSettingsButton";
            this.accountSettingsButton.Size = new System.Drawing.Size(145, 30);
            this.accountSettingsButton.TabIndex = 0;
            this.accountSettingsButton.Text = "Account settings";
            this.accountSettingsButton.Click += new System.EventHandler(this.AccountSettingsButton_Click);
            // 
            // otherUsersButton
            // 
            this.otherUsersButton.Location = new System.Drawing.Point(165, 30);
            this.otherUsersButton.Name = "otherUsersButton";
            this.otherUsersButton.Size = new System.Drawing.Size(130, 30);
            this.otherUsersButton.TabIndex = 1;
            this.otherUsersButton.Text = "Other users";
            this.otherUsersButton.Click += new System.EventHandler(this.OtherUsersButton_Click);
            // 
            // localAccountButton
            // 
            this.localAccountButton.Location = new System.Drawing.Point(303, 30);
            this.localAccountButton.Name = "localAccountButton";
            this.localAccountButton.Size = new System.Drawing.Size(165, 30);
            this.localAccountButton.TabIndex = 2;
            this.localAccountButton.Text = "Create local account";
            this.localAccountButton.Click += new System.EventHandler(this.LocalAccountButton_Click);
            // 
            // detailsBox
            // 
            this.detailsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsBox.BackColor = System.Drawing.SystemColors.Window;
            this.detailsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsBox.Location = new System.Drawing.Point(8, 192);
            this.detailsBox.Multiline = true;
            this.detailsBox.Name = "detailsBox";
            this.detailsBox.ReadOnly = true;
            this.detailsBox.Size = new System.Drawing.Size(924, 380);
            this.detailsBox.TabIndex = 4;
            this.detailsBox.TabStop = false;
            this.detailsBox.Text = "Flyoobe no longer asks for a username or password itself.\r\n\r\nThe buttons open the" +
    " matching native Windows workflow, which is smaller and safer than another accou" +
    "nt manager.";
            // 
            // AccountView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.detailsBox);
            this.Controls.Add(this.accountGroup);
            this.Controls.Add(this.introLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "AccountView";
            this.Size = new System.Drawing.Size(940, 580);
            this.accountGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
