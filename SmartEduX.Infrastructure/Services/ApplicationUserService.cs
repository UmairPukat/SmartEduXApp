namespace SmartEduX.Infrastructure.Services;

public class ApplicationUserService : IApplicationUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public ApplicationUserService(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<OperationResponse<IReadOnlyList<ApplicationUserDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _userManager.Users
            .AsNoTracking()
            .OrderBy(u => u.UserName)
            .ToListAsync(cancellationToken);

        var dtos = _mapper.Map<List<ApplicationUserDto>>(list);
        return OperationResponse<IReadOnlyList<ApplicationUserDto>>.Success(DbReturnValue.ListRetrievedSuccess, dtos);
    }

    public async Task<OperationResponse<ApplicationUserDto?>> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(id.ToString(CultureInfo.InvariantCulture));
        if (user is null)
            return ApiResponse.NotFound<ApplicationUserDto>(DbReturnValue.ApplicationUserNotFound);

        return ApiResponse.Ok(DbReturnValue.RetrievedSuccess, _mapper.Map<ApplicationUserDto>(user));
    }

    public async Task<OperationResponse<ApplicationUserDto?>> CreateAsync(CreateApplicationUserDto dto, CancellationToken cancellationToken = default)
    {
        var email = string.IsNullOrWhiteSpace(dto.Email)
            ? $"{dto.UserName}@users.internal"
            : dto.Email!;

        var user = new ApplicationUser
        {
            UserName = dto.UserName,
            Email = email,
            PhoneNumber = dto.PhoneNumber,
            EmailConfirmed = true,
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
            return ApiResponse.BadRequest<ApplicationUserDto>(
                result.Errors.Select(e => e.Description));

        return ApiResponse.OkEmpty<ApplicationUserDto>(DbReturnValue.CreateSuccess);
    }

    public async Task<OperationResponse<ApplicationUserDto?>> UpdateAsync(long id, UpdateApplicationUserDto dto, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(id.ToString(CultureInfo.InvariantCulture));
        if (user is null)
            return ApiResponse.NotFound<ApplicationUserDto>(DbReturnValue.ApplicationUserNotFound);

        var email = string.IsNullOrWhiteSpace(dto.Email)
            ? $"{dto.UserName}@users.internal"
            : dto.Email!;

        var nameResult = await _userManager.SetUserNameAsync(user, dto.UserName);
        if (!nameResult.Succeeded)
            return ApiResponse.BadRequest<ApplicationUserDto>(
                nameResult.Errors.Select(e => e.Description));

        var emailResult = await _userManager.SetEmailAsync(user, email);
        if (!emailResult.Succeeded)
            return ApiResponse.BadRequest<ApplicationUserDto>(
                emailResult.Errors.Select(e => e.Description));

        user.PhoneNumber = dto.PhoneNumber;
        var updateResult = await _userManager.UpdateAsync(user);
        if (!updateResult.Succeeded)
            return ApiResponse.BadRequest<ApplicationUserDto>(
                updateResult.Errors.Select(e => e.Description));

        return ApiResponse.OkEmpty<ApplicationUserDto>(DbReturnValue.UpdateSuccess);
    }

    public async Task<OperationResponse<ApplicationUserDto?>> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(id.ToString(CultureInfo.InvariantCulture));
        if (user is null)
            return ApiResponse.NotFound<ApplicationUserDto>(DbReturnValue.ApplicationUserNotFound);

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
            return ApiResponse.BadRequest<ApplicationUserDto>(
                result.Errors.Select(e => e.Description));

        return ApiResponse.OkEmpty<ApplicationUserDto>(DbReturnValue.DeleteSuccess);
    }
}
