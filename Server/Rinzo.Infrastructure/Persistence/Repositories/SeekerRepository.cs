using Rinzo.Application.Abstractions;
using Rinzo.Domain.Seekers;

namespace Rinzo.Infrastructure.Persistence.Repositories;

public sealed class SeekerRepository(AppDbContext db) : Repository<Seeker>(db), ISeekerRepository;
