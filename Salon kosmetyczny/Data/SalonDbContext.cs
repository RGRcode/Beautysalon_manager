using Microsoft.EntityFrameworkCore;
using Salon_kosmetyczny.Models;

namespace Salon_kosmetyczny.Data;

public class SalonDbContext : DbContext
{
    public SalonDbContext(DbContextOptions<SalonDbContext> options) : base(options)
    {
    }

    public DbSet<Klient> Klienci => Set<Klient>();
    public DbSet<KategoriaProduktu> Kategorie_produktow => Set<KategoriaProduktu>();
    public DbSet<Produkt> Produkty => Set<Produkt>();
    public DbSet<Zabieg> Zabiegi => Set<Zabieg>();
    public DbSet<SkladZabiegu> SkladZabiegów => Set<SkladZabiegu>();
    public DbSet<Wizyta> Wizyty => Set<Wizyta>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SkladZabiegu>()
            .HasKey(sz => new { sz.ZabiegId, sz.ProduktId });
        modelBuilder.Entity<Produkt>()
            .HasDiscriminator(p => p.JednostkaMiary)
            .HasValue<ProduktPlynny>("ml")
            .HasValue<ProduktSztukowy>("szt");
    }
}
