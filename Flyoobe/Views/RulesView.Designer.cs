namespace Flyoobe3.Views;

//draws one tweak category with a normal anchored list and buttons
partial class RulesView
{
    private System.ComponentModel.IContainer components = null!;
    private Label titleLabel = null!;
    private Label statusLabel = null!;
    private ListView rulesList = null!;
    private ColumnHeader choiceColumn = null!;
    private ColumnHeader statusColumn = null!;
    private ColumnHeader currentColumn = null!;
    private ContextMenuStrip ruleMenu = null!;
    private ToolStripMenuItem applyRuleMenuItem = null!;
    private ToolStripMenuItem restoreRuleMenuItem = null!;
    private ToolStripMenuItem explainRuleMenuItem = null!;
    private ToolStripSeparator menuSeparator = null!;
    private ToolStripMenuItem selectAllMenuItem = null!;
    private ToolStripMenuItem clearAllMenuItem = null!;
    private TextBox detailsBox = null!;
    private Panel footerPanel = null!;
    private Label footerSeparator = null!;
    private Button checkButton = null!;
    private Button applyButton = null!;
    private Button restoreButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.titleLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.rulesList = new System.Windows.Forms.ListView();
            this.choiceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currentColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ruleMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.applyRuleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreRuleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explainRuleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsBox = new System.Windows.Forms.TextBox();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.checkButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.restoreButton = new System.Windows.Forms.Button();
            this.footerSeparator = new System.Windows.Forms.Label();
            this.ruleMenu.SuspendLayout();
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
            this.titleLabel.Size = new System.Drawing.Size(130, 21);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Windows choices";
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
            this.statusLabel.Text = "Checking...";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rulesList
            // 
            this.rulesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rulesList.CheckBoxes = true;
            this.rulesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.choiceColumn,
            this.statusColumn,
            this.currentColumn});
            this.rulesList.ContextMenuStrip = this.ruleMenu;
            this.rulesList.FullRowSelect = true;
            this.rulesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.rulesList.HideSelection = false;
            this.rulesList.Location = new System.Drawing.Point(8, 74);
            this.rulesList.MultiSelect = false;
            this.rulesList.Name = "rulesList";
            this.rulesList.Size = new System.Drawing.Size(924, 356);
            this.rulesList.TabIndex = 3;
            this.rulesList.UseCompatibleStateImageBehavior = false;
            this.rulesList.View = System.Windows.Forms.View.Details;
            this.rulesList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.RulesList_ItemChecked);
            this.rulesList.SelectedIndexChanged += new System.EventHandler(this.RulesList_SelectedIndexChanged);
            this.rulesList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RulesList_MouseDown);
            // 
            // choiceColumn
            // 
            this.choiceColumn.Text = "Choice";
            this.choiceColumn.Width = 500;
            // 
            // statusColumn
            // 
            this.statusColumn.Text = "Status";
            this.statusColumn.Width = 100;
            // 
            // currentColumn
            // 
            this.currentColumn.Text = "Current";
            this.currentColumn.Width = 250;
            // 
            // ruleMenu
            // 
            this.ruleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applyRuleMenuItem,
            this.restoreRuleMenuItem,
            this.explainRuleMenuItem,
            this.menuSeparator,
            this.selectAllMenuItem,
            this.clearAllMenuItem});
            this.ruleMenu.Name = "ruleMenu";
            this.ruleMenu.Size = new System.Drawing.Size(206, 120);
            this.ruleMenu.Opening += new System.ComponentModel.CancelEventHandler(this.RuleMenu_Opening);
            // 
            // applyRuleMenuItem
            // 
            this.applyRuleMenuItem.Name = "applyRuleMenuItem";
            this.applyRuleMenuItem.Size = new System.Drawing.Size(205, 22);
            this.applyRuleMenuItem.Text = "Apply this choice";
            this.applyRuleMenuItem.Click += new System.EventHandler(this.ApplyRuleMenuItem_Click);
            // 
            // restoreRuleMenuItem
            // 
            this.restoreRuleMenuItem.Name = "restoreRuleMenuItem";
            this.restoreRuleMenuItem.Size = new System.Drawing.Size(205, 22);
            this.restoreRuleMenuItem.Text = "Restore Windows default";
            this.restoreRuleMenuItem.Click += new System.EventHandler(this.RestoreRuleMenuItem_Click);
            // 
            // explainRuleMenuItem
            // 
            this.explainRuleMenuItem.Name = "explainRuleMenuItem";
            this.explainRuleMenuItem.Size = new System.Drawing.Size(205, 22);
            this.explainRuleMenuItem.Text = "Explain with AI";
            this.explainRuleMenuItem.Click += new System.EventHandler(this.ExplainRuleMenuItem_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(202, 6);
            // 
            // selectAllMenuItem
            // 
            this.selectAllMenuItem.Name = "selectAllMenuItem";
            this.selectAllMenuItem.Size = new System.Drawing.Size(205, 22);
            this.selectAllMenuItem.Text = "Select all";
            this.selectAllMenuItem.Click += new System.EventHandler(this.SelectAllMenuItem_Click);
            // 
            // clearAllMenuItem
            // 
            this.clearAllMenuItem.Name = "clearAllMenuItem";
            this.clearAllMenuItem.Size = new System.Drawing.Size(205, 22);
            this.clearAllMenuItem.Text = "Clear selection";
            this.clearAllMenuItem.Click += new System.EventHandler(this.ClearAllMenuItem_Click);
            // 
            // detailsBox
            // 
            this.detailsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsBox.BackColor = System.Drawing.SystemColors.Window;
            this.detailsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsBox.Location = new System.Drawing.Point(8, 438);
            this.detailsBox.Multiline = true;
            this.detailsBox.Name = "detailsBox";
            this.detailsBox.ReadOnly = true;
            this.detailsBox.Size = new System.Drawing.Size(924, 88);
            this.detailsBox.TabIndex = 4;
            this.detailsBox.TabStop = false;
            this.detailsBox.Text = "Select a choice to see what it does.";
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.footerPanel.Controls.Add(this.checkButton);
            this.footerPanel.Controls.Add(this.applyButton);
            this.footerPanel.Controls.Add(this.restoreButton);
            this.footerPanel.Controls.Add(this.footerSeparator);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 534);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(940, 46);
            this.footerPanel.TabIndex = 5;
            // 
            // checkButton
            // 
            this.checkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkButton.AutoEllipsis = true;
            this.checkButton.Location = new System.Drawing.Point(802, 7);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(130, 30);
            this.checkButton.TabIndex = 7;
            this.checkButton.Text = "Check again";
            this.checkButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.AutoEllipsis = true;
            this.applyButton.Location = new System.Drawing.Point(666, 7);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(130, 30);
            this.applyButton.TabIndex = 6;
            this.applyButton.Text = "Apply selected";
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // restoreButton
            // 
            this.restoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreButton.AutoEllipsis = true;
            this.restoreButton.Location = new System.Drawing.Point(466, 7);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(194, 30);
            this.restoreButton.TabIndex = 5;
            this.restoreButton.Text = "Restore defaults";
            this.restoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
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
            // RulesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.detailsBox);
            this.Controls.Add(this.rulesList);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "RulesView";
            this.Size = new System.Drawing.Size(940, 580);
            this.ruleMenu.ResumeLayout(false);
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
