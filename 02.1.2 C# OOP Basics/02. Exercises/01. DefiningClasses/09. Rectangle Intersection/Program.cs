using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _09.Rectangle_Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            var parameters = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(parameters[0]);
            int m = int.Parse(parameters[1]);
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Rectangle rec = new Rectangle() { Id = input[0], Width = double.Parse(input[1]), Height = double.Parse(input[2]), Horizontal = double.Parse(input[3]), Vertical = double.Parse(input[4]) };
                rectangles.Add(rec);
            }
            for (int i = 0; i < m; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                var rec1 = rectangles.Where(a => a.Id == tokens[0]).First();
                var rec2 = rectangles.Where(a => a.Id == tokens[1]).First();
                bool areIntersecting = CheckIfIntersect(rec1, rec2);
                string result = (areIntersecting.ToString()).ToLower();
                Console.WriteLine(result);
            }
        }

        private static bool CheckIfIntersect(Rectangle rec1, Rectangle rec2)
        {
            bool intersect = false;

            if (Math.Abs(rec1.Horizontal) < Math.Abs(rec2.Horizontal + rec2.Width))
            {
                if (Math.Abs(rec1.Horizontal + rec1.Width) >= Math.Abs(rec2.Horizontal))
                {
                    if (rec1.Vertical < Math.Abs((rec2.Vertical - rec2.Height)))
                    {
                        if (Math.Abs(rec1.Vertical + rec1.Height) >= Math.Abs(rec2.Vertical))
                        {
                            intersect = true;
                        }
                    }
                }
            }

            return intersect;
        }
    }
}
