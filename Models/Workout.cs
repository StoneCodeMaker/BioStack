using System.ComponentModel.DataAnnotations;

namespace BioStack.Models;

public class Workout
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public DateTime Date { get; set; }
    
    [MaxLength(50)]
    public string? WorkoutType { get; set; }
    
    public int DurationMinutes { get; set; }
    
    [MaxLength(500)]
    public string? Notes { get; set; }
    
    // Navigation properties
    public ICollection<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
}
