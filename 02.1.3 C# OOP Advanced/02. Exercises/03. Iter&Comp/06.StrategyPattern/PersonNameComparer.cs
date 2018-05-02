using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PersonNameComparer :IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Name.Length.CompareTo(y.Name.Length);
        if (result == 0)
        {
            result = x.Name.First().ToString().ToLower().CompareTo(y.Name.First().ToString().ToLower());
        }
        return result;
    }
}