namespace Rinzo.Domain.Common;

public abstract class BaseEntity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    // Version 7 GUIDs are ordered by time, so database indexes stay fast on insert.
    public Guid Id { get; protected set; } = Guid.CreateVersion7();
    public DateTime CreatedOn { get; protected set; } = DateTime.UtcNow;
    public DateTime? UpdatedOn { get; protected set; }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    protected void MarkAsUpdated() => UpdatedOn = DateTime.UtcNow;

    public void ClearDomainEvents() => _domainEvents.Clear();
}
