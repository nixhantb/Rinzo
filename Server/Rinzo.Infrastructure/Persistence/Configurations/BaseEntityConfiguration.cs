using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rinzo.Domain.Common;

namespace Rinzo.Infrastructure.Persistence.Configurations;

// Template Method: the fixed steps that run for every entity live here; each
// subclass fills in the one step that is specific to it (ConfigureEntity).
public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
    where T : BaseEntity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CreatedOn).IsRequired();
        builder.Ignore(e => e.DomainEvents); // events are not stored in a table

        ConfigureEntity(builder);
    }

    protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
}
