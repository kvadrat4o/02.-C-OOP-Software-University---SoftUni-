using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PersonAgeComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Age.CompareTo(y.Age);
        
        return result;
    }
}
