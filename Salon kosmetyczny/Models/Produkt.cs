using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salon_kosmetyczny.Models;

[Table("Produkt")]
public abstract class Produkt
{
    [Key]
    public int  Id { get; set; }
    
    [ForeignKey("KategoriaId")]
    public KategoriaProduktu? Kategoria { get; set; } 
    
    [Required]
    [MaxLength(100)]
    public string Nazwa { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string? Marka { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal AktualnyStan {get; set;}
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal MinimalnyStan {get; set;}

    [Required] 
    [MaxLength(20)] 
    public string? JednostkaMiary { get; set; } = string.Empty;
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Cena { get; set; }
}