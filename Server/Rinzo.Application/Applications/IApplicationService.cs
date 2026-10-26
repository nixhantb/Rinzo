using Rinzo.Application.Common;

namespace Rinzo.Application.Applications;

public interface IApplicationService
{
    Task<JobApplicationResponse> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<JobApplicationResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    );
    Task<IReadOnlyList<JobApplicationResponse>> ListAllAsync(CancellationToken ct = default);
    Task<JobApplicationResponse> CreateAsync(
        JobApplicationRequest request,
        CancellationToken ct = default
    );
    Task UpdateStatusAsync(
        Guid id,
        JobApplicationStatusRequest request,
        CancellationToken ct = default
    );
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
