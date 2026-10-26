using Rinzo.Domain.Common;
using Rinzo.Domain.Common.ValueObjects;

namespace Rinzo.Domain.Jobs;

public sealed class Job : BaseEntity
{
    public Guid CompanyId { get; private set; }
    public string JobTitle { get; private set; } = string.Empty;
    public string JobDescription { get; private set; } = string.Empty;
    public string JobType { get; private set; } = string.Empty;
    public Address? JobAddress { get; private set; }
    public int Vacancies { get; private set; }
    public BasicPay? BasicPay { get; private set; }
    public string? FunctionalArea { get; private set; }
    public List<Skill> RequiredSkills { get; private set; } = [];
    public List<Qualification> RequiredQualifications { get; private set; } = [];
    public ExperienceLevel? RequiredExperienceLevel { get; private set; }
    public List<string> PreferredQualifications { get; private set; } = [];
    public List<string> JobResponsibilities { get; private set; } = [];
    public List<string> Benefits { get; private set; } = [];
    public List<string> Tags { get; private set; } = [];
    public string? WorkEnvironment { get; private set; }
    public DateTime PostingDate { get; private set; }
    public DateTime? ApplicationDeadline { get; private set; }

    private Job() { }

    public static Job Create(
        Guid companyId,
        string jobTitle,
        string jobDescription,
        string jobType,
        Address? jobAddress,
        int vacancies,
        BasicPay? basicPay,
        string? functionalArea,
        List<Skill> requiredSkills,
        List<Qualification> requiredQualifications,
        ExperienceLevel? requiredExperienceLevel,
        List<string> preferredQualifications,
        List<string> jobResponsibilities,
        List<string> benefits,
        List<string> tags,
        string? workEnvironment,
        DateTime? applicationDeadline
    )
    {
        if (companyId == Guid.Empty)
        {
            throw new ArgumentException("A company id is required.", nameof(companyId));
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(jobTitle);
        ArgumentException.ThrowIfNullOrWhiteSpace(jobDescription);
        ArgumentException.ThrowIfNullOrWhiteSpace(jobType);

        if (vacancies < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(vacancies),
                "A job needs at least one vacancy."
            );
        }

        var job = new Job
        {
            CompanyId = companyId,
            JobTitle = jobTitle.Trim(),
            JobDescription = jobDescription.Trim(),
            JobType = jobType.Trim(),
            JobAddress = jobAddress,
            Vacancies = vacancies,
            BasicPay = basicPay,
            FunctionalArea = functionalArea?.Trim(),
            RequiredSkills = requiredSkills,
            RequiredQualifications = requiredQualifications,
            RequiredExperienceLevel = requiredExperienceLevel,
            PreferredQualifications = preferredQualifications,
            JobResponsibilities = jobResponsibilities,
            Benefits = benefits,
            Tags = tags,
            WorkEnvironment = workEnvironment?.Trim(),
            PostingDate = DateTime.UtcNow,
            ApplicationDeadline = applicationDeadline,
        };

        job.AddDomainEvent(new JobCreatedEvent(job.Id, job.CompanyId, job.JobTitle));
        return job;
    }

    public void Update(
        string jobTitle,
        string jobDescription,
        string jobType,
        Address? jobAddress,
        int vacancies,
        BasicPay? basicPay,
        string? functionalArea,
        List<Skill> requiredSkills,
        List<Qualification> requiredQualifications,
        ExperienceLevel? requiredExperienceLevel,
        List<string> preferredQualifications,
        List<string> jobResponsibilities,
        List<string> benefits,
        List<string> tags,
        string? workEnvironment,
        DateTime? applicationDeadline
    )
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(jobTitle);
        ArgumentException.ThrowIfNullOrWhiteSpace(jobDescription);
        ArgumentException.ThrowIfNullOrWhiteSpace(jobType);

        if (vacancies < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(vacancies),
                "A job needs at least one vacancy."
            );
        }

        JobTitle = jobTitle.Trim();
        JobDescription = jobDescription.Trim();
        JobType = jobType.Trim();
        JobAddress = jobAddress;
        Vacancies = vacancies;
        BasicPay = basicPay;
        FunctionalArea = functionalArea?.Trim();
        RequiredSkills = requiredSkills;
        RequiredQualifications = requiredQualifications;
        RequiredExperienceLevel = requiredExperienceLevel;
        PreferredQualifications = preferredQualifications;
        JobResponsibilities = jobResponsibilities;
        Benefits = benefits;
        Tags = tags;
        WorkEnvironment = workEnvironment?.Trim();
        ApplicationDeadline = applicationDeadline;
        MarkAsUpdated();
    }
}
