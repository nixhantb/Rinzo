using Microsoft.EntityFrameworkCore;
using Rinzo.Domain.Applications;
using Rinzo.Domain.Companies;
using Rinzo.Domain.Employers;
using Rinzo.Domain.Jobs;
using Rinzo.Domain.Seekers;

namespace Rinzo.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Employer> Employers => Set<Employer>();
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<JobApplication> Applications => Set<JobApplication>();
    public DbSet<Seeker> Seekers => Set<Seeker>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Finds every IEntityTypeConfiguration in this assembly. A new entity = one
        // new configuration file, no change here.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
