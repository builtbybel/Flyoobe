namespace Flyoobe3.Views.Settings;

partial class AdvancedSettingsView
{
    private System.ComponentModel.IContainer components = null!;
    private Label sectionLabel = null!;
    private CheckBox setupActionsCheck = null!;
    private Label descriptionLabel = null!;
    private Label warningLabel = null!;
    private Button openFolderButton = null!;
    private Label logSectionLabel = null!;
    private CheckBox changeLogCheck = null!;
    private Label logDescriptionLabel = null!;
    private Button openLogButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.sectionLabel = new System.Windows.Forms.Label();
            this.setupActionsCheck = new System.Windows.Forms.CheckBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.warningLabel = new System.Windows.Forms.Label();
            this.openFolderButton = new System.Windows.Forms.Button();
            this.logSectionLabel = new System.Windows.Forms.Label();
            this.changeLogCheck = new System.Windows.Forms.CheckBox();
            this.logDescriptionLabel = new System.Windows.Forms.Label();
            this.openLogButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sectionLabel
            // 
            this.sectionLabel.AutoSize = true;
            this.sectionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.sectionLabel.Location = new System.Drawing.Point(18, 18);
            this.sectionLabel.Name = "sectionLabel";
            this.sectionLabel.Size = new System.Drawing.Size(104, 15);
            this.sectionLabel.TabIndex = 0;
            this.sectionLabel.Text = "Optional features";
            // 
            // setupActionsCheck
            // 
            this.setupActionsCheck.AutoSize = true;
            this.setupActionsCheck.Location = new System.Drawing.Point(22, 46);
            this.setupActionsCheck.Name = "setupActionsCheck";
            this.setupActionsCheck.Size = new System.Drawing.Size(137, 19);
            this.setupActionsCheck.TabIndex = 1;
            this.setupActionsCheck.Text = "Enable Setup Actions";
            this.setupActionsCheck.UseVisualStyleBackColor = true;
            this.setupActionsCheck.CheckedChanged += new System.EventHandler(this.SetupActionsCheck_CheckedChanged);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionLabel.Location = new System.Drawing.Point(22, 72);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(710, 52);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "Loads local, manifest-based setup actions and makes recipe-safe actions available" +
    " to recipes.";
            // 
            // warningLabel
            // 
            this.warningLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warningLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.warningLabel.Location = new System.Drawing.Point(22, 128);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(710, 40);
            this.warningLabel.TabIndex = 3;
            this.warningLabel.Text = "Setup Actions can run PowerShell scripts. Only add packages you trust.";
            // 
            // openFolderButton
            // 
            this.openFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.openFolderButton.Location = new System.Drawing.Point(22, 176);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(184, 30);
            this.openFolderButton.TabIndex = 4;
            this.openFolderButton.Text = "Open Actions folder";
            this.openFolderButton.UseVisualStyleBackColor = true;
            this.openFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // logSectionLabel
            // 
            this.logSectionLabel.AutoSize = true;
            this.logSectionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.logSectionLabel.Location = new System.Drawing.Point(18, 232);
            this.logSectionLabel.Name = "logSectionLabel";
            this.logSectionLabel.Size = new System.Drawing.Size(68, 15);
            this.logSectionLabel.TabIndex = 5;
            this.logSectionLabel.Text = "Change log";
            // 
            // changeLogCheck
            // 
            this.changeLogCheck.AutoSize = true;
            this.changeLogCheck.Location = new System.Drawing.Point(22, 260);
            this.changeLogCheck.Name = "changeLogCheck";
            this.changeLogCheck.Size = new System.Drawing.Size(125, 19);
            this.changeLogCheck.TabIndex = 6;
            this.changeLogCheck.Text = "Write a change log";
            this.changeLogCheck.UseVisualStyleBackColor = true;
            this.changeLogCheck.CheckedChanged += new System.EventHandler(this.ChangeLogCheck_CheckedChanged);
            // 
            // logDescriptionLabel
            // 
            this.logDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logDescriptionLabel.Location = new System.Drawing.Point(22, 286);
            this.logDescriptionLabel.Name = "logDescriptionLabel";
            this.logDescriptionLabel.Size = new System.Drawing.Size(710, 52);
            this.logDescriptionLabel.TabIndex = 7;
            this.logDescriptionLabel.Text = "Flyoobe records every change it makes, including the value it replaced.";
            // 
            // openLogButton
            // 
            this.openLogButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.openLogButton.Location = new System.Drawing.Point(22, 346);
            this.openLogButton.Name = "openLogButton";
            this.openLogButton.Size = new System.Drawing.Size(184, 30);
            this.openLogButton.TabIndex = 8;
            this.openLogButton.Text = "Open change log";
            this.openLogButton.UseVisualStyleBackColor = true;
            this.openLogButton.Click += new System.EventHandler(this.OpenLogButton_Click);
            // 
            // AdvancedSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.openLogButton);
            this.Controls.Add(this.logDescriptionLabel);
            this.Controls.Add(this.changeLogCheck);
            this.Controls.Add(this.logSectionLabel);
            this.Controls.Add(this.openFolderButton);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.setupActionsCheck);
            this.Controls.Add(this.sectionLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "AdvancedSettingsView";
            this.Size = new System.Drawing.Size(760, 460);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
