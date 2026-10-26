using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Rinzo.Application.Common;

namespace Rinzo.Application.Employers;

public sealed class CachedEmployerService(
    IEmployerService inner,
    IMemoryCache cache,
    IOptions<CacheOptions> options
) : IEmployerService
{
    private readonly TimeSpan _duration = TimeSpan.FromSeconds(options.Value.EmployerByIdSeconds);

    private static string Key(Guid id) => $"employer:{id}";

    public async Task<EmployerResponse> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        if (cache.TryGetValue(Key(id), out EmployerResponse? cached) && cached is not null)
        {
            return cached;
        }

        var employer = await inner.GetByIdAsync(id, ct);
        cache.Set(Key(id), employer, _duration);
        return employer;
    }

    public async Task UpdateAsync(Guid id, EmployerRequest request, CancellationToken ct = default)
    {
        await inner.UpdateAsync(id, request, ct);
        cache.Remove(Key(id));
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        await inner.DeleteAsync(id, ct);
        cache.Remove(Key(id));
    }

    public Task<PagedResult<EmployerResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    ) => inner.GetPagedAsync(page, pageSize, ct);

    public Task<IReadOnlyList<EmployerResponse>> ListAllAsync(CancellationToken ct = default) =>
        inner.ListAllAsync(ct);

    public Task<EmployerResponse> CreateAsync(
        EmployerRequest request,
        CancellationToken ct = default
    ) => inner.CreateAsync(request, ct);
}
