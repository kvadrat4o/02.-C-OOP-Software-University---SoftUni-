using System;
using System.Collections.Generic;
using System.Text;

public class Emerald : Gem
{
    public Emerald(string type, QualityLevel quality) : base(type, quality)
    {
        this.DefaultAgility = 4;
        this.DefaultStrength = 1;
        this.DefaultVitality = 9;
    }
}