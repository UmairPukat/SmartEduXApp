namespace SmartEduX.Application.Interfaces.Services;

public interface ITenantService
{
    Task<OperationResponse<IReadOnlyList<TenantDto>>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<OperationResponse<TenantDto?>> GetByIdAsync(long id, CancellationToken cancellationToken = default);

    Task<OperationResponse<TenantDto?>> CreateAsync(CreateTenantDto dto, CancellationToken cancellationToken = default);

    Task<OperationResponse<TenantDto?>> UpdateAsync(long id, UpdateTenantDto dto, CancellationToken cancellationToken = default);

    Task<OperationResponse<TenantDto?>> DeleteAsync(long id, CancellationToken cancellationToken = default);
}
