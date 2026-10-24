using System;

namespace Salon_Kosmetyczny.Exceptions;

public class BrakWMagazynieException : Exception
{
    public BrakWMagazynieException(string message) : base(message)
    {
    }
}
