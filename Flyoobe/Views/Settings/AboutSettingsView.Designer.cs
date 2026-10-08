namespace Flyoobe3.Views.Settings;

//draws the about page as a few freely movable labels and links
partial class AboutSettingsView
{
    private System.ComponentModel.IContainer components = null!;
    private PictureBox aboutIcon = null!;
    private Label aboutNameLabel = null!;
    private Label aboutVersionLabel = null!;
    private Label pronunciationLabel = null!;
    private Label aboutDescriptionLabel = null!;
    private Label aboutAuthorLabel = null!;
    private LinkLabel githubLink = null!;
    private LinkLabel releasesLink = null!;
    private LinkLabel issuesLink = null!;
    private LinkLabel supportLink = null!;
    private LinkLabel translatorLink = null!;
    private Label officialDownloadsLabel = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            aboutIcon?.Image?.Dispose();
            components?.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.aboutIcon = new System.Windows.Forms.PictureBox();
            this.aboutNameLabel = new System.Windows.Forms.Label();
            this.aboutVersionLabel = new System.Windows.Forms.Label();
            this.pronunciationLabel = new System.Windows.Forms.Label();
            this.aboutDescriptionLabel = new System.Windows.Forms.Label();
            this.aboutAuthorLabel = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.releasesLink = new System.Windows.Forms.LinkLabel();
            this.issuesLink = new System.Windows.Forms.LinkLabel();
            this.supportLink = new System.Windows.Forms.LinkLabel();
            this.translatorLink = new System.Windows.Forms.LinkLabel();
            this.officialDownloadsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.aboutIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // aboutIcon
            // 
            this.aboutIcon.Location = new System.Drawing.Point(40, 25);
            this.aboutIcon.Name = "aboutIcon";
            this.aboutIcon.Size = new System.Drawing.Size(64, 64);
            this.aboutIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aboutIcon.TabIndex = 0;
            this.aboutIcon.TabStop = false;
            // 
            // aboutNameLabel
            // 
            this.aboutNameLabel.AutoSize = true;
            this.aboutNameLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.aboutNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(183)))), ((int)(((byte)(218)))));
            this.aboutNameLabel.Location = new System.Drawing.Point(110, 25);
            this.aboutNameLabel.Name = "aboutNameLabel";
            this.aboutNameLabel.Size = new System.Drawing.Size(120, 37);
            this.aboutNameLabel.TabIndex = 1;
            this.aboutNameLabel.Text = "Flyoobe";
            // 
            // aboutVersionLabel
            // 
            this.aboutVersionLabel.AutoSize = true;
            this.aboutVersionLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.aboutVersionLabel.Location = new System.Drawing.Point(114, 62);
            this.aboutVersionLabel.Name = "aboutVersionLabel";
            this.aboutVersionLabel.Size = new System.Drawing.Size(45, 15);
            this.aboutVersionLabel.TabIndex = 2;
            this.aboutVersionLabel.Text = "Version";
            // 
            // pronunciationLabel
            // 
            this.pronunciationLabel.AutoSize = true;
            this.pronunciationLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.pronunciationLabel.Location = new System.Drawing.Point(114, 82);
            this.pronunciationLabel.Name = "pronunciationLabel";
            this.pronunciationLabel.Size = new System.Drawing.Size(303, 15);
            this.pronunciationLabel.TabIndex = 3;
            this.pronunciationLabel.Text = "Pronounced “Fly-oh-bee” — yes, the bee is in the name.";
            // 
            // aboutDescriptionLabel
            // 
            this.aboutDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutDescriptionLabel.Location = new System.Drawing.Point(112, 128);
            this.aboutDescriptionLabel.Name = "aboutDescriptionLabel";
            this.aboutDescriptionLabel.Size = new System.Drawing.Size(624, 24);
            this.aboutDescriptionLabel.TabIndex = 4;
            this.aboutDescriptionLabel.Text = "A small, signature-driven Windows setup tool.";
            this.aboutDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aboutAuthorLabel
            // 
            this.aboutAuthorLabel.AutoSize = true;
            this.aboutAuthorLabel.Location = new System.Drawing.Point(112, 160);
            this.aboutAuthorLabel.Name = "aboutAuthorLabel";
            this.aboutAuthorLabel.Size = new System.Drawing.Size(152, 15);
            this.aboutAuthorLabel.TabIndex = 5;
            this.aboutAuthorLabel.Text = "A Belim app creation (2026)";
            // 
            // githubLink
            // 
            this.githubLink.AutoSize = true;
            this.githubLink.Location = new System.Drawing.Point(112, 194);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(45, 15);
            this.githubLink.TabIndex = 6;
            this.githubLink.TabStop = true;
            this.githubLink.Text = "GitHub";
            // 
            // releasesLink
            // 
            this.releasesLink.AutoSize = true;
            this.releasesLink.Location = new System.Drawing.Point(180, 194);
            this.releasesLink.Name = "releasesLink";
            this.releasesLink.Size = new System.Drawing.Size(51, 15);
            this.releasesLink.TabIndex = 7;
            this.releasesLink.TabStop = true;
            this.releasesLink.Text = "Releases";
            // 
            // issuesLink
            // 
            this.issuesLink.AutoSize = true;
            this.issuesLink.Location = new System.Drawing.Point(254, 194);
            this.issuesLink.Name = "issuesLink";
            this.issuesLink.Size = new System.Drawing.Size(87, 15);
            this.issuesLink.TabIndex = 8;
            this.issuesLink.TabStop = true;
            this.issuesLink.Text = "Report an issue";
            // 
            // supportLink
            // 
            this.supportLink.AutoSize = true;
            this.supportLink.Location = new System.Drawing.Point(364, 194);
            this.supportLink.Name = "supportLink";
            this.supportLink.Size = new System.Drawing.Size(94, 15);
            this.supportLink.TabIndex = 9;
            this.supportLink.TabStop = true;
            this.supportLink.Text = "Support Flyoobe";
            // 
            // translatorLink
            // 
            this.translatorLink.AutoSize = true;
            this.translatorLink.ForeColor = System.Drawing.SystemColors.GrayText;
            this.translatorLink.Location = new System.Drawing.Point(114, 108);
            this.translatorLink.Name = "translatorLink";
            this.translatorLink.Size = new System.Drawing.Size(81, 15);
            this.translatorLink.TabIndex = 10;
            this.translatorLink.TabStop = true;
            this.translatorLink.Text = "Translation by";
            this.translatorLink.Visible = false;
            // 
            // officialDownloadsLabel
            // 
            this.officialDownloadsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.officialDownloadsLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.officialDownloadsLabel.Location = new System.Drawing.Point(24, 241);
            this.officialDownloadsLabel.Name = "officialDownloadsLabel";
            this.officialDownloadsLabel.Size = new System.Drawing.Size(712, 48);
            this.officialDownloadsLabel.TabIndex = 11;
            this.officialDownloadsLabel.Text = "Official downloads are published through the Flyoobe GitHub repository.";
            // 
            // AboutSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.officialDownloadsLabel);
            this.Controls.Add(this.translatorLink);
            this.Controls.Add(this.supportLink);
            this.Controls.Add(this.issuesLink);
            this.Controls.Add(this.releasesLink);
            this.Controls.Add(this.githubLink);
            this.Controls.Add(this.aboutAuthorLabel);
            this.Controls.Add(this.aboutDescriptionLabel);
            this.Controls.Add(this.pronunciationLabel);
            this.Controls.Add(this.aboutVersionLabel);
            this.Controls.Add(this.aboutNameLabel);
            this.Controls.Add(this.aboutIcon);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "AboutSettingsView";
            this.Size = new System.Drawing.Size(760, 460);
            ((System.ComponentModel.ISupportInitialize)(this.aboutIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
