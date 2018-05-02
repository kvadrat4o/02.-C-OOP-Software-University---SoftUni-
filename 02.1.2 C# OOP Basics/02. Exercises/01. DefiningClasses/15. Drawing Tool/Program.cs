using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Drawing_Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawingTool tool = new DrawingTool();
            string figure = Console.ReadLine();
            if (figure == "Square")
            {
                int a = int.Parse(Console.ReadLine());
                Square sq = new Square() { A = a };
                tool.Square = sq;
                tool.Square.Draw(sq);
            }
            else
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                Rectangle rect = new Rectangle(a, b);
                tool.Rectangle = rect;
                tool.Rectangle.Draw(rect);
            }
        }
    }
}
