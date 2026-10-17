using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salon_kosmetyczny.Models;

[Table("Zabiegi")]
public class Zabieg
{
    [Key]
    public int Id {get; set;}

    [Required] [MaxLength(100)] public string Nazwa { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(500)]
    public string? Opis { get; set; }
    
    [Required]
    public int CzasTrwania{get; set;}
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Cena { get; set; }

    public List<SkladZabiegu> Receptura { get; set; } = new();
    public List<Wizyta> Wizyty { get; set; } = new();
}
