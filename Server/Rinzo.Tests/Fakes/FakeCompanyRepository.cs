using Rinzo.Application.Abstractions;
using Rinzo.Application.Common;
using Rinzo.Domain.Companies;

namespace Rinzo.Tests.Fakes;

// A tiny in-memory "database": a List.
public sealed class FakeCompanyRepository : ICompanyRepository
{
    public List<Company> Items { get; } = [];

    public Task<Company?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(Items.FirstOrDefault(c => c.Id == id));

    public Task<PagedResult<Company>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    )
    {
        var pageItems = Items.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return Task.FromResult(new PagedResult<Company>(pageItems, page, pageSize, Items.Count));
    }

    public Task<IReadOnlyList<Company>> ListAsync(CancellationToken ct = default) =>
        Task.FromResult<IReadOnlyList<Company>>(Items.ToList());

    public void Add(Company entity) => Items.Add(entity);

    public void Remove(Company entity) => Items.Remove(entity);

    public Task<bool> NameExistsAsync(
        string companyName,
        Guid? excludeId = null,
        CancellationToken ct = default
    ) => Task.FromResult(Items.Any(c => c.CompanyName == companyName.Trim() && c.Id != excludeId));
}
