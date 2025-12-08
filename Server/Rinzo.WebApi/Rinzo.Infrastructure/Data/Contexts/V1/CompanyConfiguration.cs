using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts.V1
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
