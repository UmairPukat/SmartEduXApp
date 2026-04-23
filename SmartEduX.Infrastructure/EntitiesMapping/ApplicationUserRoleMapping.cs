namespace SmartEduX.Infrastructure.EntitiesMapping;

public class ApplicationUserRoleMapping
{
    public ApplicationUserRoleMapping(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        builder.ToTable("ApplicationUserRoles");
    }
}
