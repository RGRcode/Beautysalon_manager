using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Salon_Kosmetyczny.Exceptions;

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
    public decimal AktualnyStan { get; private set; } = 0;
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal MinimalnyStan {get; set;}

    [Required] 
    [MaxLength(20)] 
    public string? JednostkaMiary { get; set; } = string.Empty;
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Cena { get; set; }

    public virtual void ZmniejszStan(decimal ilosc)
    {
        if (ilosc < 0)
        {
            throw new ArgumentException("Zużywana ilość musi być większa od zera.");
        }

        if (AktualnyStan - ilosc < 0)
        {
            throw new BrakWMagazynieException($"Brak wystarczającej ilości produktu'{Nazwa}'. Brakuje $'{ilosc-AktualnyStan}' $'{JednostkaMiary}'.");
        }
        AktualnyStan -= ilosc;
    }

    public virtual void ZwiększStan(decimal ilosc)
    {
        if (ilosc <= 0)
        {
            throw new ArgumentException("Ilość z dostawy musi być większa od zera.");
        }
        AktualnyStan += ilosc;
    }
}
