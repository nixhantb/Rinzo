using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Core.Entities.Companies;

namespace Rinzo.Infrastructure.Data.Contexts
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("jblt_company");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("company_id");
            builder.Property(e => e.CompanyName).HasColumnName("company_name");
        }
    }
}
