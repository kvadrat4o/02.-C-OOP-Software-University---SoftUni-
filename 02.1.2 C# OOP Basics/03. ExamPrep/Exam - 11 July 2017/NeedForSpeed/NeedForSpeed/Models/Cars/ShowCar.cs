using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShowCar : Car
{
    private int stars;

    public ShowCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }

    public int Stars
    {
        get { return stars; }
        set { stars = value; }
    }

    public override string ToString()
    {
        if (this.Stars > 0)
        {
            return base.ToString() + $"{this.Stars} *";
        }
        else
        {
            return base.ToString() + $"0 *";
        }
    }
}
