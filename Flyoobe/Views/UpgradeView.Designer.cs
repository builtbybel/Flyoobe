namespace Flyoobe3.Views;

//draws the isolated upgrade page with plain anchored controls
partial class UpgradeView
{
    private System.ComponentModel.IContainer components = null!;
    private Label titleLabel = null!;
    private Label introLabel = null!;
    private ProgressBar progress = null!;
    private Label summaryLabel = null!;
    private ListView checksList = null!;
    private ColumnHeader checkColumn = null!;
    private ColumnHeader statusColumn = null!;
    private ColumnHeader detailsColumn = null!;
    private TextBox detailsBox = null!;
    private Panel footerPanel = null!;
    private Label footerSeparator = null!;
    private Button isoButton = null!;
    private Button downloadButton = null!;
    private Button windowsUpdateButton = null!;
    private Button checkButton = null!;
    private ContextMenuStrip isoMenu = null!;
    private ToolStripMenuItem standardIsoMenuItem = null!;
    private ToolStripMenuItem flybyIsoMenuItem = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.titleLabel = new System.Windows.Forms.Label();
            this.introLabel = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.checksList = new System.Windows.Forms.ListView();
            this.checkColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.detailsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.detailsBox = new System.Windows.Forms.TextBox();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.isoButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.windowsUpdateButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.footerSeparator = new System.Windows.Forms.Label();
            this.isoMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.standardIsoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flybyIsoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.footerPanel.SuspendLayout();
            this.isoMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.titleLabel.Location = new System.Drawing.Point(8, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(159, 21);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Windows 11 upgrade";
            // 
            // introLabel
            // 
            this.introLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.introLabel.Location = new System.Drawing.Point(8, 48);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(924, 38);
            this.introLabel.TabIndex = 2;
            this.introLabel.Text = "Check this PC first, then choose the official or Flyby11 ISO path.";
            this.introLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(0, 0);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(940, 12);
            this.progress.TabIndex = 3;
            // 
            // summaryLabel
            // 
            this.summaryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.summaryLabel.Location = new System.Drawing.Point(8, 114);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(924, 32);
            this.summaryLabel.TabIndex = 4;
            this.summaryLabel.Text = "Checking this PC...";
            this.summaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checksList
            // 
            this.checksList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checksList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.checkColumn,
            this.statusColumn,
            this.detailsColumn});
            this.checksList.FullRowSelect = true;
            this.checksList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.checksList.HideSelection = false;
            this.checksList.Location = new System.Drawing.Point(8, 150);
            this.checksList.MultiSelect = false;
            this.checksList.Name = "checksList";
            this.checksList.Size = new System.Drawing.Size(924, 282);
            this.checksList.TabIndex = 5;
            this.checksList.UseCompatibleStateImageBehavior = false;
            this.checksList.View = System.Windows.Forms.View.Details;
            this.checksList.SelectedIndexChanged += new System.EventHandler(this.ChecksList_SelectedIndexChanged);
            // 
            // checkColumn
            // 
            this.checkColumn.Text = "Check";
            this.checkColumn.Width = 240;
            // 
            // statusColumn
            // 
            this.statusColumn.Text = "Status";
            this.statusColumn.Width = 100;
            // 
            // detailsColumn
            // 
            this.detailsColumn.Text = "Details";
            this.detailsColumn.Width = 500;
            // 
            // detailsBox
            // 
            this.detailsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsBox.BackColor = System.Drawing.SystemColors.Window;
            this.detailsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsBox.Location = new System.Drawing.Point(8, 440);
            this.detailsBox.Multiline = true;
            this.detailsBox.Name = "detailsBox";
            this.detailsBox.ReadOnly = true;
            this.detailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detailsBox.Size = new System.Drawing.Size(924, 88);
            this.detailsBox.TabIndex = 6;
            this.detailsBox.TabStop = false;
            this.detailsBox.Text = "Select a check to see why it matters.";
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.footerPanel.Controls.Add(this.isoButton);
            this.footerPanel.Controls.Add(this.downloadButton);
            this.footerPanel.Controls.Add(this.windowsUpdateButton);
            this.footerPanel.Controls.Add(this.checkButton);
            this.footerPanel.Controls.Add(this.footerSeparator);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 534);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(940, 46);
            this.footerPanel.TabIndex = 7;
            // 
            // isoButton
            // 
            this.isoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.isoButton.Enabled = false;
            this.isoButton.Location = new System.Drawing.Point(770, 7);
            this.isoButton.Name = "isoButton";
            this.isoButton.Size = new System.Drawing.Size(162, 30);
            this.isoButton.TabIndex = 10;
            this.isoButton.Text = "Use ISO ▾";
            this.isoButton.Click += new System.EventHandler(this.IsoButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadButton.Location = new System.Drawing.Point(594, 7);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(170, 30);
            this.downloadButton.TabIndex = 9;
            this.downloadButton.Text = "Download Windows 11";
            this.downloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // windowsUpdateButton
            // 
            this.windowsUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.windowsUpdateButton.Location = new System.Drawing.Point(428, 7);
            this.windowsUpdateButton.Name = "windowsUpdateButton";
            this.windowsUpdateButton.Size = new System.Drawing.Size(160, 30);
            this.windowsUpdateButton.TabIndex = 8;
            this.windowsUpdateButton.Text = "Open Windows Update";
            this.windowsUpdateButton.Click += new System.EventHandler(this.WindowsUpdateButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkButton.Location = new System.Drawing.Point(302, 7);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(120, 30);
            this.checkButton.TabIndex = 7;
            this.checkButton.Text = "Check again";
            this.checkButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // footerSeparator
            // 
            this.footerSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.footerSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.footerSeparator.Location = new System.Drawing.Point(0, 0);
            this.footerSeparator.Name = "footerSeparator";
            this.footerSeparator.Size = new System.Drawing.Size(940, 1);
            this.footerSeparator.TabIndex = 11;
            // 
            // isoMenu
            // 
            this.isoMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardIsoMenuItem,
            this.flybyIsoMenuItem});
            this.isoMenu.Name = "isoMenu";
            this.isoMenu.Size = new System.Drawing.Size(224, 48);
            // 
            // standardIsoMenuItem
            // 
            this.standardIsoMenuItem.Name = "standardIsoMenuItem";
            this.standardIsoMenuItem.Size = new System.Drawing.Size(223, 22);
            this.standardIsoMenuItem.Text = "Standard Windows Setup...";
            this.standardIsoMenuItem.Click += new System.EventHandler(this.StandardIsoMenuItem_Click);
            // 
            // flybyIsoMenuItem
            // 
            this.flybyIsoMenuItem.Name = "flybyIsoMenuItem";
            this.flybyIsoMenuItem.Size = new System.Drawing.Size(223, 22);
            this.flybyIsoMenuItem.Text = "Flyby11 compatibility path...";
            this.flybyIsoMenuItem.Click += new System.EventHandler(this.FlybyIsoMenuItem_Click);
            // 
            // UpgradeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.detailsBox);
            this.Controls.Add(this.checksList);
            this.Controls.Add(this.summaryLabel);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.introLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "UpgradeView";
            this.Size = new System.Drawing.Size(940, 580);
            this.footerPanel.ResumeLayout(false);
            this.isoMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
