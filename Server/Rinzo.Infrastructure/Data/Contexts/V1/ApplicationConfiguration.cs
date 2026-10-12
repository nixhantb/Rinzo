using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Core.Entities.Jobs.V1;

namespace Rinzo.Infrastructure.Data.Contexts.V1
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("jblt_application");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("application_id");
        }
    }
}
