namespace SmartEduX.Application.DTOs.Provinces;

public class ProvinceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class CreateProvinceDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}

public class UpdateProvinceDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}
