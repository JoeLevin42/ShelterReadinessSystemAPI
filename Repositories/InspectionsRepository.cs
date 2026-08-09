using Microsoft.EntityFrameworkCore;
using ShelterReadinessSystemAPI.Data;
using ShelterReadinessSystemAPI.DTOs;
using ShelterReadinessSystemAPI.Models;

namespace ShelterReadinessSystemAPI.Repositories;


public class InspectionsRepository : IInspectionsRepository
{
    private readonly ApplicationDbContext _context;

    public InspectionsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InspectionDetailedDto>> GetInspectionDetailedAsync()
    {
        var allInc = _context.Inspections
            .Select(e => new InspectionDetailedDto
            {
                InspectionId = e.Id,
                InspectionDate = e.InspectionDate,
                ReadinessScore = e.ReadinessScore,
                Passed = e.Passed,
                ShelterName = e.Shelter.Name,
                City = e.Shelter.Area.City,
                Neighborhood = e.Shelter.Area.Neighborhood
            }).ToListAsync();

        return await allInc;
    }

    public async Task<IEnumerable<FailedInspectionDto>> GetAllFailedAsync()
    {
        var res = _context.Inspections
            .Where(e => e.Passed == true).AsQueryable();
        return await res.Select(e => new FailedInspectionDto
        {
            InspectionId = e.Id,
            InspectionDate = e.InspectionDate,
            ReadinessScore = e.ReadinessScore,
            DefectsCount = e.DefectsCount,
            ShelterName = e.Shelter.Name,
            City = e.Shelter.Area.City
        }).ToListAsync();
    }





    
}