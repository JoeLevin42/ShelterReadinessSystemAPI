using Microsoft.AspNetCore.Mvc;
using ShelterReadinessSystemAPI.DTOs;
using ShelterReadinessSystemAPI.Repositories;

namespace ShelterReadinessSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InspectionsController : ControllerBase
{
    private readonly IInspectionsRepository _inspectionRepo;
    public InspectionsController(IInspectionsRepository inspectionRepo)
    {
        _inspectionRepo = inspectionRepo;
    }

    [HttpGet("detailed")]
    public async Task<ActionResult<IEnumerable<InspectionDetailedDto>>> GetInspectionDetailedAsync()
    {
        var allRes = await _inspectionRepo.GetInspectionDetailedAsync();
        return Ok(allRes);

    }

    [HttpGet("failed")]
    public async Task<ActionResult<IEnumerable<FailedInspectionDto>>> GetAllFailedAsync()
    {
        var allRes = await _inspectionRepo.GetAllFailedAsync();
        return Ok(allRes);
    }
}