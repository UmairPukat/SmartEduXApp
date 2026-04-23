namespace SmartEduX.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = AppRoles.SuperAdmin)]
public class ProvincesController : ControllerBase
{
    private readonly IProvinceService _provinceService;

    public ProvincesController(IProvinceService provinceService)
    {
        _provinceService = provinceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _provinceService.GetAllAsync(cancellationToken);
        return response.ToApiResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var response = await _provinceService.GetByIdAsync(id, cancellationToken);
        return response.ToApiResult();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProvinceDto dto, CancellationToken cancellationToken)
    {
        var response = await _provinceService.CreateAsync(dto, cancellationToken);
        return response.ToApiResult();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProvinceDto dto, CancellationToken cancellationToken)
    {
        var response = await _provinceService.UpdateAsync(id, dto, cancellationToken);
        return response.ToApiResult();
    }
}
