using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Core.Entities.Companies;
using Rinzo.Core.Entities.Employers;

namespace Rinzo.Infrastructure.Data.Contexts
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
