using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public string Name { get => this.name; set => this.name = value; }
    public int Age { get => this.age; set => this.age = value; }
    public List<BankAccount> Accounts { get => this.accounts; set => this.accounts = value; }

    public Person(string name, int age)
        :this(name, age, new List<BankAccount>())
    {   }

    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.Name = name;
        this.Age = age;
        this.accounts = accounts;
    }
    public decimal GetBalance()
    {
        return this.accounts.Sum(a => a.Balance);
    }
}
