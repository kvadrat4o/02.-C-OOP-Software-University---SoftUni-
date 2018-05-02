using System;
using System.Collections.Generic;
using System.Text;

public class Dog :  Animal
{
    public Dog(string gender, int age, string name) : base(gender, age, name)
    {

    }

    public override void ProduceSound()
    {
        Console.WriteLine("Woof!"); ;
    }
}