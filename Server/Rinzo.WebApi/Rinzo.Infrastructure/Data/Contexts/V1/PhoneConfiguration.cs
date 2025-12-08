using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts.V1
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("jblt_phone");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("jblt_phoneid");
            builder.Property(e => e.CountryCode).HasColumnName("jblt_countrycode");
            builder.Property(e => e.PhoneNumber).HasColumnName("jblt_phonenumber");
        }
    }
}
