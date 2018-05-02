using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var inputStr = Console.ReadLine().Split().Skip(1).ToArray();
        ListIterator create = new ListIterator(inputStr);
        var input = "";
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split();
            switch (tokens[0])
            {
                case "Print":
                    create.Print();
                    break;
                case "Move":
                    Console.WriteLine(create.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(create.HasNext());
                    break;
                default:
                    break;
            }

        }
    }
}
