namespace SmartEduX.Domain.Entities;

public class Province : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<City> Cities { get; set; }
    public ICollection<Tenant> Tenants { get; set; }
}
