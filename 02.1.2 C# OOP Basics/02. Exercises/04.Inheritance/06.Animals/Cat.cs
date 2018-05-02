using System;
using System.Collections.Generic;
using System.Text;

public class Cat : Animal
{
    public Cat(string gender, int age, string name):base(gender,age,name)
    {

    }

    public Cat(int age, string name)
    {
        this.Age = age;
        this.Name = name;
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Meow meow");
    }
}
