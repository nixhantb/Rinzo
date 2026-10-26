using Rinzo.Domain.Common;

namespace Rinzo.Application.Abstractions;

// An "observer": it reacts to one kind of domain event.
public interface IDomainEventHandler<in TEvent>
    where TEvent : IDomainEvent
{
    Task HandleAsync(TEvent domainEvent, CancellationToken ct);
}
