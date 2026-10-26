using Rinzo.Application.Abstractions;
using Rinzo.Domain.Jobs;

namespace Rinzo.Infrastructure.Persistence.Repositories;

public sealed class JobRepository(AppDbContext db) : Repository<Job>(db), IJobRepository;
