using System;
using System.Collections.Generic;
using System.Text;

public class Tomcat : Cat
{
    public Tomcat(int age, string name) : base(age, name)
    {
        this.Gender = "Male";
    }

    public override void ProduceSound()
    {
       Console.WriteLine("MEOW");
    }
}
