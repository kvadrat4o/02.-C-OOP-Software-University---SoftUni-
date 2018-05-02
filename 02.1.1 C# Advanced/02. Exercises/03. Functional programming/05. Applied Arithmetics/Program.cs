using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string line;
            Func<int,int> Add1 = n => n + 1;
            Func<int,int> Subtract1 = n => n - 1;
            Func<int,int> Multiply2 = n => n * 2;
            while ((line = Console.ReadLine()) != "end")
            {
                if (line == "add")
                {
                    AddNums(Add1, input);
                }
                else if (line == "subtract")
                {
                    SubtractNums(Subtract1, input);
                }
                else if (line == "multiply")
                {
                    MultiplyNums(Multiply2, input);

                }
                else
                {
                    Console.WriteLine(String.Join(" ",input));
                }
            }
        }

        private static void MultiplyNums(Func<int, int> multiply2, List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                input[i] = multiply2(input[i]);
            }
        }

        private static void SubtractNums(Func<int, int> subtract1, List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                input[i] = subtract1(input[i]);
            }
        }

        private static void AddNums(Func<int, int> add1, List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                input[i] = add1(input[i]);
            }
        }
    }
}
