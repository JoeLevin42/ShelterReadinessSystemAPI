using Microsoft.AspNetCore.Mvc;
using ShelterReadinessSystemAPI.DTOs;
using ShelterReadinessSystemAPI.Repositories;

namespace ShelterReadinessSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SheltersController : ControllerBase
{
    private readonly IShelterRepository _shelterRepo;
    public SheltersController(IShelterRepository shelterRepo)
    {
        _shelterRepo = shelterRepo;
    }

    [HttpGet("with-area")]
    public async Task<ActionResult<IEnumerable<ShelterWithAreaDto>>> GetShelterWithAreaAsync()
    {
        var result = await _shelterRepo.GetShelterWithAreaAsync();
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ShelterSearchResultDto>>> SearchOptionalAsync(string? city, 
        int? minCapacity, bool? isAccessible, bool? isPublic)
    {
        var result = await _shelterRepo.SearchOptionalAsync(city, minCapacity, isAccessible, isPublic);
        return Ok(result);
    }

    [HttpGet("sorted")]
    public async Task<ActionResult<IEnumerable<ShelterSortedDto>>> SortByOptionalAsync(
        string? sortBy = "name", bool? ascending = false)
    {
        var result = await _shelterRepo.SortByOptionalAsync(sortBy, ascending);
        return Ok(result);
    }

    [HttpGet("with-inspection-count")]
    public async Task<ActionResult<IEnumerable<ShelterWithInspectionCountDto>>> GetStatsAsync()
    {
        var res = await _shelterRepo.GetStatsAsync();
        return Ok(res);
    }



}