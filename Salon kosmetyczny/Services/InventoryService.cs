using Microsoft.EntityFrameworkCore;
using Salon_kosmetyczny.Data;
using Salon_kosmetyczny.Models;
using Salon_Kosmetyczny.Exceptions;

namespace Salon_kosmetyczny.Services;

public class InventoryService : IInventoryService{
    private readonly SalonDbContext _context;

    public InventoryService(SalonDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produkt>> PobierzWszystkieProduktyAsync()
    {
        return await _context.Produkty
            .Include(p => p.Kategoria)
            .ToListAsync();
    }

    public async Task ZwiekszStanMagazynowyAsync(int produktId, decimal ilosc)
    {
        var produkt = await _context.Produkty.FindAsync(produktId);
        
        if (produkt == null)
        {
            throw new Exception("Nie znaleziono produktu o podanym ID.");
        }
        
        produkt.ZwiększStan(ilosc);
        
        await _context.SaveChangesAsync();
    }
}
