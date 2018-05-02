using System;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    const decimal minimalSalary = 460m;
    const int minimalNameLength = 3;

    public string FirstName
    {
        get { return firstName; }
        private set
        {
            if (value.Length < minimalNameLength)
            {
                throw new ArgumentException($"First name cannot contain fewer than {minimalNameLength} symbols!");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        private set
        {
            if (value.Length < minimalNameLength)
            {
                throw new ArgumentException($"Last name cannot contain fewer than {minimalNameLength} symbols!");
            }
            this.lastName = value;
        }
    }

    public int Age
    {
        get { return age; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            this.age = value;
        }
    }

    public decimal Salary
    {
        get { return salary; }
        private set
        {
            if (value < minimalSalary)
            {
                throw new ArgumentException($"Salary cannot be less than {minimalSalary} leva!");
            }
            this.salary = value;
        }
    }

    public Person(string first, string last, int age, decimal salary)
    {
        this.FirstName = first;
        this.LastName = last;
        this.Age = age;
        this.Salary = salary;
    }

    public decimal IncreaseSalary(decimal percentage)
    {
        if (this.Age > 30)
        {
            this.Salary += (percentage / 100) * this.Salary;
        }
        else
        {
            this.Salary += (percentage / 200) * this.Salary;
        }
        return this.Salary;
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} gets {this.Salary:F2} leva.";
    }
}