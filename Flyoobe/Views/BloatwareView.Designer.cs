namespace Flyoobe3.Views;

//draws the preinstalled app check with a normal anchored list
partial class BloatwareView
{
    private System.ComponentModel.IContainer components = null!;
    private Label titleLabel = null!;
    private Label statusLabel = null!;
    private ProgressBar progressBar = null!;
    private ListView appsList = null!;
    private ContextMenuStrip listMenu = null!;
    private ToolStripMenuItem selectAllMenuItem = null!;
    private ToolStripMenuItem clearAllMenuItem = null!;
    private ColumnHeader appColumn = null!;
    private ColumnHeader categoryColumn = null!;
    private ColumnHeader statusColumn = null!;
    private TextBox detailsBox = null!;
    private Panel footerPanel = null!;
    private Label footerSeparator = null!;
    private Button scanButton = null!;
    private Button removeButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.titleLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.components = new System.ComponentModel.Container();
            this.appsList = new System.Windows.Forms.ListView();
            this.listMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.detailsBox = new System.Windows.Forms.TextBox();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.removeButton = new System.Windows.Forms.Button();
            this.scanButton = new System.Windows.Forms.Button();
            this.footerSeparator = new System.Windows.Forms.Label();
            this.footerPanel.SuspendLayout();
            this.listMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.titleLabel.Location = new System.Drawing.Point(8, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(189, 21);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Remove preinstalled apps";
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusLabel.Location = new System.Drawing.Point(8, 44);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(924, 26);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Ready to check which preinstalled apps are actually present.";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.MarqueeAnimationSpeed = 24;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(940, 8);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 3;
            this.progressBar.Visible = false;
            // 
            // appsList
            // 
            this.appsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appsList.CheckBoxes = true;
            this.appsList.ContextMenuStrip = this.listMenu;
            this.appsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.appColumn,
            this.categoryColumn,
            this.statusColumn});
            this.appsList.FullRowSelect = true;
            this.appsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.appsList.HideSelection = false;
            this.appsList.Location = new System.Drawing.Point(8, 84);
            this.appsList.MultiSelect = false;
            this.appsList.Name = "appsList";
            this.appsList.Size = new System.Drawing.Size(924, 350);
            this.appsList.TabIndex = 4;
            this.appsList.UseCompatibleStateImageBehavior = false;
            this.appsList.View = System.Windows.Forms.View.Details;
            //
            // listMenu
            //
            this.listMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllMenuItem,
            this.clearAllMenuItem});
            this.listMenu.Name = "listMenu";
            this.listMenu.Size = new System.Drawing.Size(181, 48);
            //
            // selectAllMenuItem
            //
            this.selectAllMenuItem.Name = "selectAllMenuItem";
            this.selectAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectAllMenuItem.Text = "Select all installed";
            //
            // clearAllMenuItem
            //
            this.clearAllMenuItem.Name = "clearAllMenuItem";
            this.clearAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearAllMenuItem.Text = "Clear selection";
            //
            // appColumn
            //
            this.appColumn.Text = "App";
            this.appColumn.Width = 360;
            // 
            // categoryColumn
            // 
            this.categoryColumn.Text = "Category";
            this.categoryColumn.Width = 200;
            // 
            // statusColumn
            // 
            this.statusColumn.Text = "Status";
            this.statusColumn.Width = 140;
            // 
            // detailsBox
            // 
            this.detailsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsBox.BackColor = System.Drawing.SystemColors.Window;
            this.detailsBox.Location = new System.Drawing.Point(8, 442);
            this.detailsBox.Multiline = true;
            this.detailsBox.Name = "detailsBox";
            this.detailsBox.ReadOnly = true;
            this.detailsBox.Size = new System.Drawing.Size(924, 88);
            this.detailsBox.TabIndex = 5;
            this.detailsBox.TabStop = false;
            this.detailsBox.Text = "Select an app to see why it is listed.";
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.footerPanel.Controls.Add(this.removeButton);
            this.footerPanel.Controls.Add(this.scanButton);
            this.footerPanel.Controls.Add(this.footerSeparator);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 534);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(940, 46);
            this.footerPanel.TabIndex = 6;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(792, 7);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(140, 30);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Remove selected";
            // 
            // scanButton
            // 
            this.scanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scanButton.Location = new System.Drawing.Point(666, 7);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(120, 30);
            this.scanButton.TabIndex = 6;
            this.scanButton.Text = "Check again";
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
            // BloatwareView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.detailsBox);
            this.Controls.Add(this.appsList);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "BloatwareView";
            this.Size = new System.Drawing.Size(940, 580);
            this.footerPanel.ResumeLayout(false);
            this.listMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
