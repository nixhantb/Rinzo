using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Domain.Applications;

namespace Rinzo.Infrastructure.Persistence.Configurations;

public sealed class JobApplicationConfiguration : BaseEntityConfiguration<JobApplication>
{
    protected override void ConfigureEntity(EntityTypeBuilder<JobApplication> builder)
    {
        builder.ToTable("job_applications");

        builder.Property(a => a.SeekerId).IsRequired();
        builder.Property(a => a.CompanyId).IsRequired();
        builder.Property(a => a.JobId).IsRequired();

        // A seeker can only have one application per job.
        builder.HasIndex(a => new { a.SeekerId, a.JobId }).IsUnique();
    }
}
