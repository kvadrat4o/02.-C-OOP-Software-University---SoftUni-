using System;
using System.Collections.Generic;
using System.Text;
public class Amethyst : Gem
{
    public Amethyst(string type, QualityLevel quality) : base(type, quality)
    {
        this.DefaultAgility = 8;
        this.DefaultStrength = 2;
        this.DefaultVitality = 4;
    }
}
