using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ShelterReadinessSystemAPI.Models;
namespace ShelterReadinessSystemAPI.Models;

public class Shelter
{
    public int Id { get; set; }
    [Required]
    [StringLength(200)]
    public string Name { get; set; }
    [Required]
    [StringLength(100)]
    public string Street { get; set; }
    [Required]
    [StringLength(20)]
    public string BuildingNumber { get; set; }
    [Range(1,10000)]
    public int Capacity { get; set; }

    [Required]
    public bool IsAccessible { get; set; }

    [Required]
    public bool IsPublic { get; set; }
    [Required]
    [StringLength(50)]
    [RegularExpression("^PublicBuilding|School|Parking|Residential|Commercial$")]
    public string ShelterType { get; set; }
    //FK

    public int AreaId { get; set; }
    //NP
    public Area Area { get; set; } = null!; //every shelter have one area

    public ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();
}