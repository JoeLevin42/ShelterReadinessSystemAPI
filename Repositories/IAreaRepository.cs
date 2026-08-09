using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterReadinessSystemAPI.Data;
using ShelterReadinessSystemAPI.DTOs;
using ShelterReadinessSystemAPI.Models;

namespace ShelterReadinessSystemAPI.Repositories;

public interface IAreaRepository
{
    public Task<IEnumerable<AreaStatisticsDto>> GetStatistics();

}