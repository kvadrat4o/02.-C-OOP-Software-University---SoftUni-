public class StandartProvider : Provider
{
    private const double baseDurability = 1000;

    public StandartProvider(int iD, double energy) : base(iD, baseDurability, energy)
    {
    }
}
