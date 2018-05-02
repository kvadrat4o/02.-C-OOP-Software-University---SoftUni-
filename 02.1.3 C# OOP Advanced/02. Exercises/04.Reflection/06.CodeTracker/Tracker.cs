using _06.CodeTracker;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Tracker
{
    public  void PrintMethodsByAuthor()
    {
        var typeOfTracker = typeof(StartUp);
        var methods = typeOfTracker.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(m => m.AttributeType == typeof(SoftUniAttribute)))
            {
                var attrs = method.GetCustomAttributes(false);
                foreach (SoftUniAttribute attrib in attrs)
                {
                    Console.WriteLine($"{method.Name} is written by {attrib.Name}");
                }
            }
        }
    }
}
