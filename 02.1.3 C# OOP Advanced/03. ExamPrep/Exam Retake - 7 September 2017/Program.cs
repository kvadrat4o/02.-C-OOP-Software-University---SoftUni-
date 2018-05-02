public class Program
{
    public static void Main(string[] args)
    {
        IEnergyRepository repository = new EnergyRepository();
        IHarvesterController hvc = new HarvesterController(repository);
        IProviderController pvc = new ProviderController(repository);
        ICommandInterpreter cmi = new CommandInterpreter(hvc,pvc);
        Engine engine = new Engine(cmi, new ConsoleReader(),new ConsoleWriter());
        engine.Run();
        
    }
}