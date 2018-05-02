﻿using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public int Age { get; set; }

    public string Name { get; set; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }
}
