using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Core.Entities.Seekers;

namespace Rinzo.Infrastructure.Repositories.Seekers
{
    public class SeekersConfiguration : IEntityTypeConfiguration<Seeker>
    {
        public void Configure(EntityTypeBuilder<Seeker> builder)
        {
            builder.ToTable("jblt_seeker");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("seeker_id");
        }
    }
}
