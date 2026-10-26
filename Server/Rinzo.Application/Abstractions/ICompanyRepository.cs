using Rinzo.Domain.Companies;

namespace Rinzo.Application.Abstractions;

public interface ICompanyRepository : IRepository<Company>
{
    Task<bool> NameExistsAsync(
        string companyName,
        Guid? excludeId = null,
        CancellationToken ct = default
    );
}
