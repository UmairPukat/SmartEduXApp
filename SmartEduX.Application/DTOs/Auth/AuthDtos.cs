namespace SmartEduX.Application.DTOs.Auth;

public class SignUpDto
{
    [Required]
    [StringLength(256, MinimumLength = 1)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [StringLength(256, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;
}

public class SignInDto
{
    [Required]
    [StringLength(256, MinimumLength = 1)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
