using Microsoft.Extensions.DependencyInjection;
using Rinzo.Application.Abstractions;
using Rinzo.Domain.Common;

namespace Rinzo.Infrastructure.Events;

public sealed class DomainEventDispatcher(IServiceProvider services) : IDomainEventDispatcher
{
    public async Task DispatchAsync(
        IEnumerable<IDomainEvent> domainEvents,
        CancellationToken ct = default
    )
    {
        foreach (var domainEvent in domainEvents)
        {
            // Build IDomainEventHandler<TheConcreteEventType> at runtime: the event is
            // stored as IDomainEvent, so its real type is only known here.
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            var handleMethod = handlerType.GetMethod("HandleAsync")!;

            foreach (var handler in services.GetServices(handlerType))
            {
                await (Task)handleMethod.Invoke(handler, [domainEvent, ct])!;
            }
        }
    }
}
