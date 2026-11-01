using System;

namespace Salon_kosmetyczny.Exceptions;

public class BrakWMagazynieException : Exception
{
    public BrakWMagazynieException(string message) : base(message)
    {
    }
}
