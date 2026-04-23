namespace SmartEduX.Infrastructure.EntitiesMapping;

public class ApplicationRoleMapping
{
    public ApplicationRoleMapping(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("ApplicationRoles");
        builder.Property(r => r.Name).HasMaxLength(256).IsRequired();
        builder.Property(r => r.NormalizedName).HasMaxLength(256).IsRequired();
    }
}
