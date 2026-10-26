namespace Rinzo.Domain.Common.ValueObjects;

public enum ExperienceLevel
{
    EntryLevel = 1,
    Intermediate = 2,
    Senior = 3,
    Lead = 4,
    Principal = 5,
    Executive = 6,
    Other = 7,
}

public sealed class Experience
{
    public ExperienceLevel Level { get; private set; }
    public string Company { get; private set; } = string.Empty;
    public List<string> Responsibilities { get; private set; } = [];
    public DateTime FromDate { get; private set; }
    public DateTime? TillDate { get; private set; }

    private Experience() { }

    public static Experience Create(
        ExperienceLevel level,
        string company,
        List<string> responsibilities,
        DateTime fromDate,
        DateTime? tillDate
    )
    {
        if (tillDate.HasValue && tillDate.Value < fromDate)
        {
            throw new ArgumentException(
                "Till date cannot be before the from date.",
                nameof(tillDate)
            );
        }

        return new Experience
        {
            Level = level,
            Company = company.Trim(),
            Responsibilities = responsibilities,
            FromDate = fromDate,
            TillDate = tillDate,
        };
    }
}
