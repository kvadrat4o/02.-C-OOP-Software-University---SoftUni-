public interface IProviderController : IController
{
    double TotalEnergyProduced { get; }

    string Repair(double val);

    string CheckForProvider(int id);
}