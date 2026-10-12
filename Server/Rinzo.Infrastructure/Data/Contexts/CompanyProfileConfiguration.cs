using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Entities.Companies;

namespace Rinzo.Infrastructure.Data.Contexts
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
