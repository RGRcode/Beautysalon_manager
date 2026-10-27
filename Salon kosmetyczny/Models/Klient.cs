using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salon_kosmetyczny.Models;

[Table("Klienci")]
public class Klient
{
    [Key]
    public int Id{get;set;}

    [Required] 
    [MaxLength(100)] 
    public string Imie { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string Nazwisko { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(15)]
    public string NrTelefonu { get; set; } = string.Empty;
    
    [MaxLength(15)]
    public string? Email { get; set; }

    public List<Wizyta> Wizyty { get; set; } = new();
}
