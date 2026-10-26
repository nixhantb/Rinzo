using Rinzo.Domain.Applications;

namespace Rinzo.Application.Applications;

public static class ApplicationMappings
{
    public static JobApplicationResponse ToResponse(this JobApplication application) =>
        new(
            application.Id,
            application.SeekerId,
            application.CompanyId,
            application.JobId,
            application.Status,
            application.SubmittedOn,
            application.ReviewedOn,
            application.DecidedOn,
            application.Comments,
            application.CreatedOn,
            application.UpdatedOn
        );
}
