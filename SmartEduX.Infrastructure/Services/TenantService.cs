using SmartEduX.Infrastructure.Data;

namespace SmartEduX.Infrastructure.Services;

public class TenantService : ITenantService
{
    private readonly SmartEduXDbContext _context;
    private readonly IMapper _mapper;

    public TenantService(SmartEduXDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OperationResponse<IReadOnlyList<TenantDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _context.Tenants
            .AsNoTracking()
            .OrderByDescending(t => t.CreatedDate)
            .ToListAsync(cancellationToken);

        var dtos = _mapper.Map<List<TenantDto>>(list);
        return OperationResponse<IReadOnlyList<TenantDto>>.Success(DbReturnValue.ListRetrievedSuccess, dtos);
    }

    public async Task<OperationResponse<TenantDto?>> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Tenants.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        if (entity is null)
            return ApiResponse.NotFound<TenantDto>(DbReturnValue.TenantNotFound);

        return ApiResponse.Ok(DbReturnValue.RetrievedSuccess, _mapper.Map<TenantDto>(entity));
    }

    public async Task<OperationResponse<TenantDto?>> CreateAsync(CreateTenantDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Tenant>(dto);

        _context.Tenants.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return ApiResponse.OkEmpty<TenantDto>(DbReturnValue.CreateSuccess);
    }

    public async Task<OperationResponse<TenantDto?>> UpdateAsync(long id, UpdateTenantDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Tenants.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        if (entity is null)
            return ApiResponse.NotFound<TenantDto>(DbReturnValue.TenantNotFound);

        _mapper.Map(dto, entity);
        _context.Tenants.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return ApiResponse.OkEmpty<TenantDto>(DbReturnValue.UpdateSuccess);
    }

    public async Task<OperationResponse<TenantDto?>> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Tenants.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        if (entity is null)
            return ApiResponse.NotFound<TenantDto>(DbReturnValue.TenantNotFound);

        _context.Tenants.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return ApiResponse.OkEmpty<TenantDto>(DbReturnValue.DeleteSuccess);
    }
}
