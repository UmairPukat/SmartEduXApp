namespace SmartEduX.Infrastructure.EntitiesMapping;

public class ProvinceMapping : BaseEntityMapping<Province>
{
    public ProvinceMapping(EntityTypeBuilder<Province> builder) : base(builder)
    {
        builder.ToTable("Provinces");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
    }
}
