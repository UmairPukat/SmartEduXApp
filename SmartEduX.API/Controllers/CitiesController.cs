namespace SmartEduX.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = AppRoles.SuperAdmin)]
public class CitiesController : ControllerBase
{
    private readonly ICityService _cityService;

    public CitiesController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? provinceId, CancellationToken cancellationToken)
    {
        var response = provinceId is null
            ? await _cityService.GetAllAsync(cancellationToken)
            : await _cityService.GetByProvinceIdAsync(provinceId.Value, cancellationToken);

        return response.ToApiResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var response = await _cityService.GetByIdAsync(id, cancellationToken);
        return response.ToApiResult();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCityDto dto, CancellationToken cancellationToken)
    {
        var response = await _cityService.CreateAsync(dto, cancellationToken);
        return response.ToApiResult();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCityDto dto, CancellationToken cancellationToken)
    {
        var response = await _cityService.UpdateAsync(id, dto, cancellationToken);
        return response.ToApiResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var response = await _cityService.DeleteAsync(id, cancellationToken);
        return response.ToApiResult();
    }
}
