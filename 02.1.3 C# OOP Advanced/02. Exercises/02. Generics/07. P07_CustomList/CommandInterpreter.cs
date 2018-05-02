using System;

public class CommandInterpreter
{
    public void ReadCommands()
    {
        var list = new MyCustomList<string>();

        string line;
        while ((line = Console.ReadLine()) != "END")
        {
            var args = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (args[0])
            {
                case "Add":
                    list.Add(args[1]);
                    break;
                case "Remove":
                    list.Remove(int.Parse(args[1]));
                    break;
                case "Contains":
                    Console.WriteLine(list.Contains(args[1]));
                    break;
                case "Swap":
                    list.Swap(int.Parse(args[1]), int.Parse(args[2]));
                    break;
                case "Greater":
                    Console.WriteLine(list.CountGreaterThan(args[1]));
                    break;
                case "Max":
                    Console.WriteLine(list.Max());
                    break;
                case "Min":
                    Console.WriteLine(list.Min());
                    break;
                case "Print":
                    list.Print();
                    break;
            }
        }
    }
}

