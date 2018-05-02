
public class Parent
{
    private string name;
    private string birthday;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }

    public Parent()
    {
        
    }

    public Parent(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
    }
}