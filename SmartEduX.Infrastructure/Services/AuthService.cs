namespace SmartEduX.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IMapper _mapper;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    public async Task<OperationResponse<ApplicationUserDto?>> SignUpAsync(SignUpDto dto, CancellationToken cancellationToken = default)
    {
        var user = new ApplicationUser
        {
            UserName = dto.UserName,
            Email = $"{dto.UserName}@users.internal",
            EmailConfirmed = true,
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
            return ApiResponse.BadRequest<ApplicationUserDto>(
                result.Errors.Select(e => e.Description));

        await _signInManager.SignInAsync(user, isPersistent: false);
        return ApiResponse.Ok(DbReturnValue.SignUpSuccess, _mapper.Map<ApplicationUserDto>(user));
    }

    public async Task<OperationResponse<ApplicationUserDto?>> SignInAsync(SignInDto dto, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByNameAsync(dto.UserName);
        if (user is null)
            return ApiResponse.Fail<ApplicationUserDto>(DbReturnValue.SignInInvalidCredentials);

        var check = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure: true);
        if (check.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return ApiResponse.Ok(DbReturnValue.SignInSuccess, _mapper.Map<ApplicationUserDto>(user));
        }

        if (check.IsLockedOut)
            return ApiResponse.Fail<ApplicationUserDto>(DbReturnValue.SignInLockedOut);

        if (check.IsNotAllowed)
            return ApiResponse.Fail<ApplicationUserDto>(DbReturnValue.SignInNotAllowed);

        return ApiResponse.Fail<ApplicationUserDto>(DbReturnValue.SignInInvalidCredentials);
    }
}
