using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salon_kosmetyczny.Models;

[Table ("Wizyty")]
public class Wizyta
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int KlientId { get; set; }
    
    [ForeignKey("KlientId")]
    public Klient? Klient { get; set; }
    
    [Required]
    public int ZabiegId  { get; set; }
    [ForeignKey("ZabiegId")]
    public Zabieg? Zabieg { get; set; }
    
    [Required]
    public DateTime DataCzasWizyty { get; set; }
    
    [Required]
    [Column (TypeName = "decimal(10,2)")]
    public decimal CenaOstateczna{get;set;}
}