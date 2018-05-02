public class Engine
{
    private string model;
    private string efficiency;
    private string displacement;
    private string power;


    public string Model
    {
        get { return model; }
        set { model = value; }
    }
   
    public string Efficiency
    {
        get { return efficiency; }
        set { efficiency = value; }
    }
    public string Displacement
    {
        get { return displacement; }
        set { displacement = value; }
    }

    public string Power
    {
        get { return power; }
        set { power = value; }
    }

    public Engine(string model, string power, string displacement, string efficiency)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public Engine(string model, string power, string efficiency)
    {
        int val;
        this.Model = model;
        this.Power = power;
        this.Displacement = "n/a";
        this.Efficiency = efficiency;
        if (int.TryParse(efficiency, out  val))
        {
            this.Efficiency = "n/a";
            this.Displacement = efficiency;
        }
        else
        {
            this.Efficiency = efficiency;
            this.Displacement = "n/a";
        }
    }

    public Engine()
    {

    }
}