using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioStack.Models;

public class ExerciseSet
{
    public int Id { get; set; }
    
    [Required]
    public int WorkoutId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string ExerciseName { get; set; } = string.Empty;
    
    public int SetNumber { get; set; }
    
    public int Reps { get; set; }
    
    [Column(TypeName = "decimal(6, 2)")]
    public decimal Weight { get; set; }
    
    [MaxLength(100)]
    public string? WeightUnit { get; set; } = "lbs";
    
    [MaxLength(200)]
    public string? Notes { get; set; }
    
    // Navigation properties
    [ForeignKey("WorkoutId")]
    public Workout? Workout { get; set; }
}
