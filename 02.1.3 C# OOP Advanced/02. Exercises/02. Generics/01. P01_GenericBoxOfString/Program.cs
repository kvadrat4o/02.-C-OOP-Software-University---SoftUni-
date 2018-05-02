using System;

namespace P01_GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var box = new Box<string>();
                box.Value = Console.ReadLine();
                Console.WriteLine(box);
            }
        }
    }
}
