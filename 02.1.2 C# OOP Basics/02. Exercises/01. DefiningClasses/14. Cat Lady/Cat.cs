using System.Text;

public class Cat
{
    private string breed;
    private string name;
    private double prop;


    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public double  Prop
    {
        get { return prop; }
        set { prop = value; }
    }

    public Cat()
    {

    }

    public Cat(string name, double prop, string breed)
    {
        this.Name = name;
        this.Breed = breed;
        this.Prop = prop;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{this.Breed} {this.Name} ");
        if (this.Breed == "Cymric")
        {
            sb.Append($"{this.Prop:F2}");
        }
        else
        {
            sb.Append($"{this.Prop}");
        }
        return sb.ToString();
    }
}