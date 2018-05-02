using _02BlackBoxInteger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class BlackBoxIntegerTests
{
    public string Black()
    {
        var input = "";
        StringBuilder sb = new StringBuilder();
        var typeOfBlackBOXint = typeof(BlackBoxInt);
        var blackBox = (BlackBoxInt)Activator.CreateInstance(typeOfBlackBOXint, true);
        var methods = typeOfBlackBOXint.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        var fields = typeOfBlackBOXint.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            int param = int.Parse(tokens[1]);
            string name = tokens[0];
            methods.First(m => m.Name == name).Invoke(blackBox, new object[] { param });
            foreach (var field in fields)
            {
                sb.AppendLine(field.GetValue(blackBox).ToString());
            }
        }
        return sb.ToString().TrimEnd();
    }
}