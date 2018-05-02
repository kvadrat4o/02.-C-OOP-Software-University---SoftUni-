using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fields)
    {
        StringBuilder sb = new StringBuilder();
        var typeOfHacker = Type.GetType(className);
        var parameters = typeOfHacker.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        Object hacker = Activator.CreateInstance(typeOfHacker, new object[] { });
        sb.AppendLine($"Class under investigation: {typeOfHacker}");
        foreach (var property in parameters.Where(p => fields.Contains(p.Name)))
        {
            sb.AppendLine($"{property.Name} = {property.GetValue(hacker)}");
        }

        return sb.ToString().TrimEnd();
    }
}