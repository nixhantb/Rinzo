using Microsoft.EntityFrameworkCore;
using Rinzo.Application.Abstractions;
using Rinzo.Application.Common;
using Rinzo.Domain.Common;

namespace Rinzo.Infrastructure.Persistence.Repositories;

public abstract class Repository<T>(AppDbContext db) : IRepository<T>
    where T : BaseEntity
{
    protected readonly AppDbContext Db = db;
    protected DbSet<T> Set => Db.Set<T>();

    // Tracked: the service may change this object and then save it.
    public virtual Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Set.FirstOrDefaultAsync(e => e.Id == id, ct);

    // Read-only: AsNoTracking() is faster and uses less memory.
    public virtual async Task<PagedResult<T>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    )
    {
        var query = Set.AsNoTracking().OrderBy(e => e.CreatedOn).ThenBy(e => e.Id);

        var total = await query.CountAsync(ct);
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct);

        return new PagedResult<T>(items, page, pageSize, total);
    }

    public virtual async Task<IReadOnlyList<T>> ListAsync(CancellationToken ct = default) =>
        await Set.AsNoTracking().OrderBy(e => e.CreatedOn).ToListAsync(ct);

    public void Add(T entity) => Set.Add(entity);

    public void Remove(T entity) => Set.Remove(entity);
}
