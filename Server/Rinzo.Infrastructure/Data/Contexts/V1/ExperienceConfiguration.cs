using Rinzo.Core.Entities.Common.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rinzo.Infrastructure.Data.Contexts.V1
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.ToTable("jblt_experience");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("experience_id");
            builder.Property(e => e.ExperienceLevel).HasColumnName("experience_type");
        }
    }
}
