
public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double horizontal;
    private double vertical;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    
    public double Width
    {
        get { return width; }
        set { width = value; }
    }
    
    public double Height
    {
        get { return height; }
        set { height = value; }
    }
    
    public double Horizontal
    {
        get { return horizontal; }
        set { horizontal = value; }
    }
    
    public double Vertical
    {
        get { return vertical; }
        set { vertical = value; }
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
