using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hupo.Template.Infrastructure.Data.Configurations;

internal static class EntityConfigurationExtensions
{
    internal static void ConfigureBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IEntity
    {
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedOnAdd();
    }

    internal static void ConfigureCreateAuditable<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, ICreateAuditable
    {
        builder.Property(entity => entity.CreatedBy);
        builder.Property(entity => entity.CreatedTime).IsRequired();
    }

    internal static void ConfigureModifyAuditable<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IModifyAuditable
    {
        builder.Property(entity => entity.LastModifiedBy);
        builder.Property(entity => entity.LastModifiedDate);
    }

    internal static void ConfigureDeleteAuditable<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IDeleteAuditable
    {
        builder.Property(entity => entity.IsDeleted).IsRequired().HasDefaultValue(false);
        builder.Property(entity => entity.DeletedBy);
        builder.Property(entity => entity.DeletedDate);
    }

    internal static void ConfigureConcurrencyStamp<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IConcurrencyStamp
    {
        builder.Property(entity => entity.ConcurrencyStamp).IsConcurrencyToken();
    }

    internal static void ConfigureAuditable<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : AuditableEntity
    {
        builder.ConfigureBaseEntity();
        builder.ConfigureCreateAuditable();
        builder.ConfigureModifyAuditable();
        builder.ConfigureDeleteAuditable();
        builder.ConfigureConcurrencyStamp();
    }
}
