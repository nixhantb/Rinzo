using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts.V1
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("jblt_education");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("education_id");
            builder.Property(e => e.Degree).HasColumnName("education_degree");
            builder.Property(e => e.Major).HasColumnName("education_major");
            builder.Property(e => e.Institution).HasColumnName("education_nstitution");
            builder.Property(e => e.GraduationDate).HasColumnName("education_graduationdate");
            builder.Property(e => e.Cgpa).HasColumnName("education_cgpa");
        }
    }
}
