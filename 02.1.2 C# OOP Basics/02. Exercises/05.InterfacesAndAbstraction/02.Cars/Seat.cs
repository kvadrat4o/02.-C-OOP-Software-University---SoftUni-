using System;
using System.Collections.Generic;
using System.Text;

public class Seat : ICar
{
    public string Model { get; set; }
    public string Color { get; set; }
    public Seat()
    {
            
    }

    public Seat(string model, string color)
    {
        Model = model;
        Color = color;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }
    public override string ToString()
    {
        return $"{this.Color} {this.GetType()} {this.Model}\n{this.Start()}\n{this.Stop()}";
    }
}
