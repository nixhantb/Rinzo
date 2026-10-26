using Rinzo.Application.Abstractions;
using Rinzo.Domain.Common;

namespace Rinzo.Infrastructure.Persistence;

public sealed class UnitOfWork(AppDbContext db, IDomainEventDispatcher dispatcher) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        // 1. Collect the events from every tracked entity.
        var entities = db
            .ChangeTracker.Entries<BaseEntity>()
            .Select(entry => entry.Entity)
            .Where(entity => entity.DomainEvents.Count > 0)
            .ToList();

        var events = entities.SelectMany(entity => entity.DomainEvents).ToList();

        // 2. Save everything in ONE transaction.
        var rows = await db.SaveChangesAsync(ct);

        // 3. Only after a successful save: clear the events and tell the observers.
        entities.ForEach(entity => entity.ClearDomainEvents());
        await dispatcher.DispatchAsync(events, ct);

        return rows;
    }
}
