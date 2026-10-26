using Rinzo.Application.Common;
using Rinzo.Domain.Common;

namespace Rinzo.Application.Abstractions;

public interface IRepository<T>
    where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<T>> GetPagedAsync(int page, int pageSize, CancellationToken ct = default);
    Task<IReadOnlyList<T>> ListAsync(CancellationToken ct = default);
    void Add(T entity);
    void Remove(T entity);
}
