using Microsoft.EntityFrameworkCore;
using Rinzo.Application.Abstractions;
using Rinzo.Domain.Companies;

namespace Rinzo.Infrastructure.Persistence.Repositories;

public sealed class CompanyRepository(AppDbContext db) : Repository<Company>(db), ICompanyRepository
{
    public Task<bool> NameExistsAsync(
        string companyName,
        Guid? excludeId = null,
        CancellationToken ct = default
    )
    {
        var name = companyName.Trim();
        return Set.AnyAsync(c => c.CompanyName == name && c.Id != excludeId, ct);
    }
}
