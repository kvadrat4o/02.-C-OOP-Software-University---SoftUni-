using System;
using System.Linq;

namespace _04.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            Smartphone iPhone = new Smartphone();
            var numbers = Console.ReadLine().Split(new char[] { ' ' });
            var urls = Console.ReadLine().Split(new char[] { ' ' });
            foreach (var number in numbers)
            {
                if (!number.Any(a => Char.IsDigit(a)))
                {
                    Console.WriteLine("Invalid number!");
                }
                else
                {
                    Console.WriteLine(iPhone.Calling(number));
                }
            }

            foreach (var url in urls)
            {
                if (url.Any(a => Char.IsDigit(a)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine(iPhone.Browse(url));
                }
            }
        }
    }
}
