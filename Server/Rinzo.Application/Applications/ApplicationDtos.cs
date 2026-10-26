using Rinzo.Domain.Applications;

namespace Rinzo.Application.Applications;

public sealed record JobApplicationRequest(
    Guid SeekerId,
    Guid CompanyId,
    Guid JobId,
    string? Comments
);

// Separate from the create request: once submitted, only the status (and comments)
// can change - a seeker cannot retarget an existing application to a different job.
public sealed record JobApplicationStatusRequest(ApplicationStatus Status, string? Comments);

public sealed record JobApplicationResponse(
    Guid Id,
    Guid SeekerId,
    Guid CompanyId,
    Guid JobId,
    ApplicationStatus Status,
    DateTime SubmittedOn,
    DateTime? ReviewedOn,
    DateTime? DecidedOn,
    string? Comments,
    DateTime CreatedOn,
    DateTime? UpdatedOn
);
