using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts.V1
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("jblt_email");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("email_id");
            builder.Property(e => e.EmailType).HasColumnName("email_type");
            builder.Property(e => e.EmailAddress).HasColumnName("email_address").IsRequired(false);
            ;
        }
    }
}
