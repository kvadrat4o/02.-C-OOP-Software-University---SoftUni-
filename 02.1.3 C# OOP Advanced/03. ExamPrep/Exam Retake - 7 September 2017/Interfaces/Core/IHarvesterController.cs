public interface IHarvesterController : IController
{
    double OreProduced { get; }

    double TotalEnergyProduced { get; }

    string ChangeMode(string mode);

    string CheckForHarvester(int id);

    bool IdExists(int id);
}