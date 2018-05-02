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

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();
        var typeOfHacker = Type.GetType(className);
        var fields = typeOfHacker.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        var publicMethods = typeOfHacker.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        var privateMethods = typeOfHacker.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (var getter in privateMethods.Where(g => g.Name.StartsWith("get")))
        {
            sb.AppendLine($"{getter.Name} have to be public!");
        }
        foreach (var setter in publicMethods.Where(s => s.Name.StartsWith("set")))
        {
            sb.AppendLine($"{setter.Name} have to be private!");
        }
        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();
        var typeOfHacker = Type.GetType(className);
        var baseClassName = typeOfHacker.BaseType.Name;
        var privateMethods = typeOfHacker.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {baseClassName}");
        foreach (var method in privateMethods)
        {
            sb.AppendLine(method.Name);
        }
        return sb.ToString().TrimEnd();
    }
}