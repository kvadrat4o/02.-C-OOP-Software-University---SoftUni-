using System;
using System.Collections.Generic;
using System.Text;

public class Frog : Animal
{
    public Frog(string gender, int age, string name) : base(gender, age, name)
    {

    }

    public override void ProduceSound()
    {
        Console.WriteLine("Ribbit");
    }
}
