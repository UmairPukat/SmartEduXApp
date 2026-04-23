namespace SmartEduX.Infrastructure.EntitiesMapping;

public class ApplicationUserMapping
{
    public ApplicationUserMapping(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("ApplicationUsers");
        builder.Property(u => u.UserName).HasMaxLength(256).IsRequired();
        builder.Property(u => u.NormalizedUserName).HasMaxLength(256).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(256);
        builder.Property(u => u.NormalizedEmail).HasMaxLength(256);
    }
}
