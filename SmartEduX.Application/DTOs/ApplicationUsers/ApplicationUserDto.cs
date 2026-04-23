namespace SmartEduX.Application.DTOs.ApplicationUsers;

public class ApplicationUserDto
{
    public long Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}

public class CreateApplicationUserDto
{
    [Required]
    [StringLength(256, MinimumLength = 1)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [StringLength(256, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;

    [StringLength(256)]
    [EmailAddress]
    public string? Email { get; set; }

    [StringLength(32)]
    public string? PhoneNumber { get; set; }
}

public class UpdateApplicationUserDto
{
    [Required]
    [StringLength(256, MinimumLength = 1)]
    public string UserName { get; set; } = string.Empty;

    [StringLength(256)]
    [EmailAddress]
    public string? Email { get; set; }

    [StringLength(32)]
    public string? PhoneNumber { get; set; }
}
