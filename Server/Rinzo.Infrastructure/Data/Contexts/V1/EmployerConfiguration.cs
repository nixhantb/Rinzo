using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Core.Entities.Companies.V1;
using Rinzo.Core.Entities.Employers.V1;

namespace Rinzo.Infrastructure.Data.Contexts.V1
{
    public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.ToTable("jblt_employer");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("employer_id");
        }
    }
}
