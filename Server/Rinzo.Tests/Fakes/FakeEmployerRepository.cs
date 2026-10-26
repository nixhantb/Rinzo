using Rinzo.Application.Abstractions;
using Rinzo.Application.Common;
using Rinzo.Domain.Employers;

namespace Rinzo.Tests.Fakes;

public sealed class FakeEmployerRepository : IEmployerRepository
{
    public List<Employer> Items { get; } = [];

    public Task<Employer?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(Items.FirstOrDefault(e => e.Id == id));

    public Task<PagedResult<Employer>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    )
    {
        var pageItems = Items.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return Task.FromResult(new PagedResult<Employer>(pageItems, page, pageSize, Items.Count));
    }

    public Task<IReadOnlyList<Employer>> ListAsync(CancellationToken ct = default) =>
        Task.FromResult<IReadOnlyList<Employer>>(Items.ToList());

    public void Add(Employer entity) => Items.Add(entity);

    public void Remove(Employer entity) => Items.Remove(entity);
}
