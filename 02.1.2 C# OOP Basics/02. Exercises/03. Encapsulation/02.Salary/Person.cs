public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
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
        return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
    }
}