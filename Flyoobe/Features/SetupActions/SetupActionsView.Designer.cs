namespace Flyoobe3.Features.SetupActions;

partial class SetupActionsView
{
    private System.ComponentModel.IContainer components = null!;
    private Label titleLabel = null!;
    private Label introLabel = null!;
    private ListView actionList = null!;
    private ColumnHeader nameColumn = null!;
    private ColumnHeader phaseColumn = null!;
    private ColumnHeader adminColumn = null!;
    private ColumnHeader recipeColumn = null!;
    private TextBox detailsBox = null!;
    private Panel footerPanel = null!;
    private Label footerSeparator = null!;
    private Button runButton = null!;
    private Button importButton = null!;
    private Button openFolderButton = null!;
    private Label statusLabel = null!;
    private Label optionLabel = null!;
    private ComboBox optionBox = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.titleLabel = new System.Windows.Forms.Label();
            this.introLabel = new System.Windows.Forms.Label();
            this.actionList = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phaseColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.adminColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.recipeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.detailsBox = new System.Windows.Forms.TextBox();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.openFolderButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.footerSeparator = new System.Windows.Forms.Label();
            this.optionLabel = new System.Windows.Forms.Label();
            this.optionBox = new System.Windows.Forms.ComboBox();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.titleLabel.Location = new System.Drawing.Point(8, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(105, 21);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Setup Actions";
            // 
            // introLabel
            // 
            this.introLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.introLabel.Location = new System.Drawing.Point(8, 50);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(924, 36);
            this.introLabel.TabIndex = 2;
            this.introLabel.Text = "Local finishing steps. Nothing runs until you confirm it.";
            // 
            // actionList
            // 
            this.actionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.phaseColumn,
            this.adminColumn,
            this.recipeColumn});
            this.actionList.FullRowSelect = true;
            this.actionList.HideSelection = false;
            this.actionList.Location = new System.Drawing.Point(8, 88);
            this.actionList.MultiSelect = false;
            this.actionList.Name = "actionList";
            this.actionList.Size = new System.Drawing.Size(924, 238);
            this.actionList.TabIndex = 3;
            this.actionList.UseCompatibleStateImageBehavior = false;
            this.actionList.View = System.Windows.Forms.View.Details;
            this.actionList.SelectedIndexChanged += new System.EventHandler(this.ActionList_SelectedIndexChanged);
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Action";
            this.nameColumn.Width = 430;
            // 
            // phaseColumn
            // 
            this.phaseColumn.Text = "Phase";
            this.phaseColumn.Width = 140;
            // 
            // adminColumn
            // 
            this.adminColumn.Text = "Administrator";
            this.adminColumn.Width = 130;
            // 
            // recipeColumn
            // 
            this.recipeColumn.Text = "Recipe";
            this.recipeColumn.Width = 130;
            // 
            // detailsBox
            // 
            this.detailsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsBox.BackColor = System.Drawing.SystemColors.Window;
            this.detailsBox.Location = new System.Drawing.Point(8, 336);
            this.detailsBox.Multiline = true;
            this.detailsBox.Name = "detailsBox";
            this.detailsBox.ReadOnly = true;
            this.detailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detailsBox.Size = new System.Drawing.Size(924, 107);
            this.detailsBox.TabIndex = 4;
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.footerPanel.Controls.Add(this.statusLabel);
            this.footerPanel.Controls.Add(this.openFolderButton);
            this.footerPanel.Controls.Add(this.importButton);
            this.footerPanel.Controls.Add(this.runButton);
            this.footerPanel.Controls.Add(this.footerSeparator);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 482);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(940, 48);
            this.footerPanel.TabIndex = 7;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.AutoEllipsis = true;
            this.statusLabel.Location = new System.Drawing.Point(466, 15);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(466, 20);
            this.statusLabel.TabIndex = 10;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openFolderButton
            // 
            this.openFolderButton.Location = new System.Drawing.Point(296, 9);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(160, 30);
            this.openFolderButton.TabIndex = 9;
            this.openFolderButton.Text = "Open Actions folder";
            this.openFolderButton.UseVisualStyleBackColor = true;
            this.openFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(158, 9);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(130, 30);
            this.importButton.TabIndex = 8;
            this.importButton.Text = "Import action...";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // runButton
            // 
            this.runButton.Enabled = false;
            this.runButton.Location = new System.Drawing.Point(8, 9);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(142, 30);
            this.runButton.TabIndex = 7;
            this.runButton.Text = "Run selected";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.RunButton_Click);
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
            // optionLabel
            // 
            this.optionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.optionLabel.Location = new System.Drawing.Point(8, 453);
            this.optionLabel.Name = "optionLabel";
            this.optionLabel.Size = new System.Drawing.Size(92, 23);
            this.optionLabel.TabIndex = 5;
            this.optionLabel.Text = "Option:";
            this.optionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // optionBox
            // 
            this.optionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optionBox.FormattingEnabled = true;
            this.optionBox.Location = new System.Drawing.Point(106, 453);
            this.optionBox.Name = "optionBox";
            this.optionBox.Size = new System.Drawing.Size(826, 23);
            this.optionBox.TabIndex = 6;
            this.optionBox.SelectedIndexChanged += new System.EventHandler(this.OptionBox_SelectedIndexChanged);
            // 
            // SetupActionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.optionBox);
            this.Controls.Add(this.optionLabel);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.detailsBox);
            this.Controls.Add(this.actionList);
            this.Controls.Add(this.introLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "SetupActionsView";
            this.Size = new System.Drawing.Size(940, 530);
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
