using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double,double> vat = n => n * 1.2;
            Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(vat)
                .ToList()
                .ForEach(m => Console.WriteLine($"{m:f2}"));
        }
    }
}
