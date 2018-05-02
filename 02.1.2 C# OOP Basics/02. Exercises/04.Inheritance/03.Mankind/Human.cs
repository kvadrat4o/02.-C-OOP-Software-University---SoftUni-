using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Human
{
    private string fname;
    private string lname;

    public Human()
    {

    }

    public Human(global::System.String lname, global::System.String fname)
    {
        Lname = lname;
        Fname = fname;
    }

    public string Lname
    {
        get { return lname; }
        set
        {
            if (value.Length < 2)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
            }
            if (!Char.IsUpper(value.First()))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            lname = value;
        }
    }

    public string Fname
    {
        get { return fname; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            if (!Char.IsUpper(value.First()))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            fname = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {this.Fname}\nLast Name: {this.Lname}";
    }
}
