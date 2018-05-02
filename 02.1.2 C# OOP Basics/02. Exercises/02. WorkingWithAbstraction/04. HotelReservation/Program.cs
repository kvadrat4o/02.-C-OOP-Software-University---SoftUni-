using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            //decimal totalPrice = 0.00m;
            PriceCalculator pc = new PriceCalculator();
            var input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            decimal price = decimal.Parse(input[0]);
            int days = int.Parse(input[1]);
            Season season = (Season)Enum.Parse(typeof(Season), input[2]);
            DiscountType type = DiscountType.None;
            if (input.Length == 4)
            {
                type = (DiscountType)Enum.Parse(typeof(DiscountType), input[3]);
            }
            Console.WriteLine($"{pc.CalculateTotalPrice(days, price, season, type):F2}");
        }
    }
}
