namespace SmartEduX.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = AppRoles.SuperAdmin)]
public class TenantsController : ControllerBase
{
    private readonly ITenantService _tenantService;

    public TenantsController(ITenantService tenantService)
    {
        _tenantService = tenantService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _tenantService.GetAllAsync(cancellationToken);
        return response.ToApiResult();
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
    {
        var response = await _tenantService.GetByIdAsync(id, cancellationToken);
        return response.ToApiResult();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTenantDto dto, CancellationToken cancellationToken)
    {
        var response = await _tenantService.CreateAsync(dto, cancellationToken);
        return response.ToApiResult();
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateTenantDto dto, CancellationToken cancellationToken)
    {
        var response = await _tenantService.UpdateAsync(id, dto, cancellationToken);
        return response.ToApiResult();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var response = await _tenantService.DeleteAsync(id, cancellationToken);
        return response.ToApiResult();
    }
}
