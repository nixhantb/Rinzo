using Rinzo.Domain.Applications;

namespace Rinzo.Application.Abstractions;

public interface IApplicationRepository : IRepository<JobApplication>
{
    // A seeker should not be able to apply twice to the same job.
    Task<bool> ExistsAsync(Guid seekerId, Guid jobId, CancellationToken ct = default);
}
