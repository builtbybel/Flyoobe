namespace Flyoobe3.Views;

//draws the browser choices as two compact Windows-style task rows
partial class BrowserView
{
    private System.ComponentModel.IContainer components = null!;
    private Label titleLabel = null!;
    private Label introLabel = null!;
    private ProgressBar progressBar = null!;
    private GroupBox defaultGroup = null!;
    private ComboBox installedBrowserBox = null!;
    private Button defaultBrowserButton = null!;
    private GroupBox installGroup = null!;
    private ComboBox installBrowserBox = null!;
    private Button installButton = null!;
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
        this.progressBar = new System.Windows.Forms.ProgressBar();
        this.defaultGroup = new System.Windows.Forms.GroupBox();
        this.installedBrowserBox = new System.Windows.Forms.ComboBox();
        this.defaultBrowserButton = new System.Windows.Forms.Button();
        this.installGroup = new System.Windows.Forms.GroupBox();
        this.installBrowserBox = new System.Windows.Forms.ComboBox();
        this.installButton = new System.Windows.Forms.Button();
        this.footerPanel = new System.Windows.Forms.Panel();
        this.footerSeparator = new System.Windows.Forms.Label();
        this.statusLabel = new System.Windows.Forms.Label();
        this.defaultGroup.SuspendLayout();
        this.installGroup.SuspendLayout();
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
        this.titleLabel.Size = new System.Drawing.Size(71, 21);
        this.titleLabel.TabIndex = 1;
        this.titleLabel.Text = "Browser";
        //
        // introLabel
        //
        this.introLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.introLabel.Location = new System.Drawing.Point(8, 48);
        this.introLabel.Name = "introLabel";
        this.introLabel.Size = new System.Drawing.Size(924, 38);
        this.introLabel.TabIndex = 2;
        this.introLabel.Text = "Choose an installed browser or install another one from Apps.ini.";
        this.introLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // progressBar
        //
        this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.progressBar.Location = new System.Drawing.Point(0, 0);
        this.progressBar.Name = "progressBar";
        this.progressBar.Size = new System.Drawing.Size(940, 8);
        this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        this.progressBar.TabIndex = 3;
        this.progressBar.Visible = false;
        //
        // defaultGroup
        //
        this.defaultGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.defaultGroup.Controls.Add(this.installedBrowserBox);
        this.defaultGroup.Controls.Add(this.defaultBrowserButton);
        this.defaultGroup.Location = new System.Drawing.Point(20, 110);
        this.defaultGroup.Name = "defaultGroup";
        this.defaultGroup.Padding = new System.Windows.Forms.Padding(12, 8, 12, 10);
        this.defaultGroup.Size = new System.Drawing.Size(912, 86);
        this.defaultGroup.TabIndex = 4;
        this.defaultGroup.TabStop = false;
        this.defaultGroup.Text = "Default browser";
        //
        // installedBrowserBox
        //
        this.installedBrowserBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.installedBrowserBox.Location = new System.Drawing.Point(18, 34);
        this.installedBrowserBox.Name = "installedBrowserBox";
        this.installedBrowserBox.Size = new System.Drawing.Size(300, 23);
        this.installedBrowserBox.TabIndex = 0;
        //
        // defaultBrowserButton
        //
        this.defaultBrowserButton.Location = new System.Drawing.Point(330, 31);
        this.defaultBrowserButton.Name = "defaultBrowserButton";
        this.defaultBrowserButton.Size = new System.Drawing.Size(180, 30);
        this.defaultBrowserButton.TabIndex = 1;
        this.defaultBrowserButton.Text = "Choose as default...";
        //
        // installGroup
        //
        this.installGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.installGroup.Controls.Add(this.installBrowserBox);
        this.installGroup.Controls.Add(this.installButton);
        this.installGroup.Location = new System.Drawing.Point(20, 214);
        this.installGroup.Name = "installGroup";
        this.installGroup.Padding = new System.Windows.Forms.Padding(12, 8, 12, 10);
        this.installGroup.Size = new System.Drawing.Size(912, 86);
        this.installGroup.TabIndex = 5;
        this.installGroup.TabStop = false;
        this.installGroup.Text = "Install another browser";
        //
        // installBrowserBox
        //
        this.installBrowserBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.installBrowserBox.Location = new System.Drawing.Point(18, 34);
        this.installBrowserBox.Name = "installBrowserBox";
        this.installBrowserBox.Size = new System.Drawing.Size(300, 23);
        this.installBrowserBox.TabIndex = 0;
        //
        // installButton
        //
        this.installButton.Location = new System.Drawing.Point(330, 31);
        this.installButton.Name = "installButton";
        this.installButton.Size = new System.Drawing.Size(120, 30);
        this.installButton.TabIndex = 1;
        this.installButton.Text = "Install";
        //
        // footerPanel
        //
        this.footerPanel.BackColor = System.Drawing.SystemColors.Control;
        this.footerPanel.Controls.Add(this.statusLabel);
        this.footerPanel.Controls.Add(this.footerSeparator);
        this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.footerPanel.Location = new System.Drawing.Point(0, 538);
        this.footerPanel.Name = "footerPanel";
        this.footerPanel.Size = new System.Drawing.Size(940, 42);
        this.footerPanel.TabIndex = 6;
        //
        // footerSeparator
        //
        this.footerSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
        this.footerSeparator.Dock = System.Windows.Forms.DockStyle.Top;
        this.footerSeparator.Location = new System.Drawing.Point(0, 0);
        this.footerSeparator.Name = "footerSeparator";
        this.footerSeparator.Size = new System.Drawing.Size(940, 1);
        this.footerSeparator.TabIndex = 1;
        //
        // statusLabel
        //
        this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.statusLabel.Location = new System.Drawing.Point(8, 5);
        this.statusLabel.Name = "statusLabel";
        this.statusLabel.Size = new System.Drawing.Size(924, 34);
        this.statusLabel.TabIndex = 6;
        this.statusLabel.Text = "Windows owns the final default-app confirmation.";
        this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // BrowserView
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.BackColor = System.Drawing.SystemColors.Window;
        this.Controls.Add(this.footerPanel);
        this.Controls.Add(this.installGroup);
        this.Controls.Add(this.defaultGroup);
        this.Controls.Add(this.progressBar);
        this.Controls.Add(this.introLabel);
        this.Controls.Add(this.titleLabel);
        this.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.Name = "BrowserView";
        this.Size = new System.Drawing.Size(940, 580);
        this.defaultGroup.ResumeLayout(false);
        this.installGroup.ResumeLayout(false);
        this.footerPanel.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
