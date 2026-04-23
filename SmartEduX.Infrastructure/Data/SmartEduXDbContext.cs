namespace SmartEduX.Infrastructure.Data;

public class SmartEduXDbContext : IdentityDbContext<
    ApplicationUser,
    ApplicationRole,
    long,
    IdentityUserClaim<long>,
    ApplicationUserRole,
    IdentityUserLogin<long>,
    IdentityRoleClaim<long>,
    IdentityUserToken<long>>
{
    public SmartEduXDbContext(DbContextOptions<SmartEduXDbContext> options)
        : base(options)
    {
    }

    public DbSet<Province> Provinces => Set<Province>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Tenant> Tenants => Set<Tenant>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        new ApplicationUserMapping(builder.Entity<ApplicationUser>());
        new ApplicationRoleMapping(builder.Entity<ApplicationRole>());
        new ApplicationUserRoleMapping(builder.Entity<ApplicationUserRole>());

        new ProvinceMapping(builder.Entity<Province>());
        new CityMapping(builder.Entity<City>());
        new TenantMapping(builder.Entity<Tenant>());
    }
}
