using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,List<Employee>> employees = new Dictionary<string,List<Employee>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];
                //string email;                                                         
                //int age;
                Employee employee = new Employee()
                {
                    Name = name,
                    Position = position,
                    Salary = salary,
                    Department = department
                };
                if (input.Length == 5)
                {
                    if (int.TryParse(input[4], out  int age))
                    {
                        employee.Age = age;
                    }
                    else
                    {
                        employee.Email = input[4];
                    }
                }
                else if (input.Length == 6)
                {
                    employee.Email = input[4];
                    employee.Age = int.Parse(input[5]);
                }
                if (employee.Age == 0)
                {
                    employee.Age = -1;
                }
                if (employee.Email == null)
                {
                    employee.Email = "n/a";
                }
                if (!employees.ContainsKey(department))
                {
                    employees[department] = new List<Employee>();
                }
                employees[department].Add(employee);
            }
            var highestSalaryDept = employees.OrderByDescending(a => a.Value.Average(b => b.Salary)).First().Key;
            Console.WriteLine($"Highest Average Salary: {highestSalaryDept}");
            foreach (var person in employees[highestSalaryDept].OrderByDescending(x => x.Salary))
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
