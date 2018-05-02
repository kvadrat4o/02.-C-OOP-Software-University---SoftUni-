using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Point_in_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            var p1X = int.Parse(input[0]);
            var p1Y = int.Parse(input[1]);
            var p2X = int.Parse(input[2]);
            var p2Y = int.Parse(input[3]);
            Point p1 = new Point(p1X, p1Y);
            Point p2 = new Point(p2X, p2Y);
            Rectangle rec = new Rectangle(p1, p2);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                int x = int.Parse(tokens[0]);
                int y = int.Parse(tokens[1]);
                Point point = new Point(x,y);
                Console.WriteLine(rec.Contains(point));
            }
        }
    }
}
