using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Domain.Seekers;

namespace Rinzo.Infrastructure.Persistence.Configurations;

public sealed class SeekerConfiguration : BaseEntityConfiguration<Seeker>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Seeker> builder)
    {
        builder.ToTable("seekers");

        builder.OwnsOne(s => s.PersonName);
        builder.OwnsOne(s => s.Phone);
        builder.OwnsOne(s => s.Address);
        builder.OwnsMany(s => s.Skills, o => o.ToTable("seeker_skills"));
        builder.OwnsMany(s => s.Education, o => o.ToTable("seeker_education"));
        builder.OwnsMany(s => s.Experience, o => o.ToTable("seeker_experience"));
        builder.OwnsMany(s => s.Qualifications, o => o.ToTable("seeker_qualifications"));
        builder.OwnsMany(s => s.SocialMedias, o => o.ToTable("seeker_social_medias"));
        builder.OwnsMany(s => s.Projects, o => o.ToTable("seeker_projects"));
    }
}
