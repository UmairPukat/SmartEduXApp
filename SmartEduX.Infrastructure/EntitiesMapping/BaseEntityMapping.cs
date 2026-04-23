namespace SmartEduX.Infrastructure.EntitiesMapping;

public abstract class BaseEntityMapping<TEntity> where TEntity : BaseEntity
{
    protected BaseEntityMapping(EntityTypeBuilder<TEntity> builder)
    {
        ConfigureBase(builder);
    }

    protected virtual void ConfigureBase(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(x => x.CreatedBy).HasDefaultValue(0L);
        builder.Property(x => x.CreatedDate).HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.DeletedBy);
        builder.Property(x => x.DeletedDate);
        builder.Property(x => x.UpdatedBy);
        builder.Property(x => x.UpdatedDate);
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.LanguageCode).HasMaxLength(32).HasDefaultValue("");
    }
}
