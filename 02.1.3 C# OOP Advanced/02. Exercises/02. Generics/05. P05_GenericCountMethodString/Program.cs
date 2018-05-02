using System;

namespace P05_GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            var box = new Box<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                box.Add(Console.ReadLine());
            }

            var elementToCompare = Console.ReadLine();

            Console.WriteLine(box.FindGreaterElementsCount(elementToCompare));
        }
    }
}
