using Rinzo.Application.Common;

namespace Rinzo.Application.Employers;

public interface IEmployerService
{
    Task<EmployerResponse> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<EmployerResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    );
    Task<IReadOnlyList<EmployerResponse>> ListAllAsync(CancellationToken ct = default);
    Task<EmployerResponse> CreateAsync(EmployerRequest request, CancellationToken ct = default);
    Task UpdateAsync(Guid id, EmployerRequest request, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
