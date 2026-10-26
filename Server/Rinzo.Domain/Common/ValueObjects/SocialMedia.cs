namespace Rinzo.Domain.Common.ValueObjects;

public sealed class SocialMedia
{
    public string Title { get; private set; } = string.Empty;
    public string Url { get; private set; } = string.Empty;

    private SocialMedia() { }

    public static SocialMedia Create(string title, string url) =>
        new() { Title = title.Trim(), Url = url.Trim() };
}
