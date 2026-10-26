using Rinzo.Domain.Common;

namespace Rinzo.Domain.Employers;

public sealed record EmployerCreatedEvent(Guid EmployerId, Guid CompanyId) : IDomainEvent;
