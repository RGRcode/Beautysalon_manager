namespace Salon_kosmetyczny.Models;

public class ProduktSztukowy : Produkt
{
    public override void ZmniejszStan(decimal ilosc)
    {
        if (ilosc % 1 != 0)
        {
            throw new InvalidOperationException("Błąd logiki, nie można odjąć ułamka produktu sztukowego");
        }
        base.ZmniejszStan(ilosc);
    }
}