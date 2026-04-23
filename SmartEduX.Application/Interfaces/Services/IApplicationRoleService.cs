namespace SmartEduX.Application.Interfaces.Services;

public interface IApplicationRoleService
{
    Task<OperationResponse<IReadOnlyList<ApplicationRoleDto>>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<OperationResponse<ApplicationRoleDto?>> GetByIdAsync(long id, CancellationToken cancellationToken = default);

    Task<OperationResponse<ApplicationRoleDto?>> CreateAsync(CreateApplicationRoleDto dto, CancellationToken cancellationToken = default);

    Task<OperationResponse<ApplicationRoleDto?>> UpdateAsync(long id, UpdateApplicationRoleDto dto, CancellationToken cancellationToken = default);

    Task<OperationResponse<ApplicationRoleDto?>> DeleteAsync(long id, CancellationToken cancellationToken = default);
}
