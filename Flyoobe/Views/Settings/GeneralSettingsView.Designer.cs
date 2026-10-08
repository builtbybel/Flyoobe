namespace Flyoobe3.Views.Settings;

//draws the few general options as normal movable controls
partial class GeneralSettingsView
{
    private System.ComponentModel.IContainer components = null!;
    private Label languageLabel = null!;
    private ComboBox languageBox = null!;
    private Button openLocalizationButton = null!;
    private Button openDataButton = null!;
    private Label settingsFileTitleLabel = null!;
    private Label settingsFileLabel = null!;
    private Label databasesTitleLabel = null!;
    private Label databasesDescriptionLabel = null!;
    private ListBox databaseList = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.languageLabel = new System.Windows.Forms.Label();
            this.languageBox = new System.Windows.Forms.ComboBox();
            this.openLocalizationButton = new System.Windows.Forms.Button();
            this.openDataButton = new System.Windows.Forms.Button();
            this.settingsFileTitleLabel = new System.Windows.Forms.Label();
            this.settingsFileLabel = new System.Windows.Forms.Label();
            this.databasesTitleLabel = new System.Windows.Forms.Label();
            this.databasesDescriptionLabel = new System.Windows.Forms.Label();
            this.databaseList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // languageLabel
            // 
            this.languageLabel.Location = new System.Drawing.Point(18, 20);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(140, 28);
            this.languageLabel.TabIndex = 0;
            this.languageLabel.Text = "Language:";
            this.languageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // languageBox
            // 
            this.languageBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageBox.Location = new System.Drawing.Point(164, 23);
            this.languageBox.Name = "languageBox";
            this.languageBox.Size = new System.Drawing.Size(220, 23);
            this.languageBox.TabIndex = 1;
            this.languageBox.SelectedIndexChanged += new System.EventHandler(this.LanguageBox_SelectedIndexChanged);
            // 
            // openLocalizationButton
            // 
            this.openLocalizationButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.openLocalizationButton.Location = new System.Drawing.Point(400, 20);
            this.openLocalizationButton.Name = "openLocalizationButton";
            this.openLocalizationButton.Size = new System.Drawing.Size(190, 30);
            this.openLocalizationButton.TabIndex = 2;
            this.openLocalizationButton.Text = "Open localization folder";
            this.openLocalizationButton.Click += new System.EventHandler(this.OpenLocalizationButton_Click);
            // 
            // openDataButton
            // 
            this.openDataButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.openDataButton.Location = new System.Drawing.Point(164, 346);
            this.openDataButton.Name = "openDataButton";
            this.openDataButton.Size = new System.Drawing.Size(180, 30);
            this.openDataButton.TabIndex = 3;
            this.openDataButton.Text = "Open data folder";
            this.openDataButton.Click += new System.EventHandler(this.OpenDataButton_Click);
            // 
            // settingsFileTitleLabel
            // 
            this.settingsFileTitleLabel.Location = new System.Drawing.Point(18, 108);
            this.settingsFileTitleLabel.Name = "settingsFileTitleLabel";
            this.settingsFileTitleLabel.Size = new System.Drawing.Size(140, 28);
            this.settingsFileTitleLabel.TabIndex = 4;
            this.settingsFileTitleLabel.Text = "Settings file:";
            this.settingsFileTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // settingsFileLabel
            // 
            this.settingsFileLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsFileLabel.AutoEllipsis = true;
            this.settingsFileLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.settingsFileLabel.Location = new System.Drawing.Point(164, 108);
            this.settingsFileLabel.Name = "settingsFileLabel";
            this.settingsFileLabel.Size = new System.Drawing.Size(578, 28);
            this.settingsFileLabel.TabIndex = 5;
            this.settingsFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // databasesTitleLabel
            // 
            this.databasesTitleLabel.AutoSize = true;
            this.databasesTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.databasesTitleLabel.Location = new System.Drawing.Point(18, 174);
            this.databasesTitleLabel.Name = "databasesTitleLabel";
            this.databasesTitleLabel.Size = new System.Drawing.Size(63, 15);
            this.databasesTitleLabel.TabIndex = 6;
            this.databasesTitleLabel.Text = "Databases";
            // 
            // databasesDescriptionLabel
            // 
            this.databasesDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.databasesDescriptionLabel.Location = new System.Drawing.Point(18, 200);
            this.databasesDescriptionLabel.Name = "databasesDescriptionLabel";
            this.databasesDescriptionLabel.Size = new System.Drawing.Size(724, 38);
            this.databasesDescriptionLabel.TabIndex = 7;
            this.databasesDescriptionLabel.Text = "Flyoobe.ini is built in. Additional Flyoobe*.ini files in the data folder are mer" +
    "ged automatically when Flyoobe starts.";
            // 
            // databaseList
            // 
            this.databaseList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.databaseList.FormattingEnabled = true;
            this.databaseList.IntegralHeight = false;
            this.databaseList.ItemHeight = 15;
            this.databaseList.Location = new System.Drawing.Point(164, 244);
            this.databaseList.Name = "databaseList";
            this.databaseList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.databaseList.Size = new System.Drawing.Size(426, 88);
            this.databaseList.TabIndex = 8;
            // 
            // GeneralSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.databaseList);
            this.Controls.Add(this.databasesDescriptionLabel);
            this.Controls.Add(this.databasesTitleLabel);
            this.Controls.Add(this.settingsFileLabel);
            this.Controls.Add(this.settingsFileTitleLabel);
            this.Controls.Add(this.openDataButton);
            this.Controls.Add(this.openLocalizationButton);
            this.Controls.Add(this.languageBox);
            this.Controls.Add(this.languageLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "GeneralSettingsView";
            this.Size = new System.Drawing.Size(760, 460);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
