using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Rinzo.Application.Common;

namespace Rinzo.Application.Companies;

// Decorator: wraps the real service and adds caching for "get by id", with no change
// to CompanyService itself. Writes go through to the real service and invalidate the
// cached entry.
public sealed class CachedCompanyService(
    ICompanyService inner,
    IMemoryCache cache,
    IOptions<CacheOptions> options
) : ICompanyService
{
    private readonly TimeSpan _duration = TimeSpan.FromSeconds(options.Value.CompanyByIdSeconds);

    private static string Key(Guid id) => $"company:{id}";

    public async Task<CompanyResponse> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        if (cache.TryGetValue(Key(id), out CompanyResponse? cached) && cached is not null)
        {
            return cached;
        }

        var company = await inner.GetByIdAsync(id, ct);
        cache.Set(Key(id), company, _duration);
        return company;
    }

    public async Task UpdateAsync(Guid id, CompanyRequest request, CancellationToken ct = default)
    {
        await inner.UpdateAsync(id, request, ct);
        cache.Remove(Key(id));
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        await inner.DeleteAsync(id, ct);
        cache.Remove(Key(id));
    }

    public Task<PagedResult<CompanyResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    ) => inner.GetPagedAsync(page, pageSize, ct);

    public Task<IReadOnlyList<CompanyResponse>> ListAllAsync(CancellationToken ct = default) =>
        inner.ListAllAsync(ct);

    public Task<CompanyResponse> CreateAsync(
        CompanyRequest request,
        CancellationToken ct = default
    ) => inner.CreateAsync(request, ct);
}
