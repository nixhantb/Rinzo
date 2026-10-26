namespace Rinzo.Domain.Common.ValueObjects;

public sealed class Skill
{
    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; }

    private Skill() { }

    public static Skill Create(string title, string? description) =>
        new() { Title = title.Trim(), Description = description?.Trim() };
}
