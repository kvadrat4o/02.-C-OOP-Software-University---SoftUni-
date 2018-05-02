
public class Pokemon
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string element;

    public string Element
    {
        get { return element; }
        set { element = value; }
    }

    private double health;

    public double Health
    {
        get { return health; }
        set { health = value; }
    }

    public Pokemon()
    {

    }

    public Pokemon(string name, string element, double health)
    {
        this.Name = name;
        this.Element = element;
        this.Health = health;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}

