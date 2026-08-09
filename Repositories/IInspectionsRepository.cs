using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterReadinessSystemAPI.Data;
using ShelterReadinessSystemAPI.DTOs;
using ShelterReadinessSystemAPI.Models;

namespace ShelterReadinessSystemAPI.Repositories;

public interface IInspectionsRepository
{
    public Task<IEnumerable<InspectionDetailedDto>> GetInspectionDetailedAsync();
    public Task<IEnumerable<FailedInspectionDto>> GetAllFailedAsync();
}