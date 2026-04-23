namespace SmartEduX.Application.DTOs.Tenants;

public class TenantDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ProvinceId { get; set; }
    public int CityId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class CreateTenantDto
{
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int ProvinceId { get; set; }

    [Required]
    public int CityId { get; set; }

    public bool IsActive { get; set; } = true;
}

public class UpdateTenantDto
{
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int ProvinceId { get; set; }

    [Required]
    public int CityId { get; set; }

    public bool IsActive { get; set; } = true;
}
