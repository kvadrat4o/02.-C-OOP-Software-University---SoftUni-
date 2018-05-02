﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    public IProvider GenerateProvider(IList<string> args)
    {
        int id = int.Parse(args[3]);
        string type = args[2];
        double energyOutput = double.Parse(args[4]);

        Type clazz = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type + "Provider");
        var ctors = clazz.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
        IProvider provider = (IProvider)Activator.CreateInstance(clazz,new object[] { id, energyOutput });
        return provider;
    }
}