using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Rinzo.Application.Common;

namespace Rinzo.Application.Applications;

public sealed class CachedApplicationService(
    IApplicationService inner,
    IMemoryCache cache,
    IOptions<CacheOptions> options
) : IApplicationService
{
    private readonly TimeSpan _duration = TimeSpan.FromSeconds(
        options.Value.ApplicationByIdSeconds
    );

    private static string Key(Guid id) => $"application:{id}";

    public async Task<JobApplicationResponse> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        if (cache.TryGetValue(Key(id), out JobApplicationResponse? cached) && cached is not null)
        {
            return cached;
        }

        var application = await inner.GetByIdAsync(id, ct);
        cache.Set(Key(id), application, _duration);
        return application;
    }

    public async Task UpdateStatusAsync(
        Guid id,
        JobApplicationStatusRequest request,
        CancellationToken ct = default
    )
    {
        await inner.UpdateStatusAsync(id, request, ct);
        cache.Remove(Key(id));
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        await inner.DeleteAsync(id, ct);
        cache.Remove(Key(id));
    }

    public Task<PagedResult<JobApplicationResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    ) => inner.GetPagedAsync(page, pageSize, ct);

    public Task<IReadOnlyList<JobApplicationResponse>> ListAllAsync(
        CancellationToken ct = default
    ) => inner.ListAllAsync(ct);

    public Task<JobApplicationResponse> CreateAsync(
        JobApplicationRequest request,
        CancellationToken ct = default
    ) => inner.CreateAsync(request, ct);
}
