using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Rinzo.Application.Common;

namespace Rinzo.Application.Jobs;

public sealed class CachedJobService(
    IJobService inner,
    IMemoryCache cache,
    IOptions<CacheOptions> options
) : IJobService
{
    private readonly TimeSpan _duration = TimeSpan.FromSeconds(options.Value.JobByIdSeconds);

    private static string Key(Guid id) => $"job:{id}";

    public async Task<JobResponse> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        if (cache.TryGetValue(Key(id), out JobResponse? cached) && cached is not null)
        {
            return cached;
        }

        var job = await inner.GetByIdAsync(id, ct);
        cache.Set(Key(id), job, _duration);
        return job;
    }

    public async Task UpdateAsync(Guid id, JobRequest request, CancellationToken ct = default)
    {
        await inner.UpdateAsync(id, request, ct);
        cache.Remove(Key(id));
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        await inner.DeleteAsync(id, ct);
        cache.Remove(Key(id));
    }

    public Task<PagedResult<JobResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    ) => inner.GetPagedAsync(page, pageSize, ct);

    public Task<IReadOnlyList<JobResponse>> ListAllAsync(CancellationToken ct = default) =>
        inner.ListAllAsync(ct);

    public Task<JobResponse> CreateAsync(JobRequest request, CancellationToken ct = default) =>
        inner.CreateAsync(request, ct);
}
