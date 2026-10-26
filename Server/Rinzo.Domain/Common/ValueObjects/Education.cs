namespace Rinzo.Domain.Common.ValueObjects;

public sealed class Education
{
    public string Degree { get; private set; } = string.Empty;
    public string Major { get; private set; } = string.Empty;
    public string Institution { get; private set; } = string.Empty;
    public DateOnly GraduationDate { get; private set; }
    public decimal Cgpa { get; private set; }

    private Education() { }

    public static Education Create(
        string degree,
        string major,
        string institution,
        DateOnly graduationDate,
        decimal cgpa
    ) =>
        new()
        {
            Degree = degree.Trim(),
            Major = major.Trim(),
            Institution = institution.Trim(),
            GraduationDate = graduationDate,
            Cgpa = cgpa,
        };
}
