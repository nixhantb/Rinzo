using Microsoft.Extensions.Logging;
using Rinzo.Application.Abstractions;
using Rinzo.Domain.Common;

namespace Rinzo.Application.Events;

// One observer, registered for every domain event type (Company/Employer/Job/
// Application/Seeker "Created"), so each of the five resources gets an audit-log
// reaction with no per-resource handler class to write and keep in sync.
public sealed class LogDomainEventHandler<TEvent>(ILogger<LogDomainEventHandler<TEvent>> logger)
    : IDomainEventHandler<TEvent>
    where TEvent : IDomainEvent
{
    public Task HandleAsync(TEvent domainEvent, CancellationToken ct)
    {
        logger.LogInformation("AUDIT: {Event} {@DomainEvent}", typeof(TEvent).Name, domainEvent);
        return Task.CompletedTask;
    }
}
