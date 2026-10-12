using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Entities.Companies.V1;

namespace Rinzo.Infrastructure.Data.Contexts.V1
{
    public class CompanyProfileConfiguration : IEntityTypeConfiguration<CompanyProfile>
    {
        public void Configure(EntityTypeBuilder<CompanyProfile> builder)
        {
            builder.ToTable("jblt_companyprofile");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("companyprofile_id");
            builder.Property(e => e.Website).HasColumnName("company_website");
        }
    }
}
