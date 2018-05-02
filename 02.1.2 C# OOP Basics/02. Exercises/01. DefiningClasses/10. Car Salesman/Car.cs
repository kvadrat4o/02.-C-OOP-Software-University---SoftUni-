
public class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;


    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }
    
    public string Weight
    {
        get { return weight; }
        set { weight = value; }
    }
    
    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public Car(string model, string weight, Engine engine, string color)
    {
        this.Model = model;
        this.Color = color;
        this.Engine = engine;
        this.Weight = weight;
    }

    public Car(string model, string weight, Engine engine)
    {
        this.Model = model;
        this.Color = "n/a";
        this.Engine = engine;
        this.Weight = weight;
    }

    public Car(string model,Engine engine, string color)
    {
        this.Model = model;
        this.Color = color;
        this.Engine = engine;
        this.Weight = "n/a";
    }
    public Car()
    {

    }

    public override string ToString()
    {
        if (this.Color == null)
        {
            this.Color = "n/a";
        }
        if (this.Weight == null)
        {
            this.Weight = "n/a";
        }
        if (this.Engine.Displacement == null)
        {
            this.Engine.Displacement = "n/a";
        }
        if (this.Engine.Efficiency == null)
        {
            this.Engine.Efficiency = "n/a";
        }
        return $"{this.Model}:\n  {this.Engine.Model}:\n    Power: {this.Engine.Power}\n    Displacement: {this.Engine.Displacement}\n    Efficiency: {this.Engine.Efficiency}\n  Weight: {this.Weight}\n  Color: {this.Color}";
    }
}
