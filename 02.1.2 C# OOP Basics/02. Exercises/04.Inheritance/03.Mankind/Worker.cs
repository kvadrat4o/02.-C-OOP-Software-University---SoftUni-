using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private int workHours;
    private decimal weekSalary;

    public Worker(string lname, string fname, int days, decimal salary): base(lname,fname)
    {
        this.weekSalary = salary;
        this.WorkHours = days;
    }

    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value < 10)
            {
                throw new Exception("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public int WorkHours
    {
        get { return workHours; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new Exception("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHours = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $"\nWeek Salary: {this.WeekSalary:F2}\nHours per day: {this.WorkHours:F2}\nSalary per hour: {(this.WeekSalary / (this.WorkHours * 5)):F2}";
    }
}
