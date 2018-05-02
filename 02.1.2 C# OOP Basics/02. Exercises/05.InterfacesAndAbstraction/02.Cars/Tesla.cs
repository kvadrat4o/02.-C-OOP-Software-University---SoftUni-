﻿using System;
using System.Collections.Generic;
using System.Text;

public class Tesla : ICar, IElectricCar
{
    public string Model { get; set; }
    public string Color { get; set; }
    public int Battery { get; set ; }

    public Tesla()
    {
            
    }

    public Tesla(string model, string color, int battery)
    {
        Model = model;
        Color = color;
        Battery = battery;
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
        return $"{this.Color} {this.GetType()} Model {this.Model} with {this.Battery} Batteries\n{this.Start()}\n{this.Stop()}";
    }
}
