using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            var parsed1 = DateTime.Parse(date1);
            var parsed2 = DateTime.Parse(date2);
            DateModifier dm = new DateModifier();
            Console.WriteLine(dm.CalcDateDiff(parsed1,parsed2));
        }
    }
}
