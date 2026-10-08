namespace Flyoobe3.Views;

//plain anchored controls keep this export window easy to edit in the designer
partial class RecipeExportDialog
{
    private System.ComponentModel.IContainer components = null!;
    private Label introLabel = null!;
    private GroupBox preferencesGroup = null!;
    private CheckedListBox preferenceList = null!;
    private GroupBox appsGroup = null!;
    private CheckedListBox appList = null!;
    private GroupBox bloatwareGroup = null!;
    private CheckedListBox bloatwareList = null!;
    private GroupBox actionsGroup = null!;
    private CheckedListBox actionList = null!;
    private ContextMenuStrip listMenu = null!;
    private ToolStripMenuItem selectAllMenuItem = null!;
    private ToolStripMenuItem clearAllMenuItem = null!;
    private Button exportButton = null!;
    private Button cancelButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.introLabel = new System.Windows.Forms.Label();
            this.preferencesGroup = new System.Windows.Forms.GroupBox();
            this.preferenceList = new System.Windows.Forms.CheckedListBox();
            this.appsGroup = new System.Windows.Forms.GroupBox();
            this.appList = new System.Windows.Forms.CheckedListBox();
            this.listMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloatwareGroup = new System.Windows.Forms.GroupBox();
            this.bloatwareList = new System.Windows.Forms.CheckedListBox();
            this.actionsGroup = new System.Windows.Forms.GroupBox();
            this.actionList = new System.Windows.Forms.CheckedListBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.preferencesGroup.SuspendLayout();
            this.appsGroup.SuspendLayout();
            this.listMenu.SuspendLayout();
            this.bloatwareGroup.SuspendLayout();
            this.actionsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // introLabel
            // 
            this.introLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.introLabel.Location = new System.Drawing.Point(12, 12);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(736, 38);
            this.introLabel.TabIndex = 0;
            this.introLabel.Text = "Windows recommendations are read automatically. Choose the personal settings and " +
    "app actions this recipe should also reproduce.";
            // 
            // preferencesGroup
            // 
            this.preferencesGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preferencesGroup.Controls.Add(this.preferenceList);
            this.preferencesGroup.Location = new System.Drawing.Point(12, 54);
            this.preferencesGroup.Name = "preferencesGroup";
            this.preferencesGroup.Size = new System.Drawing.Size(736, 126);
            this.preferencesGroup.TabIndex = 1;
            this.preferencesGroup.TabStop = false;
            this.preferencesGroup.Text = "Personal settings";
            // 
            // preferenceList
            // 
            this.preferenceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preferenceList.CheckOnClick = true;
            this.preferenceList.FormattingEnabled = true;
            this.preferenceList.IntegralHeight = false;
            this.preferenceList.Location = new System.Drawing.Point(10, 22);
            this.preferenceList.Name = "preferenceList";
            this.preferenceList.Size = new System.Drawing.Size(716, 94);
            this.preferenceList.TabIndex = 0;
            // 
            // appsGroup
            // 
            this.appsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.appsGroup.Controls.Add(this.appList);
            this.appsGroup.Location = new System.Drawing.Point(12, 306);
            this.appsGroup.Name = "appsGroup";
            this.appsGroup.Size = new System.Drawing.Size(362, 310);
            this.appsGroup.TabIndex = 2;
            this.appsGroup.TabStop = false;
            this.appsGroup.Text = "Apps to install";
            // 
            // appList
            // 
            this.appList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appList.CheckOnClick = true;
            this.appList.ContextMenuStrip = this.listMenu;
            this.appList.FormattingEnabled = true;
            this.appList.IntegralHeight = false;
            this.appList.Location = new System.Drawing.Point(10, 22);
            this.appList.Name = "appList";
            this.appList.Size = new System.Drawing.Size(342, 278);
            this.appList.Sorted = true;
            this.appList.TabIndex = 0;
            // 
            // listMenu
            // 
            this.listMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllMenuItem,
            this.clearAllMenuItem});
            this.listMenu.Name = "listMenu";
            this.listMenu.Size = new System.Drawing.Size(121, 48);
            // 
            // selectAllMenuItem
            // 
            this.selectAllMenuItem.Name = "selectAllMenuItem";
            this.selectAllMenuItem.Size = new System.Drawing.Size(120, 22);
            this.selectAllMenuItem.Text = "Select all";
            // 
            // clearAllMenuItem
            // 
            this.clearAllMenuItem.Name = "clearAllMenuItem";
            this.clearAllMenuItem.Size = new System.Drawing.Size(120, 22);
            this.clearAllMenuItem.Text = "Clear all";
            // 
            // bloatwareGroup
            // 
            this.bloatwareGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bloatwareGroup.Controls.Add(this.bloatwareList);
            this.bloatwareGroup.Location = new System.Drawing.Point(386, 306);
            this.bloatwareGroup.Name = "bloatwareGroup";
            this.bloatwareGroup.Size = new System.Drawing.Size(362, 310);
            this.bloatwareGroup.TabIndex = 3;
            this.bloatwareGroup.TabStop = false;
            this.bloatwareGroup.Text = "Preinstalled apps to remove";
            // 
            // bloatwareList
            // 
            this.bloatwareList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bloatwareList.CheckOnClick = true;
            this.bloatwareList.ContextMenuStrip = this.listMenu;
            this.bloatwareList.FormattingEnabled = true;
            this.bloatwareList.IntegralHeight = false;
            this.bloatwareList.Location = new System.Drawing.Point(10, 22);
            this.bloatwareList.Name = "bloatwareList";
            this.bloatwareList.Size = new System.Drawing.Size(342, 278);
            this.bloatwareList.Sorted = true;
            this.bloatwareList.TabIndex = 0;
            // 
            // actionsGroup
            // 
            this.actionsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.actionsGroup.Controls.Add(this.actionList);
            this.actionsGroup.Location = new System.Drawing.Point(12, 188);
            this.actionsGroup.Name = "actionsGroup";
            this.actionsGroup.Size = new System.Drawing.Size(736, 110);
            this.actionsGroup.TabIndex = 2;
            this.actionsGroup.TabStop = false;
            this.actionsGroup.Text = "Setup Actions";
            // 
            // actionList
            // 
            this.actionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.actionList.CheckOnClick = true;
            this.actionList.ContextMenuStrip = this.listMenu;
            this.actionList.FormattingEnabled = true;
            this.actionList.IntegralHeight = false;
            this.actionList.Location = new System.Drawing.Point(10, 22);
            this.actionList.Name = "actionList";
            this.actionList.Size = new System.Drawing.Size(716, 78);
            this.actionList.Sorted = true;
            this.actionList.TabIndex = 0;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.AutoEllipsis = true;
            this.exportButton.Location = new System.Drawing.Point(503, 628);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(137, 30);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "Export recipe";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(648, 628);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // RecipeExportDialog
            // 
            this.AcceptButton = this.exportButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(760, 670);
            this.Controls.Add(this.introLabel);
            this.Controls.Add(this.preferencesGroup);
            this.Controls.Add(this.actionsGroup);
            this.Controls.Add(this.appsGroup);
            this.Controls.Add(this.bloatwareGroup);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.cancelButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(690, 480);
            this.Name = "RecipeExportDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create setup recipe";
            this.preferencesGroup.ResumeLayout(false);
            this.appsGroup.ResumeLayout(false);
            this.listMenu.ResumeLayout(false);
            this.bloatwareGroup.ResumeLayout(false);
            this.actionsGroup.ResumeLayout(false);
            this.ResumeLayout(false);

    }
}
