namespace SmartEduX.Infrastructure.EntitiesMapping;

public class TenantMapping : BaseEntityMapping<Tenant>
{
    public TenantMapping(EntityTypeBuilder<Tenant> builder) : base(builder)
    {
        builder.ToTable("Tenants");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();

        builder.HasOne(x => x.Province)
            .WithMany(x => x.Tenants)
            .HasForeignKey(x => x.ProvinceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.City)
            .WithMany(x => x.Tenants)
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
