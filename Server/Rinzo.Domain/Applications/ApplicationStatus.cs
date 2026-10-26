namespace Rinzo.Domain.Applications;

public enum ApplicationStatus
{
    Pending = 0,
    Reviewed = 1,
    InterviewScheduled = 2,
    Accepted = 3,
    Rejected = 4,
    Cancelled = 5,
}
