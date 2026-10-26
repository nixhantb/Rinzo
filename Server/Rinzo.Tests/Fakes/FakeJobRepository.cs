using Rinzo.Application.Abstractions;
using Rinzo.Application.Common;
using Rinzo.Domain.Jobs;

namespace Rinzo.Tests.Fakes;

public sealed class FakeJobRepository : IJobRepository
{
    public List<Job> Items { get; } = [];

    public Task<Job?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(Items.FirstOrDefault(j => j.Id == id));

    public Task<PagedResult<Job>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    )
    {
        var pageItems = Items.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return Task.FromResult(new PagedResult<Job>(pageItems, page, pageSize, Items.Count));
    }

    public Task<IReadOnlyList<Job>> ListAsync(CancellationToken ct = default) =>
        Task.FromResult<IReadOnlyList<Job>>(Items.ToList());

    public void Add(Job entity) => Items.Add(entity);

    public void Remove(Job entity) => Items.Remove(entity);
}
