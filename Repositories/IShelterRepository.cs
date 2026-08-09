using Microsoft.EntityFrameworkCore;
using ShelterReadinessSystemAPI.Data;
using ShelterReadinessSystemAPI.DTOs;
using ShelterReadinessSystemAPI.Models;

namespace ShelterReadinessSystemAPI.Repositories;

public interface IShelterRepository
{
    public Task<IEnumerable<ShelterWithAreaDto>> GetShelterWithAreaAsync();
    public Task<IEnumerable<ShelterSearchResultDto>> SearchOptionalAsync(string? city, int? minCapacity, bool? isAccessible, bool? isPublic);
    public Task<IEnumerable<ShelterSortedDto>> SortByOptionalAsync(
        string? sortBy = "name", bool? ascending = false);
    public Task<IEnumerable<ShelterWithInspectionCountDto>> GetStatsAsync();


}