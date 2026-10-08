using Flyoobe3.Services;

namespace Flyoobe3.Views;

//shows how far this PC already follows Flyoobe's recommendations, in the shape of the old Windows index
internal partial class RatingView : UserControl
{
    private readonly SetupCatalog _catalog;
    private string? _weakestKey;

    public event Action<string>? OpenRequested;

    //the designer needs empty data, MainForm supplies the scanned catalog
    public RatingView() : this(new SetupCatalog()) { }

    public RatingView(SetupCatalog catalog)
    {
        _catalog = catalog;
        InitializeComponent();
        ApplyLocalization();
        BuildTable();
    }

    private void ApplyLocalization()
    {
        titleLabel.Text = Loc.Get("Rating_Title");
        scoreCaption.Text = Loc.Get("Rating_BaseScore");
        disclaimerLabel.Text = Loc.Get("Rating_Disclaimer");
        //the mark is the weakest area alone, so the whole picture stands next to it and cannot be misread
        totalLabel.Text = Loc.Format("Overview_CheckSummary",
            _catalog.Rules.Count(rule => rule.IsApplied), _catalog.Rules.Count);
    }

    private void BuildTable()
    {
        var rows = SetupRating.Rows(_catalog);
        var weakest = SetupRating.Weakest(rows);
        _weakestKey = weakest?.Key;

        //the designer insists on one row, every real row is added here
        ratingTable.RowStyles.Clear();
        ratingTable.RowCount = 0;

        //not disposed on purpose: the header labels keep using it for as long as they live
        var bold = new Font(Font, FontStyle.Bold);
        AddRow(Loc.Get("Rating_Component"), Loc.Get("Rating_Rated"), Loc.Get("Rating_Subscore"), null, bold);
        foreach (var row in rows)
            AddRow(row.Name, row.Measured, row.Score.ToString("0.0"), row.Score, Font);

        //without a row that takes the leftover height the last bar would grow into it
        ratingTable.RowCount++;
        ratingTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        //nothing was measured yet, so there is no mark to explain and nowhere to send anyone
        weakestLabel.Visible = weakest != null;
        reviewButton.Visible = weakest != null;
        if (weakest == null) return;

        scoreLabel.Text = weakest.Score.ToString("0.0");
        weakestLabel.Text = Loc.Format("Rating_Weakest", weakest.Name);
        reviewButton.Text = Loc.Format("Overview_ReviewArea", weakest.Name);
    }

    //one line of the table; the header row is the same line without a bar
    private void AddRow(string name, string measured, string score, double? value, Font font)
    {
        var index = ratingTable.RowCount++;
        ratingTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        ratingTable.Controls.Add(Cell(name, font), 0, index);
        ratingTable.Controls.Add(Cell(measured, font), 2, index);
        ratingTable.Controls.Add(Cell(score, font, ContentAlignment.MiddleRight), 3, index);
        if (value == null) return;

        //Maximum is the ceiling of the scale, so the bar fills exactly when the mark is at its best
        ratingTable.Controls.Add(new ProgressBar
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(3, 4, 3, 4),
            Maximum = 99,
            Style = ProgressBarStyle.Continuous,
            Value = (int)Math.Round(value.Value * 10)
        }, 1, index);
    }

    //autosize keeps every row as tall as its own text, so no size has to be scaled by hand
    private static Label Cell(string text, Font font, ContentAlignment align = ContentAlignment.MiddleLeft) =>
        new Label
        {
            Anchor = align == ContentAlignment.MiddleRight ? AnchorStyles.Right : AnchorStyles.Left,
            AutoSize = true,
            Font = font,
            Margin = new Padding(3, 6, 3, 6),
            Text = text
        };

    private void ReviewButton_Click(object? sender, EventArgs e)
    {
        if (_weakestKey != null) OpenRequested?.Invoke(_weakestKey);
    }
}
