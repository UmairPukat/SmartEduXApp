namespace SmartEduX.Application.Interfaces.Services;

public interface IProvinceService
{
    Task<OperationResponse<IReadOnlyList<ProvinceDto>>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<OperationResponse<ProvinceDto?>> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<OperationResponse<ProvinceDto?>> CreateAsync(CreateProvinceDto dto, CancellationToken cancellationToken = default);

    Task<OperationResponse<ProvinceDto?>> UpdateAsync(int id, UpdateProvinceDto dto, CancellationToken cancellationToken = default);
}
