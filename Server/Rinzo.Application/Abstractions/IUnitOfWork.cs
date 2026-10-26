namespace Rinzo.Application.Abstractions;

public interface IUnitOfWork
{
    // Saves ALL pending changes in one database transaction.
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
