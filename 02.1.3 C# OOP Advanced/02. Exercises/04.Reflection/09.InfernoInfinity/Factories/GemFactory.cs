using System;
using System.Collections.Generic;
using System.Text;

public class GemFactory : IFactory<IGem>
{
    public IGem CreateInstance<IGem>(params string[] data)
    {
        var typeOfT = typeof(Gem);
        var instance = Activator.CreateInstance(typeOfT);

        return (IGem)instance;
    }
}