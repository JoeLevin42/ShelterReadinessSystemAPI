using Microsoft.AspNetCore.Mvc;
using ShelterReadinessSystemAPI.DTOs;
using ShelterReadinessSystemAPI.Repositories;

namespace ShelterReadinessSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AreasController : ControllerBase
{
    private readonly IAreaRepository _areaRepo;
    public AreasController(IAreaRepository areaRepo)
    {
        _areaRepo = areaRepo;
    }
    [HttpGet("statistics")]
    public async Task<ActionResult<IEnumerable<AreaStatisticsDto>>> GetStatistics()
    {
        var res = await _areaRepo.GetStatistics();
        return Ok(res);
    }
}