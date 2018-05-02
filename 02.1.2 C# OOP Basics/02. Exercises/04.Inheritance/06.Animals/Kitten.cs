using System;
using System.Collections.Generic;
using System.Text;

public class Kitten : Cat
{
    public Kitten( int age, string name) : base( age, name)
    {
        this.Gender = "Female";
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Meow");
    }
}
