public class SolarProvider : Provider
{
    private const double baseDurability = 1000;

    public SolarProvider(int iD, double energy) : base(iD, baseDurability + 500, energy)
    {

    }
}
