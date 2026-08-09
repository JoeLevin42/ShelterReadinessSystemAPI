using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
    public string ShelterType { get; set; }
}