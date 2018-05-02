using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Employee
{
    //name, salary, position, department, email and age
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;


    public string Name { get => this.name; set => this.name = value; }
    public int Age
    {
        get => this.age;
        set
        {
            this.age = value;
        }
    }
    public decimal Salary { get => this.salary; set => this.salary = value; }
    public string Position { get => this.position; set => this.position = value; }
    public string Email { get => this.email; set => this.email = value; }
    public string Department { get => this.department; set => this.department = value; }

    public Employee()
    {

    }
    public Employee(string name, string department, string position, decimal salary)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = "n/a";
        this.Age = -1;
    }

    public Employee(string name, string department, string position, decimal salary, int age)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Age = age;
        this.Email = "n/a";
    }

    public Employee(string name, string department, string position, decimal salary, string email)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = email;
        this.Age = -1;
    }

    public Employee(string name, string department, string position, decimal salary, int age, string email)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Age = age;
        this.Email = email;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Salary:f2} {this.Email} {this.Age}";
    }
}
