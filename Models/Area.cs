using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShelterReadinessSystemAPI.Models;

[Index(nameof(AreaCode), IsUnique = true)]
public class Area
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string City { get; set; }

    [Required]
    [StringLength(100)]
    public string Neighborhood { get; set; }

    [Required]
    [StringLength(20)]
    public string AreaCode { get; set; }
    
    [Range(1,5)]
    public int RiskLevel { get; set; }
}