using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Core.Entities.Common.V1;

namespace Rinzo.Infrastructure.Data.Contexts.V1
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("jblt_skill");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("skill_id");

            var valueComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()
            );
            builder
                .Property(e => e.Title)
                .HasColumnName("title")
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
                )
                .Metadata.SetValueComparer(valueComparer);
            builder
                .Property(e => e.Description)
                .HasColumnName("description")
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
                )
                .Metadata.SetValueComparer(valueComparer);
        }
    }
}
