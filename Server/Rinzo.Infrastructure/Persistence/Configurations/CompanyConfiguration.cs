using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Domain.Companies;

namespace Rinzo.Infrastructure.Persistence.Configurations;

public sealed class CompanyConfiguration : BaseEntityConfiguration<Company>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("companies");

        builder.Property(c => c.CompanyName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Website).HasMaxLength(200);
        builder.HasIndex(c => c.CompanyName).IsUnique();

        builder.OwnsOne(c => c.CompanyAddress);
        builder.OwnsOne(c => c.ContactPhone);
        builder.OwnsOne(c => c.ContactEmail);
    }
}
