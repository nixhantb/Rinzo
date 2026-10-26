using Rinzo.Domain.Common;

namespace Rinzo.Domain.Jobs;

public sealed record JobCreatedEvent(Guid JobId, Guid CompanyId, string JobTitle) : IDomainEvent;
