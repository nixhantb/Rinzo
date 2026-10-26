using Rinzo.Application.Common;
using Rinzo.Domain.Jobs;

namespace Rinzo.Application.Jobs;

public static class JobMappings
{
    public static JobResponse ToResponse(this Job job) =>
        new(
            job.Id,
            job.CompanyId,
            job.JobTitle,
            job.JobDescription,
            job.JobType,
            job.JobAddress?.ToDto(),
            job.Vacancies,
            job.BasicPay?.ToDto(),
            job.FunctionalArea,
            job.RequiredSkills.Select(s => s.ToDto()).ToList(),
            job.RequiredQualifications.Select(q => q.ToDto()).ToList(),
            job.RequiredExperienceLevel,
            job.PreferredQualifications,
            job.JobResponsibilities,
            job.Benefits,
            job.Tags,
            job.WorkEnvironment,
            job.PostingDate,
            job.ApplicationDeadline,
            job.CreatedOn,
            job.UpdatedOn
        );
}
