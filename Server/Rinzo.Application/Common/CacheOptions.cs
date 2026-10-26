namespace Rinzo.Application.Common;

// How long a single "get by id" response stays in the cache, per resource.
public sealed class CacheOptions
{
    public const string SectionName = "Cache";

    public int CompanyByIdSeconds { get; set; } = 60;
    public int EmployerByIdSeconds { get; set; } = 60;
    public int JobByIdSeconds { get; set; } = 60;
    public int ApplicationByIdSeconds { get; set; } = 60;
    public int SeekerByIdSeconds { get; set; } = 60;
}
