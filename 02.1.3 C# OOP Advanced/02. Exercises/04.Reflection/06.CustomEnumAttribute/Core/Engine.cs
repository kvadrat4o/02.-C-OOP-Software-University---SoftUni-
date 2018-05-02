using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

public class Engine
{
    public void Run()
    {
        string param = Console.ReadLine();
        string result = PrintAttributes(param);
        Console.WriteLine(result);
    }

    private string PrintAttributes(string param)
    {
        StringBuilder sb = new StringBuilder();
        var typeOfattr = param == "Rank" ? typeof(CardRank) : typeof(CardSuit);
        var attribs = typeOfattr.GetCustomAttributes();
        foreach (var atrr in attribs)
        {
            sb.AppendLine(atrr.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}