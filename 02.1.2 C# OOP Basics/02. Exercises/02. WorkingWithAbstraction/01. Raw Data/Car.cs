
using System.Collections.Generic;

public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tire> tires;

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

    public Cargo Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }

    public List<Tire> Tires
    {
        get { return tires; }
        set { tires = value; }
    }

    public Car()
    {
        this.Tires = new List<Tire>(4);
    }
    public Car(string model, Engine engine, Cargo cargo)
        : this()
    {
        this.Model = model;
        this.Cargo = cargo;
        this.Engine = engine;
    }

    public override string ToString()
    {
        return $"{this.Model}";
    }
}

