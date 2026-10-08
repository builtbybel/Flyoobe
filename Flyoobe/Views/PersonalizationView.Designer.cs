namespace Flyoobe3.Views;

//draws the personal choices directly so the page stays easy to edit
partial class PersonalizationView
{
    private System.ComponentModel.IContainer components = null!;
    private Label titleLabel = null!;
    private Label introLabel = null!;
    private GroupBox choicesGroup = null!;
    private Label appModeLabel = null!;
    private ComboBox appModeBox = null!;
    private Label windowsModeLabel = null!;
    private ComboBox windowsModeBox = null!;
    private Label taskbarLabel = null!;
    private ComboBox taskbarBox = null!;
    private CheckBox transparencyBox = null!;
    private Label wallpaperTitleLabel = null!;
    private Label wallpaperLabel = null!;
    private Button applyButton = null!;
    private Button wallpaperButton = null!;
    private Button windowsSettingsButton = null!;
    private Panel footerPanel = null!;
    private Label footerSeparator = null!;
    private Label statusLabel = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.titleLabel = new System.Windows.Forms.Label();
            this.introLabel = new System.Windows.Forms.Label();
            this.choicesGroup = new System.Windows.Forms.GroupBox();
            this.appModeLabel = new System.Windows.Forms.Label();
            this.appModeBox = new System.Windows.Forms.ComboBox();
            this.windowsModeLabel = new System.Windows.Forms.Label();
            this.windowsModeBox = new System.Windows.Forms.ComboBox();
            this.taskbarLabel = new System.Windows.Forms.Label();
            this.taskbarBox = new System.Windows.Forms.ComboBox();
            this.transparencyBox = new System.Windows.Forms.CheckBox();
            this.wallpaperTitleLabel = new System.Windows.Forms.Label();
            this.wallpaperLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.wallpaperButton = new System.Windows.Forms.Button();
            this.windowsSettingsButton = new System.Windows.Forms.Button();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.footerSeparator = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.choicesGroup.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(0, 51, 153);
            this.titleLabel.Location = new System.Drawing.Point(8, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(129, 21);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Personalization";
            // 
            // introLabel
            // 
            this.introLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.introLabel.Location = new System.Drawing.Point(8, 48);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(924, 40);
            this.introLabel.TabIndex = 2;
            this.introLabel.Text = "The common fresh-install choices, without rebuilding the whole Windows Settings a" +
    "pp.";
            this.introLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // choicesGroup
            // 
            this.choicesGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.choicesGroup.Controls.Add(this.appModeLabel);
            this.choicesGroup.Controls.Add(this.appModeBox);
            this.choicesGroup.Controls.Add(this.windowsModeLabel);
            this.choicesGroup.Controls.Add(this.windowsModeBox);
            this.choicesGroup.Controls.Add(this.taskbarLabel);
            this.choicesGroup.Controls.Add(this.taskbarBox);
            this.choicesGroup.Controls.Add(this.transparencyBox);
            this.choicesGroup.Controls.Add(this.wallpaperTitleLabel);
            this.choicesGroup.Controls.Add(this.wallpaperLabel);
            this.choicesGroup.Location = new System.Drawing.Point(8, 94);
            this.choicesGroup.Name = "choicesGroup";
            this.choicesGroup.Size = new System.Drawing.Size(924, 408);
            this.choicesGroup.TabIndex = 3;
            this.choicesGroup.TabStop = false;
            this.choicesGroup.Text = "Your Windows look";
            // 
            // appModeLabel
            // 
            this.appModeLabel.Location = new System.Drawing.Point(18, 32);
            this.appModeLabel.Name = "appModeLabel";
            this.appModeLabel.Size = new System.Drawing.Size(180, 23);
            this.appModeLabel.TabIndex = 0;
            this.appModeLabel.Text = "App mode";
            this.appModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // appModeBox
            // 
            this.appModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appModeBox.Location = new System.Drawing.Point(204, 32);
            this.appModeBox.Name = "appModeBox";
            this.appModeBox.Size = new System.Drawing.Size(180, 23);
            this.appModeBox.TabIndex = 1;
            // 
            // windowsModeLabel
            // 
            this.windowsModeLabel.Location = new System.Drawing.Point(18, 74);
            this.windowsModeLabel.Name = "windowsModeLabel";
            this.windowsModeLabel.Size = new System.Drawing.Size(180, 23);
            this.windowsModeLabel.TabIndex = 2;
            this.windowsModeLabel.Text = "Windows mode";
            this.windowsModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // windowsModeBox
            // 
            this.windowsModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.windowsModeBox.Location = new System.Drawing.Point(204, 74);
            this.windowsModeBox.Name = "windowsModeBox";
            this.windowsModeBox.Size = new System.Drawing.Size(180, 23);
            this.windowsModeBox.TabIndex = 3;
            // 
            // taskbarLabel
            // 
            this.taskbarLabel.Location = new System.Drawing.Point(18, 116);
            this.taskbarLabel.Name = "taskbarLabel";
            this.taskbarLabel.Size = new System.Drawing.Size(180, 23);
            this.taskbarLabel.TabIndex = 4;
            this.taskbarLabel.Text = "Taskbar alignment";
            this.taskbarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // taskbarBox
            // 
            this.taskbarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taskbarBox.Location = new System.Drawing.Point(204, 116);
            this.taskbarBox.Name = "taskbarBox";
            this.taskbarBox.Size = new System.Drawing.Size(180, 23);
            this.taskbarBox.TabIndex = 5;
            // 
            // transparencyBox
            // 
            this.transparencyBox.AutoSize = true;
            this.transparencyBox.Location = new System.Drawing.Point(204, 160);
            this.transparencyBox.Name = "transparencyBox";
            this.transparencyBox.Size = new System.Drawing.Size(154, 19);
            this.transparencyBox.TabIndex = 6;
            this.transparencyBox.Text = "Use transparency effects";
            // 
            // wallpaperTitleLabel
            // 
            this.wallpaperTitleLabel.Location = new System.Drawing.Point(18, 202);
            this.wallpaperTitleLabel.Name = "wallpaperTitleLabel";
            this.wallpaperTitleLabel.Size = new System.Drawing.Size(180, 23);
            this.wallpaperTitleLabel.TabIndex = 7;
            this.wallpaperTitleLabel.Text = "Wallpaper";
            this.wallpaperTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wallpaperLabel
            // 
            this.wallpaperLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wallpaperLabel.AutoEllipsis = true;
            this.wallpaperLabel.Location = new System.Drawing.Point(204, 202);
            this.wallpaperLabel.Name = "wallpaperLabel";
            this.wallpaperLabel.Size = new System.Drawing.Size(700, 23);
            this.wallpaperLabel.TabIndex = 8;
            this.wallpaperLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.footerPanel.Controls.Add(this.statusLabel);
            this.footerPanel.Controls.Add(this.windowsSettingsButton);
            this.footerPanel.Controls.Add(this.wallpaperButton);
            this.footerPanel.Controls.Add(this.applyButton);
            this.footerPanel.Controls.Add(this.footerSeparator);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 502);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(940, 78);
            this.footerPanel.TabIndex = 4;
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.applyButton.AutoEllipsis = true;
            this.applyButton.Location = new System.Drawing.Point(8, 8);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(134, 30);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Apply choices";
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // wallpaperButton
            // 
            this.wallpaperButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.wallpaperButton.AutoEllipsis = true;
            this.wallpaperButton.Location = new System.Drawing.Point(148, 8);
            this.wallpaperButton.Name = "wallpaperButton";
            this.wallpaperButton.Size = new System.Drawing.Size(140, 30);
            this.wallpaperButton.TabIndex = 5;
            this.wallpaperButton.Text = "Choose wallpaper...";
            this.wallpaperButton.Click += new System.EventHandler(this.WallpaperButton_Click);
            // 
            // windowsSettingsButton
            // 
            this.windowsSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.windowsSettingsButton.AutoEllipsis = true;
            this.windowsSettingsButton.Location = new System.Drawing.Point(294, 8);
            this.windowsSettingsButton.Name = "windowsSettingsButton";
            this.windowsSettingsButton.Size = new System.Drawing.Size(180, 30);
            this.windowsSettingsButton.TabIndex = 6;
            this.windowsSettingsButton.Text = "More Windows settings...";
            this.windowsSettingsButton.Click += new System.EventHandler(this.WindowsSettingsButton_Click);
            // 
            // footerSeparator
            // 
            this.footerSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.footerSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.footerSeparator.Location = new System.Drawing.Point(0, 0);
            this.footerSeparator.Name = "footerSeparator";
            this.footerSeparator.Size = new System.Drawing.Size(940, 1);
            this.footerSeparator.TabIndex = 8;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.Location = new System.Drawing.Point(8, 44);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(924, 26);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.Text = "Current choices loaded from Windows.";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PersonalizationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.choicesGroup);
            this.Controls.Add(this.introLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "PersonalizationView";
            this.Size = new System.Drawing.Size(940, 580);
            this.choicesGroup.ResumeLayout(false);
            this.choicesGroup.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
