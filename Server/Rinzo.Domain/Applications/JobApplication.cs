using Rinzo.Domain.Common;

namespace Rinzo.Domain.Applications;

// Named "JobApplication" rather than "Application" to avoid clashing with the
// everyday meaning of "application" (the app itself, ASP.NET's app builder, etc).
public sealed class JobApplication : BaseEntity
{
    public Guid SeekerId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid JobId { get; private set; }
    public ApplicationStatus Status { get; private set; } = ApplicationStatus.Pending;
    public DateTime SubmittedOn { get; private set; }
    public DateTime? ReviewedOn { get; private set; }
    public DateTime? DecidedOn { get; private set; }
    public string? Comments { get; private set; }

    private JobApplication() { }

    public static JobApplication Create(Guid seekerId, Guid companyId, Guid jobId, string? comments)
    {
        if (seekerId == Guid.Empty)
        {
            throw new ArgumentException("A seeker id is required.", nameof(seekerId));
        }

        if (companyId == Guid.Empty)
        {
            throw new ArgumentException("A company id is required.", nameof(companyId));
        }

        if (jobId == Guid.Empty)
        {
            throw new ArgumentException("A job id is required.", nameof(jobId));
        }

        var application = new JobApplication
        {
            SeekerId = seekerId,
            CompanyId = companyId,
            JobId = jobId,
            Status = ApplicationStatus.Pending,
            SubmittedOn = DateTime.UtcNow,
            Comments = comments?.Trim(),
        };

        application.AddDomainEvent(
            new JobApplicationCreatedEvent(application.Id, application.SeekerId, application.JobId)
        );
        return application;
    }

    // Status moves forward through a review, never backward, and a decision needs a review first.
    public void ChangeStatus(ApplicationStatus status, string? comments)
    {
        if (status == ApplicationStatus.Pending)
        {
            throw new ArgumentException(
                "An application cannot be moved back to Pending.",
                nameof(status)
            );
        }

        var isDecision = status is ApplicationStatus.Accepted or ApplicationStatus.Rejected;
        if (isDecision)
        {
            DecidedOn = DateTime.UtcNow;
        }
        else if (status is ApplicationStatus.Reviewed or ApplicationStatus.InterviewScheduled)
        {
            ReviewedOn ??= DateTime.UtcNow;
        }

        Status = status;
        Comments = comments?.Trim() ?? Comments;
        MarkAsUpdated();
    }
}
