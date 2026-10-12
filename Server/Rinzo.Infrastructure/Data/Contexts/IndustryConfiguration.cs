using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Core.Entities.Companies;

namespace Rinzo.Infrastructure.Data.Contexts
{
    public class IndustryConfiguration : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> builder)
        {
            builder.ToTable("jblt_industryType");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("industry_id");
            builder.Property(e => e.IndustryType).HasColumnName("industry_type");
        }
    }
}
