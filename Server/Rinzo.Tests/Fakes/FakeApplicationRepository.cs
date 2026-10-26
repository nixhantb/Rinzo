using Rinzo.Application.Abstractions;
using Rinzo.Application.Common;
using Rinzo.Domain.Applications;

namespace Rinzo.Tests.Fakes;

public sealed class FakeApplicationRepository : IApplicationRepository
{
    public List<JobApplication> Items { get; } = [];

    public Task<JobApplication?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(Items.FirstOrDefault(a => a.Id == id));

    public Task<PagedResult<JobApplication>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    )
    {
        var pageItems = Items.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return Task.FromResult(
            new PagedResult<JobApplication>(pageItems, page, pageSize, Items.Count)
        );
    }

    public Task<IReadOnlyList<JobApplication>> ListAsync(CancellationToken ct = default) =>
        Task.FromResult<IReadOnlyList<JobApplication>>(Items.ToList());

    public void Add(JobApplication entity) => Items.Add(entity);

    public void Remove(JobApplication entity) => Items.Remove(entity);

    public Task<bool> ExistsAsync(Guid seekerId, Guid jobId, CancellationToken ct = default) =>
        Task.FromResult(Items.Any(a => a.SeekerId == seekerId && a.JobId == jobId));
}
