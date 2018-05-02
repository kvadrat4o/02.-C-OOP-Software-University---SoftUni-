using System;
using System.Collections.Generic;
using System.Text;

public class Private : Soldier, IPrivate
{
    public double Salary { get; private set; }
    
    public Private(string firstName, string lastName, string id, double salary) :base(firstName,lastName,id)
    {
        Salary = salary;
    }

    public override string ToString()
    {
        return base.ToString() + $" Salary: {this.Salary:F2}";
    }
}
