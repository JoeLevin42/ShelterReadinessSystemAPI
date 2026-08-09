using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterReadinessSystemAPI.Data;
using ShelterReadinessSystemAPI.DTOs;
using ShelterReadinessSystemAPI.Models;

namespace ShelterReadinessSystemAPI.Repositories;

public class AreaRepository : IAreaRepository
{
    private readonly ApplicationDbContext _context;

    public AreaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AreaStatisticsDto>> GetStatistics()
    {
        var allRes = _context.Areas
            .Select(e => new AreaStatisticsDto
            {
                City = e.City,
                Neighborhood = e.Neighborhood,
                ShelterCount = e.Shelters.Count,
                TotalCapacity = e.Shelters.Sum(s => s.Capacity)
            }).ToListAsync();
        return await allRes;
    } 
}