namespace SmartEduX.Application.Interfaces.Services;

public interface ICityService
{
    Task<OperationResponse<IReadOnlyList<CityDto>>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<OperationResponse<IReadOnlyList<CityDto>>> GetByProvinceIdAsync(int provinceId, CancellationToken cancellationToken = default);

    Task<OperationResponse<CityDto?>> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<OperationResponse<CityDto?>> CreateAsync(CreateCityDto dto, CancellationToken cancellationToken = default);

    Task<OperationResponse<CityDto?>> UpdateAsync(int id, UpdateCityDto dto, CancellationToken cancellationToken = default);

    Task<OperationResponse<CityDto?>> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
