public class Company
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string department;

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    private double salary;

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public Company()
    {

    }

    public Company(string name, string department, double salary)
    {
        this.Name = name;
        this.Department = department;
        this.Salary = salary;
    }
}
