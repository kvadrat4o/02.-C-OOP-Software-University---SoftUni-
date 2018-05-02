using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Text.RegularExpressions;


namespace _03.CryptoBlockchain
{
    class CryptoBlockchain
    {
        static void Main(string[] args)
        {
            Queue<string> strings = new Queue<String>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                strings.Enqueue(input);
            }
            string result = "";
            for (int i = 0; i < strings.Count; i++)
            {
                result += strings.Dequeue();
            }
        }
    }
}
