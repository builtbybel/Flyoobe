using Flyoobe3.Services;

namespace Flyoobe3.Views.Settings;

//shows the app identity and the few official project links
internal partial class AboutSettingsView : UserControl
{
    public AboutSettingsView()
    {
        InitializeComponent();
        ApplyLocalization();
        LoadIcon();
        WireLinks();
    }

    private void ApplyLocalization()
    {
        aboutNameLabel.Text = "Flyoobe";
        aboutVersionLabel.Text = Loc.Format("About_Version", AppInfo.DisplayVersion);
        pronunciationLabel.Text = Loc.Get("About_Pronunciation");
        aboutDescriptionLabel.Text = Loc.Get("About_Description");
        aboutAuthorLabel.Text = Loc.Get("About_Author");
        githubLink.Text = Loc.Get("About_GitHub");
        releasesLink.Text = Loc.Get("About_Releases");
        issuesLink.Text = Loc.Get("About_Issues");
        supportLink.Text = Loc.Get("About_Support");
        officialDownloadsLabel.Text = Loc.Get("About_OfficialNotice");
        ApplyTranslatorCredit();
    }

    //only shown when the active language file names its translator; english names none
    private void ApplyTranslatorCredit()
    {
        var name = Loc.Meta("_Meta_TranslatorName");
        translatorLink.Visible = name.Length > 0;
        if (name.Length == 0) return;

        translatorLink.Text = Loc.Format("About_Translation", name);
        var start = translatorLink.Text.IndexOf(name, StringComparison.Ordinal);
        //without a url the line stays plain text, so nothing pretends to be clickable
        translatorLink.LinkArea = Loc.Meta("_Meta_TranslatorUrl").Length > 0 && start >= 0
            ? new LinkArea(start, name.Length) : new LinkArea(0, 0);
    }

    private void WireLinks()
    {
        githubLink.LinkClicked += (_, _) => AppLinks.Open(AppLinks.GitHub);
        releasesLink.LinkClicked += (_, _) => AppLinks.Open(AppLinks.Releases);
        issuesLink.LinkClicked += (_, _) => AppLinks.Open(AppLinks.Issues);
        supportLink.LinkClicked += (_, _) => AppLinks.Open(AppLinks.Donation);
        translatorLink.LinkClicked += (_, _) => AppLinks.Open(Loc.Meta("_Meta_TranslatorUrl"));
    }

    //the 256px artwork lives inside the exe; GDI+ ties a Bitmap to its stream, so we keep a copy
    private void LoadIcon()
    {
        try
        {
            using var stream = typeof(AboutSettingsView).Assembly
                .GetManifestResourceStream("Flyoobe3.Assets.AppIcon.png");
            if (stream == null) return;
            using var source = new Bitmap(stream);
            aboutIcon.Image = new Bitmap(source);
        }
        catch { }
    }
}
