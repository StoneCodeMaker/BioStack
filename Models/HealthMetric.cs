using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioStack.Models;

public class HealthMetric
{
    public int Id { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    // Sleep metrics
    public int? SleepHours { get; set; }
    
    [Range(1, 10)]
    public int? SleepQuality { get; set; }
    
    // Energy and recovery metrics
    [Range(1, 10)]
    public int? EnergyLevel { get; set; }
    
    [Range(1, 10)]
    public int? RecoveryScore { get; set; }
    
    // Physical metrics
    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Weight { get; set; }
    
    [MaxLength(10)]
    public string? WeightUnit { get; set; } = "lbs";
    
    // Additional notes
    [MaxLength(500)]
    public string? Notes { get; set; }
}
