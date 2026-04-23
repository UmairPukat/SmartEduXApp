namespace SmartEduX.Domain.Entities;

public class City : BaseEntity
{
    public int Id { get; set; }
    public int ProvinceId { get; set; }
    public string Name { get; set; }

    public Province Province { get; set; }
    public ICollection<Tenant> Tenants { get; set; }
}
