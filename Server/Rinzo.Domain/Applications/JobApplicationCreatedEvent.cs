using Rinzo.Domain.Common;

namespace Rinzo.Domain.Applications;

public sealed record JobApplicationCreatedEvent(Guid ApplicationId, Guid SeekerId, Guid JobId)
    : IDomainEvent;
