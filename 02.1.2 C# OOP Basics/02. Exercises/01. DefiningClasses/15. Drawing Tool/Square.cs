public class Square
{
    private int a;

    public int A
    {
        get { return a; }
        set { a = value; }
    }

    public Square()
    {

    }

    public Square(int a)
    {
        this.A = a;
    }
    public void Draw(Square square)
    {
        System.Console.WriteLine($"|{new string('-',this.A)}|");
        for (int i = 0; i < this.A - 2; i++)
        {
            System.Console.WriteLine($"|{new string(' ', this.A)}|");
        }
        System.Console.WriteLine($"|{new string('-', this.A)}|");
    }
}
