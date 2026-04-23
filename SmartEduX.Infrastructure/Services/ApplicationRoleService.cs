namespace SmartEduX.Infrastructure.Services;

public class ApplicationRoleService : IApplicationRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IMapper _mapper;

    public ApplicationRoleService(RoleManager<ApplicationRole> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task<OperationResponse<IReadOnlyList<ApplicationRoleDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _roleManager.Roles
            .AsNoTracking()
            .OrderBy(r => r.Name)
            .ToListAsync(cancellationToken);

        var dtos = _mapper.Map<List<ApplicationRoleDto>>(list);
        return OperationResponse<IReadOnlyList<ApplicationRoleDto>>.Success(DbReturnValue.ListRetrievedSuccess, dtos);
    }

    public async Task<OperationResponse<ApplicationRoleDto?>> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString(CultureInfo.InvariantCulture));
        if (role is null)
            return ApiResponse.NotFound<ApplicationRoleDto>(DbReturnValue.ApplicationRoleNotFound);

        return ApiResponse.Ok(DbReturnValue.RetrievedSuccess, _mapper.Map<ApplicationRoleDto>(role));
    }

    public async Task<OperationResponse<ApplicationRoleDto?>> CreateAsync(CreateApplicationRoleDto dto, CancellationToken cancellationToken = default)
    {
        var role = new ApplicationRole { Name = dto.Name };
        var result = await _roleManager.CreateAsync(role);
        if (!result.Succeeded)
            return ApiResponse.BadRequest<ApplicationRoleDto>(
                result.Errors.Select(e => e.Description));

        return ApiResponse.OkEmpty<ApplicationRoleDto>(DbReturnValue.CreateSuccess);
    }

    public async Task<OperationResponse<ApplicationRoleDto?>> UpdateAsync(long id, UpdateApplicationRoleDto dto, CancellationToken cancellationToken = default)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString(CultureInfo.InvariantCulture));
        if (role is null)
            return ApiResponse.NotFound<ApplicationRoleDto>(DbReturnValue.ApplicationRoleNotFound);

        role.Name = dto.Name;
        var result = await _roleManager.UpdateAsync(role);
        if (!result.Succeeded)
            return ApiResponse.BadRequest<ApplicationRoleDto>(
                result.Errors.Select(e => e.Description));

        return ApiResponse.OkEmpty<ApplicationRoleDto>(DbReturnValue.UpdateSuccess);
    }

    public async Task<OperationResponse<ApplicationRoleDto?>> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString(CultureInfo.InvariantCulture));
        if (role is null)
            return ApiResponse.NotFound<ApplicationRoleDto>(DbReturnValue.ApplicationRoleNotFound);

        var result = await _roleManager.DeleteAsync(role);
        if (!result.Succeeded)
            return ApiResponse.BadRequest<ApplicationRoleDto>(
                result.Errors.Select(e => e.Description));

        return ApiResponse.OkEmpty<ApplicationRoleDto>(DbReturnValue.DeleteSuccess);
    }
}
