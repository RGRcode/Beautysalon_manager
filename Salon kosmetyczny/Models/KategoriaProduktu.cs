using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salon_kosmetyczny.Models;

[Table("Kategorie_produktow")]
public class KategoriaProduktu
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [MaxLength(100)]
    public string Nazwa { get; set; } = string.Empty;
}