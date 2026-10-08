namespace Flyoobe3.Views;

//draws the app catalog with a plain anchored list
partial class AppsView
{
    private System.ComponentModel.IContainer components = null!;
    private Label titleLabel = null!;
    private Label categoryLabel = null!;
    private ComboBox categoryBox = null!;
    private Label statusLabel = null!;
    private ProgressBar progressBar = null!;
    private ListView appsList = null!;
    private ContextMenuStrip listMenu = null!;
    private ToolStripMenuItem selectAllMenuItem = null!;
    private ToolStripMenuItem clearAllMenuItem = null!;
    private ColumnHeader appColumn = null!;
    private ColumnHeader categoryColumn = null!;
    private ColumnHeader wingetColumn = null!;
    private ColumnHeader installedColumn = null!;
    private TextBox detailsBox = null!;
    private Panel footerPanel = null!;
    private Label footerSeparator = null!;
    private Button scanButton = null!;
    private Button installButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.titleLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryBox = new System.Windows.Forms.ComboBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.appsList = new System.Windows.Forms.ListView();
            this.listMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appColumn =((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wingetColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.installedColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.detailsBox = new System.Windows.Forms.TextBox();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.installButton = new System.Windows.Forms.Button();
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
            this.titleLabel.Size = new System.Drawing.Size(88, 21);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Install apps";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(250, 16);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(58, 15);
            this.categoryLabel.TabIndex = 2;
            this.categoryLabel.Text = "Category:";
            // 
            // categoryBox
            // 
            this.categoryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryBox.FormattingEnabled = true;
            this.categoryBox.Location = new System.Drawing.Point(316, 12);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(190, 23);
            this.categoryBox.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusLabel.Location = new System.Drawing.Point(8, 44);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(924, 26);
            this.statusLabel.TabIndex = 6;
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
            this.progressBar.TabIndex = 7;
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
            this.wingetColumn,
            this.installedColumn});
            this.appsList.FullRowSelect = true;
            this.appsList.HideSelection = false;
            this.appsList.Location = new System.Drawing.Point(8, 84);
            this.appsList.MultiSelect = false;
            this.appsList.Name = "appsList";
            this.appsList.Size = new System.Drawing.Size(924, 350);
            this.appsList.TabIndex = 8;
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
            this.selectAllMenuItem.Text = "Select all";
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
            this.appColumn.Width = 300;
            // 
            // categoryColumn
            // 
            this.categoryColumn.Text = "Category";
            this.categoryColumn.Width = 180;
            // 
            // wingetColumn
            // 
            this.wingetColumn.Text = "winget ID";
            this.wingetColumn.Width = 260;
            // 
            // installedColumn
            // 
            this.installedColumn.Text = "Status";
            this.installedColumn.Width = 120;
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
            this.detailsBox.TabIndex = 9;
            this.detailsBox.TabStop = false;
            this.detailsBox.Text = "Select an app to see its catalog details.";
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.footerPanel.Controls.Add(this.installButton);
            this.footerPanel.Controls.Add(this.scanButton);
            this.footerPanel.Controls.Add(this.footerSeparator);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 534);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(940, 46);
            this.footerPanel.TabIndex = 10;
            // 
            // installButton
            // 
            this.installButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.installButton.Location = new System.Drawing.Point(792, 7);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(140, 30);
            this.installButton.TabIndex = 11;
            this.installButton.Text = "Install selected";
            // 
            // scanButton
            // 
            this.scanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scanButton.Location = new System.Drawing.Point(646, 7);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(138, 30);
            this.scanButton.TabIndex = 10;
            this.scanButton.Text = "Check installed";
            // 
            // footerSeparator
            // 
            this.footerSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.footerSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.footerSeparator.Location = new System.Drawing.Point(0, 0);
            this.footerSeparator.Name = "footerSeparator";
            this.footerSeparator.Size = new System.Drawing.Size(940, 1);
            this.footerSeparator.TabIndex = 12;
            // 
            // AppsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.detailsBox);
            this.Controls.Add(this.appsList);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "AppsView";
            this.Size = new System.Drawing.Size(940, 580);
            this.footerPanel.ResumeLayout(false);
            this.listMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
