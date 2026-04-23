namespace SmartEduX.Infrastructure.EntitiesMapping;

public class CityMapping : BaseEntityMapping<City>
{
    public CityMapping(EntityTypeBuilder<City> builder) : base(builder)
    {
        builder.ToTable("Cities");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

        builder.HasOne(x => x.Province)
            .WithMany(x => x.Cities)
            .HasForeignKey(x => x.ProvinceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
