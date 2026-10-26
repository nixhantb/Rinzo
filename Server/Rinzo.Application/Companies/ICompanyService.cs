using Rinzo.Application.Common;

namespace Rinzo.Application.Companies;

public interface ICompanyService
{
    Task<CompanyResponse> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<CompanyResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    );
    Task<IReadOnlyList<CompanyResponse>> ListAllAsync(CancellationToken ct = default);
    Task<CompanyResponse> CreateAsync(CompanyRequest request, CancellationToken ct = default);
    Task UpdateAsync(Guid id, CompanyRequest request, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
