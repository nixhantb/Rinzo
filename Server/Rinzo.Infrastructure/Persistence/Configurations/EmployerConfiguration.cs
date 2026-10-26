using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Domain.Employers;

namespace Rinzo.Infrastructure.Persistence.Configurations;

public sealed class EmployerConfiguration : BaseEntityConfiguration<Employer>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Employer> builder)
    {
        builder.ToTable("employers");

        builder.Property(e => e.CompanyId).IsRequired();
        builder.HasIndex(e => e.CompanyId);

        builder.OwnsOne(e => e.Name);
        builder.OwnsOne(e => e.EmployerAddress);
        builder.OwnsOne(e => e.EmployerPhone);
    }
}
