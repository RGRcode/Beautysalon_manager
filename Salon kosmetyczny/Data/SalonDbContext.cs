using Microsoft.EntityFrameworkCore;

namespace Salon_kosmetyczny.Data;

public class SalonDbContext : DbContext
{
    public SalonDbContext(DbContextOptions<SalonDbContext> options) : base(options)
    {
    }
}