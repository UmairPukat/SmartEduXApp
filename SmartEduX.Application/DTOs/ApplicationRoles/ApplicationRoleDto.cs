namespace SmartEduX.Application.DTOs.ApplicationRoles;

public class ApplicationRoleDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class CreateApplicationRoleDto
{
    [Required]
    [StringLength(256, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;
}

public class UpdateApplicationRoleDto
{
    [Required]
    [StringLength(256, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;
}
