
public class Car
{
    //model, fuel amount, fuel consumption for 1 kilometer and distance traveled

    private string model;
    private double fuelamount;
    private double consumption;
    private double distanceTravelled;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public double FuelAmount
    {
        get { return fuelamount; }
        set { fuelamount = value; }
    }

    public double Consumption
    {
        get { return consumption; }
        set { consumption = value; }
    }

    public double DistanceTravelled
    {
        get { return distanceTravelled; }
        set { distanceTravelled = value; }
    }

    public Car()
    {

    }

    public void Drive(string model, int km)
    {
        if (this.FuelAmount > 0 && this.FuelAmount >= this.Consumption * km)
        {
            this.FuelAmount -= this.Consumption * km;
            this.DistanceTravelled += km;
        }
        else
        {
            System.Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:F2} {this.DistanceTravelled}";
    }
}
