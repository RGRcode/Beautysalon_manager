using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salon_kosmetyczny.Models;

[Table("Sklad_zabiegu")]
public class SkladZabiegu
{
    [Required]
    public int ZabiegId { get; set; } 
    
    [ForeignKey("ZabiegId")]
    public Zabieg?  Zabieg { get; set; }
    
    [Required]
    public int ProduktId { get; set; }
    
    [ForeignKey("ProduktId")]
    public Produkt? Produkt { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public Decimal WymaganaIlosc { get; set; }
}