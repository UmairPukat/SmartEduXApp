namespace SmartEduX.Application.DTOs.Cities;

public class CityDto
{
    public int Id { get; set; }
    public int ProvinceId { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class CreateCityDto
{
    [Required]
    public int ProvinceId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}

public class UpdateCityDto
{
    [Required]
    public int ProvinceId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}
