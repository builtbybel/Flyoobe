namespace Flyoobe3.Views;

//draws the settings shell with a classic category list and page frame
partial class SettingsView
{
    private System.ComponentModel.IContainer components = null!;
    private Label titleLabel = null!;
    private LinkLabel helpLink = null!;
    private ListView navigationList = null!;
    private ColumnHeader navigationColumn = null!;
    private GroupBox contentGroup = null!;
    private Panel contentHost = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            contentHost?.Controls.Clear();
            _general?.Dispose();
            _ai?.Dispose();
            _advanced?.Dispose();
            _about?.Dispose();
            components?.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.titleLabel = new System.Windows.Forms.Label();
            this.helpLink = new System.Windows.Forms.LinkLabel();
            this.navigationList = new System.Windows.Forms.ListView();
        this.navigationColumn = new System.Windows.Forms.ColumnHeader();
        this.contentGroup = new System.Windows.Forms.GroupBox();
        this.contentHost = new System.Windows.Forms.Panel();
        this.contentGroup.SuspendLayout();
        this.SuspendLayout();
        //
        // titleLabel
        //
        this.titleLabel.AutoSize = true;
        this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
        this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(0, 51, 153);
        this.titleLabel.Location = new System.Drawing.Point(8, 12);
        this.titleLabel.Name = "titleLabel";
        this.titleLabel.Size = new System.Drawing.Size(72, 21);
        this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Settings";
            // 
            // helpLink
            // 
            this.helpLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.helpLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpLink.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.helpLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.helpLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(153)))));
            this.helpLink.Location = new System.Drawing.Point(912, 14);
            this.helpLink.Name = "helpLink";
            this.helpLink.Size = new System.Drawing.Size(18, 18);
            this.helpLink.TabIndex = 1;
            this.helpLink.TabStop = true;
            this.helpLink.Text = "?";
            this.helpLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.helpLink.Click += new System.EventHandler(this.HelpLink_Click);
            // 
            // navigationList
        //
        this.navigationList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
        this.navigationList.BackColor = System.Drawing.SystemColors.Window;
        this.navigationList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.navigationColumn });
        this.navigationList.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.navigationList.FullRowSelect = true;
        this.navigationList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        this.navigationList.HideSelection = false;
        this.navigationList.Location = new System.Drawing.Point(8, 52);
        this.navigationList.MultiSelect = false;
        this.navigationList.Name = "navigationList";
        this.navigationList.Scrollable = false;
        this.navigationList.Size = new System.Drawing.Size(138, 520);
        this.navigationList.TabIndex = 2;
        this.navigationList.UseCompatibleStateImageBehavior = false;
        this.navigationList.View = System.Windows.Forms.View.Details;
        this.navigationList.SelectedIndexChanged += new System.EventHandler(this.NavigationList_SelectedIndexChanged);
        //
        // navigationColumn
        //
        this.navigationColumn.Text = "Category";
        this.navigationColumn.Width = 134;
        //
        // contentGroup
        //
        this.contentGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.contentGroup.Controls.Add(this.contentHost);
        this.contentGroup.Location = new System.Drawing.Point(154, 48);
        this.contentGroup.Name = "contentGroup";
        this.contentGroup.Padding = new System.Windows.Forms.Padding(8);
        this.contentGroup.Size = new System.Drawing.Size(778, 524);
        this.contentGroup.TabIndex = 3;
        this.contentGroup.TabStop = false;
        this.contentGroup.Text = "General";
        //
        // contentHost
        //
        this.contentHost.BackColor = System.Drawing.SystemColors.Window;
        this.contentHost.Dock = System.Windows.Forms.DockStyle.Fill;
        this.contentHost.Location = new System.Drawing.Point(8, 24);
        this.contentHost.Name = "contentHost";
        this.contentHost.Size = new System.Drawing.Size(762, 492);
        this.contentHost.TabIndex = 0;
        //
        // SettingsView
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.contentGroup);
            this.Controls.Add(this.navigationList);
            this.Controls.Add(this.helpLink);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(780, 0);
            this.Name = "SettingsView";
        this.Size = new System.Drawing.Size(940, 580);
        this.contentGroup.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
