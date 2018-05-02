using System;
using System.Collections.Generic;
using System.Text;

public class Ruby : Gem
{

    public Ruby(string type, QualityLevel quality) : base(type,quality)
    {
        this.DefaultAgility = 2;
        this.DefaultStrength = 7;
        this.DefaultVitality = 5;
    }
}