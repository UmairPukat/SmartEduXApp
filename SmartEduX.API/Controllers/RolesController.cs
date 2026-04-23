namespace SmartEduX.API.Controllers;

[ApiController]
[Route("api/roles")]
public class RolesController : ControllerBase
{
    private readonly IApplicationRoleService _applicationRoleService;

    public RolesController(IApplicationRoleService applicationRoleService)
    {
        _applicationRoleService = applicationRoleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _applicationRoleService.GetAllAsync(cancellationToken);
        return response.ToApiResult();
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
    {
        var response = await _applicationRoleService.GetByIdAsync(id, cancellationToken);
        return response.ToApiResult();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateApplicationRoleDto dto, CancellationToken cancellationToken)
    {
        var response = await _applicationRoleService.CreateAsync(dto, cancellationToken);
        return response.ToApiResult();
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateApplicationRoleDto dto, CancellationToken cancellationToken)
    {
        var response = await _applicationRoleService.UpdateAsync(id, dto, cancellationToken);
        return response.ToApiResult();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var response = await _applicationRoleService.DeleteAsync(id, cancellationToken);
        return response.ToApiResult();
    }
}
