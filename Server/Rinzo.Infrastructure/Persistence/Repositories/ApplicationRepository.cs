using Microsoft.EntityFrameworkCore;
using Rinzo.Application.Abstractions;
using Rinzo.Domain.Applications;

namespace Rinzo.Infrastructure.Persistence.Repositories;

public sealed class ApplicationRepository(AppDbContext db)
    : Repository<JobApplication>(db),
        IApplicationRepository
{
    public Task<bool> ExistsAsync(Guid seekerId, Guid jobId, CancellationToken ct = default) =>
        Set.AnyAsync(a => a.SeekerId == seekerId && a.JobId == jobId, ct);
}
