using SmartEduX.Infrastructure.Data;

namespace SmartEduX.Infrastructure.Services;

public class CityService : ICityService
{
    private readonly SmartEduXDbContext _context;
    private readonly IMapper _mapper;

    public CityService(SmartEduXDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OperationResponse<IReadOnlyList<CityDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _context.Cities
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .ToListAsync(cancellationToken);

        var dtos = _mapper.Map<List<CityDto>>(list);
        return OperationResponse<IReadOnlyList<CityDto>>.Success(DbReturnValue.ListRetrievedSuccess, dtos);
    }

    public async Task<OperationResponse<IReadOnlyList<CityDto>>> GetByProvinceIdAsync(int provinceId, CancellationToken cancellationToken = default)
    {
        var list = await _context.Cities
            .AsNoTracking()
            .Where(c => c.ProvinceId == provinceId)
            .OrderBy(c => c.Name)
            .ToListAsync(cancellationToken);

        var dtos = _mapper.Map<List<CityDto>>(list);
        return OperationResponse<IReadOnlyList<CityDto>>.Success(DbReturnValue.ListRetrievedSuccess, dtos);
    }

    public async Task<OperationResponse<CityDto?>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Cities.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        if (entity is null)
            return ApiResponse.NotFound<CityDto>(DbReturnValue.CityNotFound);

        return ApiResponse.Ok(DbReturnValue.RetrievedSuccess, _mapper.Map<CityDto>(entity));
    }

    public async Task<OperationResponse<CityDto?>> CreateAsync(CreateCityDto dto, CancellationToken cancellationToken = default)
    {
        if (!await _context.Provinces.AnyAsync(p => p.Id == dto.ProvinceId, cancellationToken))
            return ApiResponse.Fail<CityDto>(DbReturnValue.ReferencedProvinceNotFound);

        var entity = _mapper.Map<City>(dto);
        _context.Cities.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return ApiResponse.OkEmpty<CityDto>(DbReturnValue.CreateSuccess);
    }

    public async Task<OperationResponse<CityDto?>> UpdateAsync(int id, UpdateCityDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Cities.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        if (entity is null)
            return ApiResponse.NotFound<CityDto>(DbReturnValue.CityNotFound);

        if (!await _context.Provinces.AnyAsync(p => p.Id == dto.ProvinceId, cancellationToken))
            return ApiResponse.Fail<CityDto>(DbReturnValue.ReferencedProvinceNotFound);

        _mapper.Map(dto, entity);
        _context.Cities.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return ApiResponse.OkEmpty<CityDto>(DbReturnValue.UpdateSuccess);
    }

    public async Task<OperationResponse<CityDto?>> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Cities.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        if (entity is null)
            return ApiResponse.NotFound<CityDto>(DbReturnValue.CityNotFound);

        if (await _context.Tenants.AnyAsync(t => t.CityId == id, cancellationToken))
            return ApiResponse.Conflict<CityDto>(DbReturnValue.CityDeleteBlockedByTenants);

        _context.Cities.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return ApiResponse.OkEmpty<CityDto>(DbReturnValue.DeleteSuccess);
    }
}
