using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts.V1
{
    public class PersonNameConfiguration : IEntityTypeConfiguration<PersonName>
    {
        public void Configure(EntityTypeBuilder<PersonName> builder)
        {
            builder.ToTable("jblt_personName");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("personname_id");
            builder.Property(e => e.FirstName).HasColumnName("personName_firstname");
            builder.Property(e => e.MiddleName).HasColumnName("personName_middlename");
            builder.Property(e => e.LastName).HasColumnName("personName_lastname");
        }
    }
}
