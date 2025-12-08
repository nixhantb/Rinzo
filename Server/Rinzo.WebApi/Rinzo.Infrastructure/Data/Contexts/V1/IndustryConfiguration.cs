using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts.V1
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
