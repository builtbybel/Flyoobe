namespace Flyoobe3.Views;

//the rating page: one big mark, the areas it was made from, and a way into the weakest one
partial class RatingView
{
    private System.ComponentModel.IContainer components = null!;
    private Label titleLabel = null!;
    private Label scoreLabel = null!;
    private Label scoreCaption = null!;
    private Label disclaimerLabel = null!;
    private Label totalLabel = null!;
    private Label headerSeparator = null!;
    private TableLayoutPanel ratingTable = null!;
    private Label weakestLabel = null!;
    private Panel footerPanel = null!;
    private Label footerSeparator = null!;
    private Button reviewButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.titleLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreCaption = new System.Windows.Forms.Label();
            this.disclaimerLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.headerSeparator = new System.Windows.Forms.Label();
            this.ratingTable = new System.Windows.Forms.TableLayoutPanel();
            this.weakestLabel = new System.Windows.Forms.Label();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.footerSeparator = new System.Windows.Forms.Label();
            this.reviewButton = new System.Windows.Forms.Button();
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
            this.titleLabel.Text = "Setup rating";
            //
            // scoreLabel
            //
            this.scoreLabel.Font = new System.Drawing.Font("Segoe UI", 34F);
            this.scoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.scoreLabel.Location = new System.Drawing.Point(8, 44);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(150, 62);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "0.0";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // scoreCaption
            //
            this.scoreCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.scoreCaption.Location = new System.Drawing.Point(8, 108);
            this.scoreCaption.Name = "scoreCaption";
            this.scoreCaption.Size = new System.Drawing.Size(150, 20);
            this.scoreCaption.TabIndex = 3;
            this.scoreCaption.Text = "Base score";
            this.scoreCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // disclaimerLabel
            //
            this.disclaimerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.disclaimerLabel.Location = new System.Drawing.Point(176, 44);
            this.disclaimerLabel.Name = "disclaimerLabel";
            this.disclaimerLabel.Size = new System.Drawing.Size(756, 56);
            this.disclaimerLabel.TabIndex = 4;
            this.disclaimerLabel.Text = "Compared to Flyoobe\'s recommendations.";
            //
            // totalLabel
            //
            this.totalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.totalLabel.Location = new System.Drawing.Point(176, 104);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(756, 24);
            this.totalLabel.TabIndex = 5;
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // headerSeparator
            //
            this.headerSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.headerSeparator.Location = new System.Drawing.Point(8, 138);
            this.headerSeparator.Name = "headerSeparator";
            this.headerSeparator.Size = new System.Drawing.Size(924, 1);
            this.headerSeparator.TabIndex = 5;
            //
            // ratingTable
            //
            this.ratingTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ratingTable.AutoScroll = true;
            this.ratingTable.ColumnCount = 4;
            this.ratingTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.ratingTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.ratingTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.ratingTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ratingTable.Location = new System.Drawing.Point(8, 150);
            this.ratingTable.Name = "ratingTable";
            this.ratingTable.RowCount = 1;
            this.ratingTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ratingTable.Size = new System.Drawing.Size(924, 338);
            this.ratingTable.TabIndex = 6;
            //
            // weakestLabel
            //
            this.weakestLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weakestLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.weakestLabel.Location = new System.Drawing.Point(8, 498);
            this.weakestLabel.Name = "weakestLabel";
            this.weakestLabel.Size = new System.Drawing.Size(924, 26);
            this.weakestLabel.TabIndex = 7;
            this.weakestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // footerPanel
            //
            this.footerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.footerPanel.Controls.Add(this.reviewButton);
            this.footerPanel.Controls.Add(this.footerSeparator);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 534);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(940, 46);
            this.footerPanel.TabIndex = 8;
            //
            // footerSeparator
            //
            this.footerSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.footerSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.footerSeparator.Location = new System.Drawing.Point(0, 0);
            this.footerSeparator.Name = "footerSeparator";
            this.footerSeparator.Size = new System.Drawing.Size(940, 1);
            this.footerSeparator.TabIndex = 1;
            //
            // reviewButton
            //
            this.reviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reviewButton.AutoEllipsis = true;
            this.reviewButton.Location = new System.Drawing.Point(732, 7);
            this.reviewButton.Name = "reviewButton";
            this.reviewButton.Size = new System.Drawing.Size(200, 30);
            this.reviewButton.TabIndex = 2;
            this.reviewButton.Text = "Review";
            this.reviewButton.Click += new System.EventHandler(this.ReviewButton_Click);
            //
            // RatingView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.weakestLabel);
            this.Controls.Add(this.ratingTable);
            this.Controls.Add(this.headerSeparator);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.disclaimerLabel);
            this.Controls.Add(this.scoreCaption);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "RatingView";
            this.Size = new System.Drawing.Size(940, 580);
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
