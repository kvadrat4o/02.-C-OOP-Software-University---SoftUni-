using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var converter = new Stack<int>();
            var reminder = 0;
            var num = int.Parse(Console.ReadLine());

            
            if (num == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                while (num > 0)
                {
                    reminder = num % 2;
                    num /= 2;
                    converter.Push(reminder);
                }
                Console.WriteLine(string.Join("", converter));
            }
        }
    }
}
