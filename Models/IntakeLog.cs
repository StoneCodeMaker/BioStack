using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioStack.Models;

public class IntakeLog
{
    public int Id { get; set; }
    
    [Required]
    public int SupplementId { get; set; }
    
    [Required]
    public DateTime IntakeTime { get; set; }
    
    public bool Taken { get; set; }
    
    [MaxLength(500)]
    public string? Notes { get; set; }
    
    // Navigation properties
    [ForeignKey("SupplementId")]
    public Supplement? Supplement { get; set; }
}
