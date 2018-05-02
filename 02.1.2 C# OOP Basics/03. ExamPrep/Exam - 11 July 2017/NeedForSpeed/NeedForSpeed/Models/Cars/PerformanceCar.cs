using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PerformanceCar : Car
{
    private List<string> addOns;
   
    public List<string> AddOns
    {
        get { return addOns; }
        protected set { addOns = value; }
    }




    public PerformanceCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.AddOns = new List<string>();
        this.HorsePower += (this.HorsePower * 50) / 100;
        this.Suspension -= ((this.Suspension * 25) / 100 );
    }

    public override string ToString()
    {
        if (this.AddOns.Count > 0)
        {
            return base.ToString() + $"Add - ons:{string.Join(", ", this.AddOns)}";
        }
        else
        {
            return base.ToString() + $"Add - ons: None";
        }
    }
}