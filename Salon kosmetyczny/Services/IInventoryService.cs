using Salon_kosmetyczny.Models;

namespace Salon_kosmetyczny.Services;

public interface IInventoryService
{
    Task<List<Produkt>> PobierzWszystkieProduktyAsync();
    Task ZwiekszStanMagazynowyAsync(int produktId, decimal ilosc);
}