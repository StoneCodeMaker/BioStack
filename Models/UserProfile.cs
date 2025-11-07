using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioStack.Models;

public class UserProfile
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Height { get; set; }
    
    [MaxLength(10)]
    public string? HeightUnit { get; set; } = "in";
    
    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Weight { get; set; }
    
    [MaxLength(10)]
    public string? WeightUnit { get; set; } = "lbs";
    
    public DateTime? DateOfBirth { get; set; }
    
    [MaxLength(500)]
    public string? FitnessGoals { get; set; }
    
    [MaxLength(500)]
    public string? HealthNotes { get; set; }
}
