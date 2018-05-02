using System;
using System.Collections.Generic;
using System.Text;

public class Ferrari : IFerrari
{
    public string Driver { get; set; }

    public Ferrari(string driver)
    {
        Driver = driver;
    }

    public string Breaks()
    {
        return "Brakes!";
    }

    public string PushTheGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"488-Spider/{this.Breaks()}/{this.PushTheGasPedal()}/{this.Driver}";
    }
}
