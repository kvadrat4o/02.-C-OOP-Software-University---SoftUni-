using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Student : Human
{
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (value.Length < 5 || value.Length > 10 || value.ToCharArray().Any(a => (a < 'a' && a > 'z') || (a <'A' && a > 'Z') || (a < '0' && a > '9')))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }


    public Student(string lname, string fname, string fac) :base(lname, fname)
    {
        this.FacultyNumber = fac;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nFaculty number: {this.FacultyNumber}";
    }
}
