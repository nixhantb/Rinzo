using Rinzo.Application.Common;

namespace Rinzo.Application.Seekers;

public interface ISeekerService
{
    Task<SeekerResponse> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<SeekerResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    );
    Task<IReadOnlyList<SeekerResponse>> ListAllAsync(CancellationToken ct = default);
    Task<SeekerResponse> CreateAsync(SeekerRequest request, CancellationToken ct = default);
    Task UpdateAsync(Guid id, SeekerRequest request, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
