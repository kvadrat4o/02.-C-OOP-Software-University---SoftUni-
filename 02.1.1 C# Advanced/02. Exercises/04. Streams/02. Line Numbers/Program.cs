using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int counter = 1;
            using (StreamReader reader = new StreamReader("..//..//text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("..//..//result.txt"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"Line {counter}:{line}");
                        counter++;
                    }
                }
            }
        }
    }
}
