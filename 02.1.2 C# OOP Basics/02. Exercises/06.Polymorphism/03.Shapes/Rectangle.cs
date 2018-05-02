using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle : Shape
{
    public double width { get; private set; }

    public double height { get; private set; }

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double CalculatePerimeter()
    {
        return this.width * 2 + this.height * 2;
    }

    public override double CalculateArea()
    {
        return this.width * this.height;
    }

    public override string Draw()
    {
        return base.Draw() + " Rectangle";
    }
}
