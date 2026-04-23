namespace SmartEduX.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IApplicationUserService _applicationUserService;

    public UsersController(IApplicationUserService applicationUserService)
    {
        _applicationUserService = applicationUserService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _applicationUserService.GetAllAsync(cancellationToken);
        return response.ToApiResult();
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
    {
        var response = await _applicationUserService.GetByIdAsync(id, cancellationToken);
        return response.ToApiResult();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateApplicationUserDto dto, CancellationToken cancellationToken)
    {
        var response = await _applicationUserService.CreateAsync(dto, cancellationToken);
        return response.ToApiResult();
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateApplicationUserDto dto, CancellationToken cancellationToken)
    {
        var response = await _applicationUserService.UpdateAsync(id, dto, cancellationToken);
        return response.ToApiResult();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var response = await _applicationUserService.DeleteAsync(id, cancellationToken);
        return response.ToApiResult();
    }
}
