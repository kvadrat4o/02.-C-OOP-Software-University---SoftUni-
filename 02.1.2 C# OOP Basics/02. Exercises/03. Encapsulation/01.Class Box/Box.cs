using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double height;
    private double width;
    private double length;

    public double Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }
    public double Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }
    public double Length
    {
        get { return length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    public Box(double height, double length, double width)
    {
        this.Height = height;
        this.Width = width;
        this.Length = length;
    }

    public double GetSurfaceArea ()
    {
        return  2 * this.Length * this.Height + 2 * this.Width * this.Height + 2 * this.Length * this.Width;
    }

    public double GetLateralArea()
    {
        return 2 * this.Length * this.Height + 2 * this.Width * this.Height ;
    }

    public double GetVolume()
    {
        return this.Length * this.Width * this.Height;
    }
}
