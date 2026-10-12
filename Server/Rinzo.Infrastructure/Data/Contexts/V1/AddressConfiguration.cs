using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Core.Entities.Common.V1;

namespace Rinzo.Infrastructure.Data.Contexts.V1
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("jblt_userAddress");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("address_id");
            builder.Property(e => e.Street).HasColumnName("address_street");
            builder.Property(e => e.City).HasColumnName("address_city");
            builder.Property(e => e.State).HasColumnName("address_state");
            builder.Property(e => e.PostalCode).HasColumnName("address_postalCode");
            builder.Property(e => e.Country).HasColumnName("address_country");
        }
    }
}
