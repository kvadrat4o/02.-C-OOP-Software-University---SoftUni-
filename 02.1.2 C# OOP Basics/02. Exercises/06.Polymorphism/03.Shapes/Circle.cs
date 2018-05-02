using System;
using System.Collections.Generic;
using System.Text;

public class Circle : Shape
{
    public double radius { get; private set; }

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double CalculatePerimeter()
    {
        return this.radius * 2 * Math.PI;
    }

    public override double CalculateArea()
    {
        return (this.radius * this.radius ) * Math.PI;
    }

    public override string Draw()
    {
        return base.Draw() + " Circle";
    }
}