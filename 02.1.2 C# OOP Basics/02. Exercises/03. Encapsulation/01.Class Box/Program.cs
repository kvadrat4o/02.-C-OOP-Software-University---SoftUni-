using System;

class Program
{
    public static void Main(string[] args)
    {
        double l = double.Parse(Console.ReadLine());
        double w = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());
        try
        {
            Box box = new Box(h, l, w);
            Console.WriteLine($"Surface Area - {box.GetSurfaceArea():F2}\nLateral Surface Area - {box.GetLateralArea():F2}\nVolume - {box.GetVolume():F2}");
        }
        catch (ArgumentException ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
}
