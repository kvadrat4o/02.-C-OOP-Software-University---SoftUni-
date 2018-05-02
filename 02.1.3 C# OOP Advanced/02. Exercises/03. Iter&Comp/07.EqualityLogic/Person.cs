using System;
using System.Collections.Generic;
using System.Text;

public class Person : IComparable<Person>, IEquatable<Person>
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

    public override bool Equals(object obj)
    {
        return this.Equals(obj as Person);
    }

    public override int GetHashCode()
    {
        return  this.Age.GetHashCode() + this.Name.GetHashCode();
    }

    public int CompareTo(Person other)
    {
        int result = this.Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }
        return result;
    }

    public bool Equals(Person other)
    {
        return this.Name == other.Name && this.Age == other.Age;
    }
}
