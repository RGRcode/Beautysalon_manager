using Salon_kosmetyczny.Models;

namespace Salon_kosmetyczny.Services;

public interface IAppointmentService
{
    Task ZrealizujWizyteAsync(int klientId, int zabiegId, DateTime dataWizyty);
}