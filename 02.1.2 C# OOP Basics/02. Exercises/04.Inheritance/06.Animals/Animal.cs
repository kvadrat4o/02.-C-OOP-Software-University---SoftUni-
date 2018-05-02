using System;
using System.Collections.Generic;
using System.Text;

public class Animal
{
    private string name;
    private int age;
    private string gender;
    
    public string Gender
    {
        get { return gender; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            gender = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            age = value;
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            name = value;
        }
    }

    public Animal()
    {

    }

    public Animal(global::System.String gender, global::System.Int32 age, global::System.String name)
    {
        this.Gender = gender;
        Age = age;
        Name = name;
    }

    public override string ToString()
    {
        return $"{this.GetType()}\n{this.Name} {this.Age} {this.Gender}";
    }

    public virtual void ProduceSound()
    {
        Console.WriteLine("");
    }
}