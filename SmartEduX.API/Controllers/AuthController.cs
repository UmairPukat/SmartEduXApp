namespace SmartEduX.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpDto dto, CancellationToken cancellationToken)
    {
        var response = await _authService.SignUpAsync(dto, cancellationToken);
        return response.ToApiResult();
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInDto dto, CancellationToken cancellationToken)
    {
        var response = await _authService.SignInAsync(dto, cancellationToken);
        return response.ToApiResult();
    }
}
