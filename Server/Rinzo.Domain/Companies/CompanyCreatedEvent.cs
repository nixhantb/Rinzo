using Rinzo.Domain.Common;

namespace Rinzo.Domain.Companies;

public sealed record CompanyCreatedEvent(Guid CompanyId, string CompanyName) : IDomainEvent;
