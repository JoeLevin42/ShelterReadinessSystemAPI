using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShelterReadinessSystemAPI.Models;

public class Inspection
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime InspectionDate { get; set; }

    [Range(0,100)]
    public int ReadinessScore { get; set; }

    [Required]
    public bool Passed { get; set; }

    [Range(0, 100)]
    public int DefectsCount { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

}