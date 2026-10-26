using Rinzo.Domain.Common;

namespace Rinzo.Domain.Seekers;

public sealed record SeekerCreatedEvent(Guid SeekerId) : IDomainEvent;
