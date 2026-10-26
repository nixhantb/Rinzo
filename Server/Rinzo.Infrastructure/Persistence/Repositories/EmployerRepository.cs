using Rinzo.Application.Abstractions;
using Rinzo.Domain.Employers;

namespace Rinzo.Infrastructure.Persistence.Repositories;

public sealed class EmployerRepository(AppDbContext db)
    : Repository<Employer>(db),
        IEmployerRepository;
