public class Rectangle
{
    private Point pointTopLeft;
    private Point pointBottomRight;


    public Point PointTopLeft
    {
        get { return pointTopLeft; }
        set { pointTopLeft = value; }
    }

    public Point PointBottomRight
    {
        get { return pointBottomRight; }
        set { pointBottomRight = value; }
    }

    public bool Contains(Point point)
    {
        return this.PointTopLeft.X <= point.X  && this.PointBottomRight.X >= point.X && this.PointBottomRight.Y >= point.Y  && this.PointTopLeft.Y <= point.Y;
        
    }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        this.PointTopLeft = topLeft;
        this.PointBottomRight = bottomRight;
    }
}
