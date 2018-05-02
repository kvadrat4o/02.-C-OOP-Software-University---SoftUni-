using System;
using System.Collections.Generic;
using System.Text;

public class ProviderFactory
{
    public ProviderFactory()
    {

    }

    public Provider GetProvider(List<string> args)
    {
        Provider sp;
        var id = args[1];
        var energy = double.Parse(args[2]);
        if (args[0] == "Pressure")
        {
            sp = new PressureProvider(id, energy);
        }
        else
        {
            sp = new SolarProvider(id, energy);
        }

        return sp;
    }
}