using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            var boxes = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var box = new Box<string>(Console.ReadLine());

                boxes.Add(box);
            }

            var swapIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SwapElements(swapIndexes[0], swapIndexes[1], boxes);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        static void SwapElements(int index1, int index2, List<Box<string>> boxes)
        {
            var element1 = boxes[index1].Value;
            var element2 = boxes[index2].Value;

            boxes[index1].Value = element2;
            boxes[index2].Value = element1;
        }
    }
}
