namespace SmartEduX.Domain.Entities;

public class Tenant : BaseEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int ProvinceId { get; set; }
    public int CityId { get; set; }

    public Province Province { get; set; }
    public City City { get; set; }
}
