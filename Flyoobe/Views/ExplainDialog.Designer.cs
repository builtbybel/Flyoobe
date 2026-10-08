namespace Flyoobe3.Views;

// keeps the AI answer readable at every DPI
partial class ExplainDialog
{
    private System.ComponentModel.IContainer components = null!;
    private TextBox bodyBox = null!;
    private Button closeButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        bodyBox = new TextBox();
        closeButton = new Button();
        SuspendLayout();

        bodyBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        bodyBox.BackColor = SystemColors.Window;
        bodyBox.Location = new Point(12, 12);
        bodyBox.Multiline = true;
        bodyBox.ReadOnly = true;
        bodyBox.ScrollBars = ScrollBars.Vertical;
        bodyBox.Size = new Size(576, 307);

        closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        closeButton.DialogResult = DialogResult.Cancel;
        closeButton.Location = new Point(498, 331);
        closeButton.Size = new Size(90, 30);

        AcceptButton = closeButton;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        CancelButton = closeButton;
        ClientSize = new Size(600, 373);
        Controls.Add(bodyBox);
        Controls.Add(closeButton);
        Font = new Font("Segoe UI", 9F);
        MaximizeBox = false;
        MinimizeBox = false;
        MinimumSize = new Size(470, 300);
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);
        PerformLayout();
    }
}
