namespace SmartEduX.Application.Interfaces.Services;

public interface IApplicationUserService
{
    Task<OperationResponse<IReadOnlyList<ApplicationUserDto>>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<OperationResponse<ApplicationUserDto?>> GetByIdAsync(long id, CancellationToken cancellationToken = default);

    Task<OperationResponse<ApplicationUserDto?>> CreateAsync(CreateApplicationUserDto dto, CancellationToken cancellationToken = default);

    Task<OperationResponse<ApplicationUserDto?>> UpdateAsync(long id, UpdateApplicationUserDto dto, CancellationToken cancellationToken = default);

    Task<OperationResponse<ApplicationUserDto?>> DeleteAsync(long id, CancellationToken cancellationToken = default);
}
