using System;
using System.Collections.Generic;
using System.Text;

public class Smartphone : IBrowsable, ICallable
{
    public Smartphone()
    {

    }

    public string Browse(string n)
    {
        return $"Browsing: {n}!";
    }

    public string Calling(string n)
    {
        return $"Calling... {n}";
    }
}
