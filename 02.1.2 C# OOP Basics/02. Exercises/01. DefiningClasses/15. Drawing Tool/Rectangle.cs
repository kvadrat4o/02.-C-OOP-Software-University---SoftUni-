public class Rectangle
{
    private int a;
    private int b;

    public int A
    {
        get { return a; }
        set { a = value; }
    }

    public int B
    {
        get { return b; }
        set { b = value; }
    }

    public Rectangle()
    {

    }

    public Rectangle(int a, int b)
    {
        this.A = a;
        this.B = b;
    }

    public void Draw(Rectangle rect)
    {
        System.Console.WriteLine($"|{new string('-', this.A)}|");
        for (int i = 0; i < this.B - 2; i++)
        {
            System.Console.WriteLine($"|{new string(' ', this.A)}|");
        }
        System.Console.WriteLine($"|{new string('-', this.A)}|");
    }
}
