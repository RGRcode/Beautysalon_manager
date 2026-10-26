using Microsoft.EntityFrameworkCore;
using Salon_kosmetyczny.Data;
using Salon_kosmetyczny.Models;
using Salon_Kosmetyczny.Exceptions;

namespace Salon_kosmetyczny.Services;

public class AppointmentService : IAppointmentService
{
    private readonly SalonDbContext _context;

    public AppointmentService(SalonDbContext context)
    {
        _context = context;
    }

    public async Task ZrealizujWizyteAsync(int klientId, int zabiegId, DateTime dataWizyty)
    {
        var zabieg = await _context.Zabiegi
            .Include(z => z.Receptura)
                .ThenInclude(sz => sz.Produkt)
            .FirstOrDefaultAsync(z => z.Id == zabiegId);

        if (zabieg == null)
            throw new Exception("Nie znaleziono takiego zabiegu.");

        var klientIstnieje = await _context.Klienci.AnyAsync(k => k.Id == klientId);
        if (!klientIstnieje)
            throw new Exception("Nie znaleziono takiego klienta.");

        foreach (var skladnik in zabieg.Receptura)
        {
            if (skladnik.Produkt != null)
            {
                skladnik.Produkt.ZmniejszStan(skladnik.WymaganaIlosc);
            }
        }

        var nowaWizyta = new Wizyta
        {
            KlientId = klientId,
            ZabiegId = zabiegId,
            DataCzasWizyty = dataWizyty,
            CenaOstateczna = zabieg.Cena 
        };

        _context.Wizyty.Add(nowaWizyta);

        await _context.SaveChangesAsync();
    }
}