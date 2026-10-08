namespace Flyoobe3;

// contains only the main window and its view host
partial class MainForm
{
    private System.ComponentModel.IContainer components = null!;
    private Panel viewHost = null!;
    private Panel accentBar = null!;
    private Panel navigationBar = null!;
    private Button backButton = null!;
    private Button forwardButton = null!;
    private Panel navigationSeparator = null!;
    private Panel addressBar = null!;
    private TableLayoutPanel crumbStrip = null!;
    private Button crumbRootButton = null!;
    private Label crumbCurrentLabel = null!;
    private Panel searchSeparator = null!;
    private Panel searchHost = null!;
    private TableLayoutPanel searchField = null!;
    private TextBox searchBox = null!;
    private Label clearSearchButton = null!;
    private Button settingsButton = null!;
    private ToolTip navigationTips = null!;
    private StatusStrip statusBar = null!;
    private ToolStripStatusLabel statusLeft = null!;
    private ToolStripStatusLabel statusSpacer = null!;
    private ToolStripStatusLabel statusRight = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.viewHost = new System.Windows.Forms.Panel();
            this.accentBar = new System.Windows.Forms.Panel();
            this.navigationBar = new System.Windows.Forms.Panel();
            this.addressBar = new System.Windows.Forms.Panel();
            this.crumbStrip = new System.Windows.Forms.TableLayoutPanel();
            this.crumbRootButton = new System.Windows.Forms.Button();
            this.crumbCurrentLabel = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.searchSeparator = new System.Windows.Forms.Panel();
            this.searchHost = new System.Windows.Forms.Panel();
            this.searchField = new System.Windows.Forms.TableLayoutPanel();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.clearSearchButton = new System.Windows.Forms.Label();
            this.navigationSeparator = new System.Windows.Forms.Panel();
            this.forwardButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.navigationTips = new System.Windows.Forms.ToolTip(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.navigationBar.SuspendLayout();
            this.addressBar.SuspendLayout();
            this.crumbStrip.SuspendLayout();
            this.searchHost.SuspendLayout();
            this.searchField.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewHost
            // 
            this.viewHost.BackColor = System.Drawing.SystemColors.Window;
            this.viewHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewHost.Location = new System.Drawing.Point(0, 53);
            this.viewHost.Name = "viewHost";
            this.viewHost.Size = new System.Drawing.Size(984, 566);
            this.viewHost.TabIndex = 0;
            // 
            // accentBar
            // 
            this.accentBar.BackColor = System.Drawing.Color.Transparent;
            this.accentBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.accentBar.Location = new System.Drawing.Point(0, 0);
            this.accentBar.Name = "accentBar";
            this.accentBar.Size = new System.Drawing.Size(984, 4);
            this.accentBar.TabIndex = 1;
            this.accentBar.Visible = false;
            // 
            // navigationBar
            // 
            this.navigationBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.navigationBar.Controls.Add(this.addressBar);
            this.navigationBar.Controls.Add(this.searchSeparator);
            this.navigationBar.Controls.Add(this.searchHost);
            this.navigationBar.Controls.Add(this.navigationSeparator);
            this.navigationBar.Controls.Add(this.forwardButton);
            this.navigationBar.Controls.Add(this.backButton);
            this.navigationBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationBar.Location = new System.Drawing.Point(0, 4);
            this.navigationBar.Name = "navigationBar";
            this.navigationBar.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.navigationBar.Size = new System.Drawing.Size(984, 49);
            this.navigationBar.TabIndex = 2;
            // 
            // addressBar
            // 
            this.addressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.addressBar.Controls.Add(this.crumbStrip);
            this.addressBar.Controls.Add(this.settingsButton);
            this.addressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressBar.Location = new System.Drawing.Point(84, 8);
            this.addressBar.Name = "addressBar";
            this.addressBar.Padding = new System.Windows.Forms.Padding(1);
            this.addressBar.Size = new System.Drawing.Size(720, 33);
            this.addressBar.TabIndex = 3;
            // 
            // crumbStrip
            // 
            this.crumbStrip.BackColor = System.Drawing.SystemColors.Window;
            this.crumbStrip.ColumnCount = 3;
            this.crumbStrip.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.crumbStrip.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.crumbStrip.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.crumbStrip.Controls.Add(this.crumbRootButton, 0, 0);
            this.crumbStrip.Controls.Add(this.crumbCurrentLabel, 1, 0);
            this.crumbStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crumbStrip.Location = new System.Drawing.Point(1, 1);
            this.crumbStrip.Name = "crumbStrip";
            this.crumbStrip.RowCount = 1;
            this.crumbStrip.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.crumbStrip.Size = new System.Drawing.Size(686, 31);
            this.crumbStrip.TabIndex = 9;
            // 
            // crumbRootButton
            // 
            this.crumbRootButton.AutoSize = true;
            this.crumbRootButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.crumbRootButton.BackColor = System.Drawing.SystemColors.Window;
            this.crumbRootButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crumbRootButton.FlatAppearance.BorderSize = 0;
            this.crumbRootButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.crumbRootButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.crumbRootButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crumbRootButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.crumbRootButton.Location = new System.Drawing.Point(0, 0);
            this.crumbRootButton.Margin = new System.Windows.Forms.Padding(0);
            this.crumbRootButton.Name = "crumbRootButton";
            this.crumbRootButton.Padding = new System.Windows.Forms.Padding(8, 0, 2, 0);
            this.crumbRootButton.Size = new System.Drawing.Size(69, 31);
            this.crumbRootButton.TabIndex = 0;
            this.crumbRootButton.Text = "Flyoobe";
            this.crumbRootButton.UseVisualStyleBackColor = false;
            this.crumbRootButton.Click += new System.EventHandler(this.CrumbRootButton_Click);
            // 
            // crumbCurrentLabel
            // 
            this.crumbCurrentLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.crumbCurrentLabel.AutoSize = true;
            this.crumbCurrentLabel.Location = new System.Drawing.Point(72, 8);
            this.crumbCurrentLabel.Name = "crumbCurrentLabel";
            this.crumbCurrentLabel.Padding = new System.Windows.Forms.Padding(2, 0, 8, 0);
            this.crumbCurrentLabel.Size = new System.Drawing.Size(76, 15);
            this.crumbCurrentLabel.TabIndex = 1;
            this.crumbCurrentLabel.Text = "›  Overview";
            this.crumbCurrentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.SystemColors.Window;
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.settingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11F);
            this.settingsButton.ForeColor = System.Drawing.Color.Black;
            this.settingsButton.Location = new System.Drawing.Point(687, 1);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(32, 31);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.Text = "";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // searchSeparator
            // 
            this.searchSeparator.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchSeparator.Location = new System.Drawing.Point(804, 8);
            this.searchSeparator.Name = "searchSeparator";
            this.searchSeparator.Size = new System.Drawing.Size(6, 33);
            this.searchSeparator.TabIndex = 6;
            // 
            // searchHost
            // 
            this.searchHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.searchHost.Controls.Add(this.searchField);
            this.searchHost.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchHost.Location = new System.Drawing.Point(810, 8);
            this.searchHost.Name = "searchHost";
            this.searchHost.Padding = new System.Windows.Forms.Padding(1);
            this.searchHost.Size = new System.Drawing.Size(164, 33);
            this.searchHost.TabIndex = 5;
            // 
            // searchField
            // 
            this.searchField.BackColor = System.Drawing.SystemColors.Window;
            this.searchField.ColumnCount = 2;
            this.searchField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.searchField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchField.Controls.Add(this.searchBox, 0, 0);
            this.searchField.Controls.Add(this.clearSearchButton, 1, 0);
            this.searchField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchField.Location = new System.Drawing.Point(1, 1);
            this.searchField.Name = "searchField";
            this.searchField.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.searchField.RowCount = 1;
            this.searchField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.searchField.Size = new System.Drawing.Size(162, 31);
            this.searchField.TabIndex = 0;
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchBox.ForeColor = System.Drawing.Color.DimGray;
            this.searchBox.Location = new System.Drawing.Point(9, 7);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(123, 16);
            this.searchBox.TabIndex = 0;
            this.searchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // clearSearchButton
            // 
            this.clearSearchButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clearSearchButton.AutoSize = true;
            this.clearSearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearSearchButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.clearSearchButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clearSearchButton.Location = new System.Drawing.Point(138, 8);
            this.clearSearchButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.clearSearchButton.Name = "clearSearchButton";
            this.clearSearchButton.Size = new System.Drawing.Size(18, 15);
            this.clearSearchButton.TabIndex = 1;
            this.clearSearchButton.Text = "✕";
            this.clearSearchButton.Visible = false;
            this.clearSearchButton.Click += new System.EventHandler(this.ClearSearchButton_Click);
            // 
            // navigationSeparator
            // 
            this.navigationSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.navigationSeparator.Location = new System.Drawing.Point(78, 8);
            this.navigationSeparator.Name = "navigationSeparator";
            this.navigationSeparator.Size = new System.Drawing.Size(6, 33);
            this.navigationSeparator.TabIndex = 2;
            // 
            // forwardButton
            // 
            this.forwardButton.BackColor = System.Drawing.Color.Transparent;
            this.forwardButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.forwardButton.Enabled = false;
            this.forwardButton.FlatAppearance.BorderSize = 0;
            this.forwardButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            this.forwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forwardButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F);
            this.forwardButton.ForeColor = System.Drawing.Color.Black;
            this.forwardButton.Location = new System.Drawing.Point(44, 8);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(34, 33);
            this.forwardButton.TabIndex = 1;
            this.forwardButton.TabStop = false;
            this.forwardButton.Text = "";
            this.forwardButton.UseVisualStyleBackColor = false;
            this.forwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.backButton.Enabled = false;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F);
            this.backButton.ForeColor = System.Drawing.Color.Black;
            this.backButton.Location = new System.Drawing.Point(10, 8);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(34, 33);
            this.backButton.TabIndex = 0;
            this.backButton.TabStop = false;
            this.backButton.Text = "";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLeft,
            this.statusSpacer,
            this.statusRight});
            this.statusBar.Location = new System.Drawing.Point(0, 619);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusBar.ShowItemToolTips = true;
            this.statusBar.Size = new System.Drawing.Size(984, 22);
            this.statusBar.TabIndex = 1;
            // 
            // statusLeft
            // 
            this.statusLeft.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.statusLeft.IsLink = true;
            this.statusLeft.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.statusLeft.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.statusLeft.Name = "statusLeft";
            this.statusLeft.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.statusLeft.Size = new System.Drawing.Size(104, 17);
            this.statusLeft.Text = "Support Flyoobe";
            this.statusLeft.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.statusLeft.Click += new System.EventHandler(this.StatusLeft_Click);
            // 
            // statusSpacer
            // 
            this.statusSpacer.Name = "statusSpacer";
            this.statusSpacer.Size = new System.Drawing.Size(774, 17);
            this.statusSpacer.Spring = true;
            // 
            // statusRight
            // 
            this.statusRight.ForeColor = System.Drawing.SystemColors.GrayText;
            this.statusRight.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.statusRight.Name = "statusRight";
            this.statusRight.Size = new System.Drawing.Size(49, 17);
            this.statusRight.Text = "v3.00.01";
            this.statusRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(984, 641);
            this.Controls.Add(this.viewHost);
            this.Controls.Add(this.navigationBar);
            this.Controls.Add(this.accentBar);
            this.Controls.Add(this.statusBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(760, 540);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flyoobe";
            this.navigationBar.ResumeLayout(false);
            this.addressBar.ResumeLayout(false);
            this.crumbStrip.ResumeLayout(false);
            this.crumbStrip.PerformLayout();
            this.searchHost.ResumeLayout(false);
            this.searchField.ResumeLayout(false);
            this.searchField.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
