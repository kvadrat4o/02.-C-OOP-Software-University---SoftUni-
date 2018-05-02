public class PressureProvider : Provider
{
    private const double baseDurability = 1000;

    public PressureProvider(int iD,double energy) : base(iD,baseDurability - 300, energy * 2)
    {
        
    }
}