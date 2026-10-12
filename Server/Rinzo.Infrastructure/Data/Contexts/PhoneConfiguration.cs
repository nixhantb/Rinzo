using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Core.Entities.Common;

namespace Rinzo.Infrastructure.Data.Contexts
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
