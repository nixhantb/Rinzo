using Rinzo.Application.Abstractions;
using Rinzo.Application.Common;
using Rinzo.Domain.Seekers;

namespace Rinzo.Tests.Fakes;

public sealed class FakeSeekerRepository : ISeekerRepository
{
    public List<Seeker> Items { get; } = [];

    public Task<Seeker?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(Items.FirstOrDefault(s => s.Id == id));

    public Task<PagedResult<Seeker>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    )
    {
        var pageItems = Items.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return Task.FromResult(new PagedResult<Seeker>(pageItems, page, pageSize, Items.Count));
    }

    public Task<IReadOnlyList<Seeker>> ListAsync(CancellationToken ct = default) =>
        Task.FromResult<IReadOnlyList<Seeker>>(Items.ToList());

    public void Add(Seeker entity) => Items.Add(entity);

    public void Remove(Seeker entity) => Items.Remove(entity);
}
