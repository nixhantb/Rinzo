using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Rinzo.Application.Common;

namespace Rinzo.Application.Seekers;

public sealed class CachedSeekerService(
    ISeekerService inner,
    IMemoryCache cache,
    IOptions<CacheOptions> options
) : ISeekerService
{
    private readonly TimeSpan _duration = TimeSpan.FromSeconds(options.Value.SeekerByIdSeconds);

    private static string Key(Guid id) => $"seeker:{id}";

    public async Task<SeekerResponse> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        if (cache.TryGetValue(Key(id), out SeekerResponse? cached) && cached is not null)
        {
            return cached;
        }

        var seeker = await inner.GetByIdAsync(id, ct);
        cache.Set(Key(id), seeker, _duration);
        return seeker;
    }

    public async Task UpdateAsync(Guid id, SeekerRequest request, CancellationToken ct = default)
    {
        await inner.UpdateAsync(id, request, ct);
        cache.Remove(Key(id));
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        await inner.DeleteAsync(id, ct);
        cache.Remove(Key(id));
    }

    public Task<PagedResult<SeekerResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    ) => inner.GetPagedAsync(page, pageSize, ct);

    public Task<IReadOnlyList<SeekerResponse>> ListAllAsync(CancellationToken ct = default) =>
        inner.ListAllAsync(ct);

    public Task<SeekerResponse> CreateAsync(
        SeekerRequest request,
        CancellationToken ct = default
    ) => inner.CreateAsync(request, ct);
}
