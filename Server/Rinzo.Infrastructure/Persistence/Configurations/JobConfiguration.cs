using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Domain.Jobs;

namespace Rinzo.Infrastructure.Persistence.Configurations;

public sealed class JobConfiguration : BaseEntityConfiguration<Job>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable("jobs");

        builder.Property(j => j.CompanyId).IsRequired();
        builder.Property(j => j.JobTitle).HasMaxLength(150).IsRequired();
        builder.Property(j => j.JobType).HasMaxLength(50).IsRequired();
        builder.HasIndex(j => j.CompanyId);

        builder.OwnsOne(j => j.JobAddress);
        builder.OwnsOne(j => j.BasicPay);
        builder.OwnsMany(j => j.RequiredSkills, o => o.ToTable("job_required_skills"));
        builder.OwnsMany(
            j => j.RequiredQualifications,
            o => o.ToTable("job_required_qualifications")
        );
    }
}
