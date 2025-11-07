using System.ComponentModel.DataAnnotations;

namespace BioStack.Models;

public class Supplement
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(50)]
    public string Category { get; set; } = string.Empty;
    
    [Required]
    public string Dosage { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Notes { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    // Navigation properties
    public ICollection<IntakeLog> IntakeLogs { get; set; } = new List<IntakeLog>();
}
