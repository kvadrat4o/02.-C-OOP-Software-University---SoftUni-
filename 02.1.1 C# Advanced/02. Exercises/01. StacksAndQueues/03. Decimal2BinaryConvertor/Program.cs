using System;
using System.Collections.Generic;
using System.Linq;


namespace _03._Decimal2BinaryConvertor
{
    class Program
    {
        static void Main(string[] args)
        {
            var  input = int.Parse(Console.ReadLine());
            Stack<int> binary = new Stack<int>(input);
            if (input == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                while (input > 0)
                {
                    var reminder = input % 2;
                    input /= 2;
                    binary.Push(reminder);
                }
                Console.WriteLine(string.Join("", binary));
            }
        }
    }
}
