using SmartEduX.Infrastructure.Data;

namespace SmartEduX.Infrastructure.Services;

public class ProvinceService : IProvinceService
{
    private readonly SmartEduXDbContext _context;
    private readonly IMapper _mapper;

    public ProvinceService(SmartEduXDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OperationResponse<IReadOnlyList<ProvinceDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _context.Provinces
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);

        var dtos = _mapper.Map<List<ProvinceDto>>(list);
        return OperationResponse<IReadOnlyList<ProvinceDto>>.Success(DbReturnValue.ListRetrievedSuccess, dtos);
    }

    public async Task<OperationResponse<ProvinceDto?>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Provinces.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (entity is null)
            return ApiResponse.NotFound<ProvinceDto>(DbReturnValue.ProvinceNotFound);

        return ApiResponse.Ok(DbReturnValue.RetrievedSuccess, _mapper.Map<ProvinceDto>(entity));
    }

    public async Task<OperationResponse<ProvinceDto?>> CreateAsync(CreateProvinceDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Province>(dto);
        _context.Provinces.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return ApiResponse.OkEmpty<ProvinceDto>(DbReturnValue.CreateSuccess);
    }

    public async Task<OperationResponse<ProvinceDto?>> UpdateAsync(int id, UpdateProvinceDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Provinces.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (entity is null)
            return ApiResponse.NotFound<ProvinceDto>(DbReturnValue.ProvinceNotFound);

        _mapper.Map(dto, entity);
        _context.Provinces.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return ApiResponse.OkEmpty<ProvinceDto>(DbReturnValue.UpdateSuccess);
    }
}
