using Rinzo.Application.Common;

namespace Rinzo.Application.Jobs;

public interface IJobService
{
    Task<JobResponse> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<JobResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    );
    Task<IReadOnlyList<JobResponse>> ListAllAsync(CancellationToken ct = default);
    Task<JobResponse> CreateAsync(JobRequest request, CancellationToken ct = default);
    Task UpdateAsync(Guid id, JobRequest request, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
