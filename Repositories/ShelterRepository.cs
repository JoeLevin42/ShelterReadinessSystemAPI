using Microsoft.EntityFrameworkCore;
using ShelterReadinessSystemAPI.Data;
using ShelterReadinessSystemAPI.DTOs;
using ShelterReadinessSystemAPI.Models;

namespace ShelterReadinessSystemAPI.Repositories;

public class ShelterRepository
{
    private readonly ApplicationDbContext _context;

    public ShelterRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ShelterWithAreaDto>> GetShelterWithAreaAsync()
    {
        var query = _context.Shelters
            .Select(e => new ShelterWithAreaDto
            {
                ShelterId = e.Id,
                ShelterName = e.Name,
                Capacity = e.Capacity,
                City = e.Area.City,
                Neighborhood = e.Area.Neighborhood

            }).ToListAsync();

        return await query;
    }

    public async Task<IEnumerable<ShelterSearchResultDto>> SearchOptionalAsync(
        string? city, int? minCapacity, bool? isAccessible, bool? isPublic)
    {
        var query = _context.Shelters.AsQueryable();

        if (!string.IsNullOrWhiteSpace(city))
        {
            query = query.Where(s => s.Area.City == city);
        }

        if (minCapacity.HasValue)
        {
            query = query.Where(s => s.Capacity >= minCapacity.Value);
        }

        if (isAccessible.HasValue)
        {
            query = query.Where(s => s.IsAccessible == isAccessible.Value);
        }
        if (isPublic.HasValue)
        {
            query = query.Where(s => s.IsPublic == isPublic.Value);
        }


        var res = query.Select(s => new ShelterSearchResultDto
        {
            Id = s.Id,
            Name = s.Name,
            Street = s.Street,
            Capacity = s.Capacity,
            IsAccessible = s.IsAccessible,
            City = s.Area.City
        }).ToListAsync();


        return await res;
    }

    public async Task<IEnumerable<ShelterSortedDto>> SortByOptionalAsync(
        string? sortBy = "name", bool? ascending = false)
    {
        var query = _context.Shelters.AsQueryable();

        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            sortBy = sortBy.ToLower(); switch (sortBy)
            {
                case "capacity":
                    if (ascending == true)
                    {
                        query = query.OrderBy(s => s.Capacity);
                        break;
                    }
                    else
                    {
                        query = query.OrderByDescending(s => s.Capacity);
                        break;
                    }
                case "name":
                    if (ascending == true)
                    {
                        query = query.OrderBy(s => s.Name);
                        break;
                    }
                    else
                    {
                        query = query.OrderByDescending(s => s.Name);
                        break;
                    }
                case "city":
                    if (ascending == true)
                    {
                        query = query.OrderBy(s => s.Area.City);
                        break;
                    }
                    else
                    {
                        query = query.OrderByDescending(s => s.Area.City);
                        break;
                    }
            }

        }
        var res = query.Select(e => new ShelterSortedDto
        {
            Id = e.Id,
            Name = e.Name,
            Street = e.Street,
            BuildingNumber = e.BuildingNumber,
            Capacity = e.Capacity,
            IsAccessible = e.IsAccessible,
            IsPublic = e.IsPublic,
            ShelterType = e.ShelterType
        }).ToListAsync();

        return await  res;

    }
}