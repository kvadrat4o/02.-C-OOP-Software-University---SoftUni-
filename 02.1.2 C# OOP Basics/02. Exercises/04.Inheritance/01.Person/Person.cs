using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private int age;

    
    public Person()
    {

    }

    public Person(string name, int age)
        :this()
    {
        this.Age = age;
        this.Name = name;
    }

    protected virtual int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }
            this.age = value;
        }
    }

    protected virtual string Name
    {
        get { return name; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }
            this.name = value;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                             this.Name,
                             this.Age));

        return stringBuilder.ToString();

        //return $"Name: {this.Name}, Age: {this.Age}";
    }
}
