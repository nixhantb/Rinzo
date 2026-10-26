namespace Rinzo.Domain.Common.ValueObjects;

public enum QualificationType
{
    Education = 1,
    Skill = 2,
    Certification = 3,
}

public sealed class Qualification
{
    public QualificationType Type { get; private set; }
    public string Information { get; private set; } = string.Empty;

    private Qualification() { }

    public static Qualification Create(QualificationType type, string information) =>
        new() { Type = type, Information = information.Trim() };
}
