using System;
using System.Collections.Generic;
using System.Text;

public class Person : IComparable<Person>
{
    public int Age { get; set; }

    public string Name { get; set; }

    public string Town { get; set; }

    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }

    public int CompareTo(Person other)
    {
        int result = this.Name.CompareTo(other.Name);

        if (this.Name.CompareTo(other.Name) == 0)
        {
            if (this.Age.CompareTo(other.Age) == 0)
            {
                result = this.Town.CompareTo(other.Town);
            }
        }

        return result;
    }
}
