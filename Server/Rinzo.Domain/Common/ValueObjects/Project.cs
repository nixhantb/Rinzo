namespace Rinzo.Domain.Common.ValueObjects;

public sealed class Project
{
    public string Title { get; private set; } = string.Empty;
    public List<string> Responsibilities { get; private set; } = [];
    public List<string> TechnologiesUsed { get; private set; } = [];
    public string? Role { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly? EndDate { get; private set; }
    public string? ProjectUrl { get; private set; }
    public string? GitHubUrl { get; private set; }

    public bool IsOngoing => !EndDate.HasValue;

    private Project() { }

    public static Project Create(
        string title,
        List<string> responsibilities,
        List<string> technologiesUsed,
        string? role,
        DateOnly startDate,
        DateOnly? endDate,
        string? projectUrl,
        string? gitHubUrl
    ) =>
        new()
        {
            Title = title.Trim(),
            Responsibilities = responsibilities,
            TechnologiesUsed = technologiesUsed,
            Role = role?.Trim(),
            StartDate = startDate,
            EndDate = endDate,
            ProjectUrl = projectUrl?.Trim(),
            GitHubUrl = gitHubUrl?.Trim(),
        };
}
