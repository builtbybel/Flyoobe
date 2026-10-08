namespace Flyoobe3.Views;

//uses one outer grid so the overview stack survives dpi and window resizing
partial class OverviewView
{
    private System.ComponentModel.IContainer components = null!;
    private TableLayoutPanel layout = null!;
    private Label introTitleLabel = null!;
    private Label introLabel = null!;
    private Panel recipeBanner = null!;
    private Label recipeBannerLabel = null!;
    private Button discardRecipeButton = null!;
    private ProgressBar progress = null!;
    private Label summaryLabel = null!;
    private SplitContainer detailSplit = null!;
    private TreeView setupTree = null!;
    private TableLayoutPanel detailPane = null!;
    private Label detailsLabel = null!;
    private Label tipHeading = null!;
    private LinkLabel detailLink = null!;
    private Panel actionPanel = null!;
    private Label actionSeparator = null!;
    private Button scanButton = null!;
    private Button configureButton = null!;
    private Button recipeButton = null!;
    private Button applyRecipeButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.introTitleLabel = new System.Windows.Forms.Label();
            this.introLabel = new System.Windows.Forms.Label();
            this.recipeBanner = new System.Windows.Forms.Panel();
            this.recipeBannerLabel = new System.Windows.Forms.Label();
            this.discardRecipeButton = new System.Windows.Forms.Button();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.detailSplit = new System.Windows.Forms.SplitContainer();
            this.setupTree = new System.Windows.Forms.TreeView();
            this.detailPane = new System.Windows.Forms.TableLayoutPanel();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.tipHeading = new System.Windows.Forms.Label();
            this.detailLink = new System.Windows.Forms.LinkLabel();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.scanButton = new System.Windows.Forms.Button();
            this.configureButton = new System.Windows.Forms.Button();
            this.recipeButton = new System.Windows.Forms.Button();
            this.applyRecipeButton = new System.Windows.Forms.Button();
            this.actionSeparator = new System.Windows.Forms.Label();
            this.layout.SuspendLayout();
            this.recipeBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailSplit)).BeginInit();
            this.detailSplit.Panel1.SuspendLayout();
            this.detailSplit.Panel2.SuspendLayout();
            this.detailSplit.SuspendLayout();
            this.detailPane.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.BackColor = System.Drawing.SystemColors.Window;
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.Controls.Add(this.progress, 0, 0);
            this.layout.Controls.Add(this.introTitleLabel, 0, 1);
            this.layout.Controls.Add(this.introLabel, 0, 2);
            this.layout.Controls.Add(this.recipeBanner, 0, 3);
            this.layout.Controls.Add(this.summaryLabel, 0, 4);
            this.layout.Controls.Add(this.detailSplit, 0, 5);
            this.layout.Controls.Add(this.actionPanel, 0, 6);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Name = "layout";
            this.layout.RowCount = 7;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.Size = new System.Drawing.Size(940, 580);
            this.layout.TabIndex = 0;
            // 
            // progress
            // 
            this.progress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progress.Location = new System.Drawing.Point(0, 0);
            this.progress.Margin = new System.Windows.Forms.Padding(0);
            this.progress.MinimumSize = new System.Drawing.Size(0, 12);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(940, 12);
            this.progress.TabIndex = 2;
            // 
            // introTitleLabel
            // 
            this.introTitleLabel.AutoSize = true;
            this.introTitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.introTitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.introTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.introTitleLabel.Location = new System.Drawing.Point(10, 20);
            this.introTitleLabel.Margin = new System.Windows.Forms.Padding(10, 8, 8, 2);
            this.introTitleLabel.MinimumSize = new System.Drawing.Size(0, 25);
            this.introTitleLabel.Name = "introTitleLabel";
            this.introTitleLabel.Size = new System.Drawing.Size(922, 25);
            this.introTitleLabel.TabIndex = 0;
            this.introTitleLabel.Text = "Set up Windows";
            this.introTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // introLabel
            // 
            this.introLabel.AutoSize = true;
            this.introLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.introLabel.Location = new System.Drawing.Point(10, 47);
            this.introLabel.Margin = new System.Windows.Forms.Padding(10, 0, 8, 10);
            this.introLabel.MinimumSize = new System.Drawing.Size(0, 22);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(922, 22);
            this.introLabel.TabIndex = 1;
            this.introLabel.Text = "Choose only what matters. Red marks a difference; personal choices are never rate" +
    "d.";
            this.introLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // recipeBanner
            // 
            this.recipeBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.recipeBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recipeBanner.Controls.Add(this.recipeBannerLabel);
            this.recipeBanner.Controls.Add(this.discardRecipeButton);
            this.recipeBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipeBanner.Location = new System.Drawing.Point(8, 79);
            this.recipeBanner.Margin = new System.Windows.Forms.Padding(8, 0, 8, 6);
            this.recipeBanner.MinimumSize = new System.Drawing.Size(2, 48);
            this.recipeBanner.Name = "recipeBanner";
            this.recipeBanner.Size = new System.Drawing.Size(924, 48);
            this.recipeBanner.TabIndex = 1;
            this.recipeBanner.Visible = false;
            // 
            // recipeBannerLabel
            // 
            this.recipeBannerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recipeBannerLabel.AutoEllipsis = true;
            this.recipeBannerLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.recipeBannerLabel.Location = new System.Drawing.Point(10, 3);
            this.recipeBannerLabel.Name = "recipeBannerLabel";
            this.recipeBannerLabel.Size = new System.Drawing.Size(770, 40);
            this.recipeBannerLabel.TabIndex = 0;
            this.recipeBannerLabel.Text = "Recipe loaded — review mode";
            this.recipeBannerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // discardRecipeButton
            // 
            this.discardRecipeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discardRecipeButton.Location = new System.Drawing.Point(788, 8);
            this.discardRecipeButton.Name = "discardRecipeButton";
            this.discardRecipeButton.Size = new System.Drawing.Size(126, 30);
            this.discardRecipeButton.TabIndex = 1;
            this.discardRecipeButton.Text = "Discard recipe";
            this.discardRecipeButton.Click += new System.EventHandler(this.DiscardRecipeButton_Click);
            // 
            // summaryLabel
            // 
            this.summaryLabel.AutoSize = true;
            this.summaryLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.summaryLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.summaryLabel.Location = new System.Drawing.Point(8, 138);
            this.summaryLabel.Margin = new System.Windows.Forms.Padding(8, 5, 8, 6);
            this.summaryLabel.MinimumSize = new System.Drawing.Size(0, 24);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(924, 24);
            this.summaryLabel.TabIndex = 3;
            this.summaryLabel.Text = "Ready to check the recommendations. Preferences are not rated.";
            this.summaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // detailSplit
            // 
            this.detailSplit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.detailSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.detailSplit.Location = new System.Drawing.Point(8, 168);
            this.detailSplit.Margin = new System.Windows.Forms.Padding(8, 0, 8, 10);
            this.detailSplit.Name = "detailSplit";
            // 
            // detailSplit.Panel1
            // 
            this.detailSplit.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.detailSplit.Panel1.Controls.Add(this.setupTree);
            this.detailSplit.Panel1MinSize = 320;
            // 
            // detailSplit.Panel2
            // 
            this.detailSplit.Panel2.BackColor = System.Drawing.Color.White;
            this.detailSplit.Panel2.Controls.Add(this.detailPane);
            this.detailSplit.Panel2.Padding = new System.Windows.Forms.Padding(10, 8, 8, 8);
            this.detailSplit.Panel2MinSize = 180;
            this.detailSplit.Size = new System.Drawing.Size(924, 348);
            this.detailSplit.SplitterDistance = 732;
            this.detailSplit.SplitterWidth = 2;
            this.detailSplit.TabIndex = 4;
            // 
            // setupTree
            // 
            this.setupTree.BackColor = System.Drawing.SystemColors.Window;
            this.setupTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.setupTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupTree.FullRowSelect = true;
            this.setupTree.HideSelection = false;
            this.setupTree.HotTracking = true;
            this.setupTree.Indent = 22;
            this.setupTree.ItemHeight = 22;
            this.setupTree.Location = new System.Drawing.Point(0, 0);
            this.setupTree.Margin = new System.Windows.Forms.Padding(0);
            this.setupTree.Name = "setupTree";
            this.setupTree.ShowLines = false;
            this.setupTree.Size = new System.Drawing.Size(732, 348);
            this.setupTree.TabIndex = 0;
            this.setupTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SetupTree_AfterSelect);
            this.setupTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SetupTree_NodeMouseDoubleClick);
            // 
            // detailPane
            // 
            this.detailPane.AutoSize = true;
            this.detailPane.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.detailPane.ColumnCount = 1;
            this.detailPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detailPane.Controls.Add(this.detailsLabel, 0, 0);
            this.detailPane.Controls.Add(this.tipHeading, 0, 1);
            this.detailPane.Controls.Add(this.detailLink, 0, 2);
            this.detailPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.detailPane.Location = new System.Drawing.Point(10, 8);
            this.detailPane.Margin = new System.Windows.Forms.Padding(0);
            this.detailPane.Name = "detailPane";
            this.detailPane.RowCount = 3;
            this.detailPane.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.detailPane.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.detailPane.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.detailPane.Size = new System.Drawing.Size(172, 76);
            this.detailPane.TabIndex = 0;
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsLabel.Location = new System.Drawing.Point(0, 0);
            this.detailsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(172, 30);
            this.detailsLabel.TabIndex = 0;
            this.detailsLabel.Text = "Select a setup area to see what Flyoobe found.";
            // 
            // tipHeading
            // 
            this.tipHeading.AutoSize = true;
            this.tipHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tipHeading.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipHeading.Location = new System.Drawing.Point(0, 30);
            this.tipHeading.Margin = new System.Windows.Forms.Padding(0);
            this.tipHeading.Name = "tipHeading";
            this.tipHeading.Padding = new System.Windows.Forms.Padding(0, 14, 0, 2);
            this.tipHeading.Size = new System.Drawing.Size(172, 31);
            this.tipHeading.TabIndex = 1;
            this.tipHeading.Text = "More options";
            // 
            // detailLink
            // 
            this.detailLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.detailLink.AutoSize = true;
            this.detailLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.detailLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.detailLink.Location = new System.Drawing.Point(0, 61);
            this.detailLink.Margin = new System.Windows.Forms.Padding(0);
            this.detailLink.Name = "detailLink";
            this.detailLink.Size = new System.Drawing.Size(172, 15);
            this.detailLink.TabIndex = 1;
            this.detailLink.TabStop = true;
            this.detailLink.Text = "More options in Settings";
            this.detailLink.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.detailLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DetailLink_LinkClicked);
            // 
            // actionPanel
            // 
            this.actionPanel.BackColor = System.Drawing.SystemColors.Control;
            this.actionPanel.Controls.Add(this.scanButton);
            this.actionPanel.Controls.Add(this.configureButton);
            this.actionPanel.Controls.Add(this.recipeButton);
            this.actionPanel.Controls.Add(this.applyRecipeButton);
            this.actionPanel.Controls.Add(this.actionSeparator);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionPanel.Location = new System.Drawing.Point(0, 526);
            this.actionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.actionPanel.MinimumSize = new System.Drawing.Size(0, 54);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(940, 54);
            this.actionPanel.TabIndex = 6;
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(10, 11);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(120, 30);
            this.scanButton.TabIndex = 0;
            this.scanButton.Text = "Check this PC";
            this.scanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // configureButton
            // 
            this.configureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.configureButton.AutoEllipsis = true;
            this.configureButton.Enabled = false;
            this.configureButton.Location = new System.Drawing.Point(770, 11);
            this.configureButton.Name = "configureButton";
            this.configureButton.Size = new System.Drawing.Size(160, 30);
            this.configureButton.TabIndex = 3;
            this.configureButton.Text = "Configure selected";
            this.configureButton.Click += new System.EventHandler(this.ConfigureButton_Click);
            // 
            // recipeButton
            // 
            this.recipeButton.Location = new System.Drawing.Point(136, 11);
            this.recipeButton.Name = "recipeButton";
            this.recipeButton.Size = new System.Drawing.Size(110, 30);
            this.recipeButton.TabIndex = 1;
            this.recipeButton.Text = "Recipe ▾";
            // 
            // applyRecipeButton
            // 
            this.applyRecipeButton.Enabled = false;
            this.applyRecipeButton.Location = new System.Drawing.Point(252, 11);
            this.applyRecipeButton.Name = "applyRecipeButton";
            this.applyRecipeButton.Size = new System.Drawing.Size(158, 30);
            this.applyRecipeButton.TabIndex = 2;
            this.applyRecipeButton.Text = "Apply recipe";
            this.applyRecipeButton.UseVisualStyleBackColor = true;
            this.applyRecipeButton.Visible = false;
            this.applyRecipeButton.Click += new System.EventHandler(this.ApplyRecipeButton_Click);
            // 
            // actionSeparator
            // 
            this.actionSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.actionSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionSeparator.Location = new System.Drawing.Point(0, 0);
            this.actionSeparator.Name = "actionSeparator";
            this.actionSeparator.Size = new System.Drawing.Size(940, 1);
            this.actionSeparator.TabIndex = 5;
            // 
            // OverviewView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.layout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "OverviewView";
            this.Size = new System.Drawing.Size(940, 580);
            this.layout.ResumeLayout(false);
            this.layout.PerformLayout();
            this.recipeBanner.ResumeLayout(false);
            this.detailSplit.Panel1.ResumeLayout(false);
            this.detailSplit.Panel2.ResumeLayout(false);
            this.detailSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailSplit)).EndInit();
            this.detailSplit.ResumeLayout(false);
            this.detailPane.ResumeLayout(false);
            this.detailPane.PerformLayout();
            this.actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

    }
}
