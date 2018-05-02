
using System;

class Engine : IRunnable
{
    private IRepository repository;
    private IUnitFactory unitFactory;

    public Engine(IRepository repository, IUnitFactory unitFactory)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
    }

    public void Run()
    {
        string input = "";
        while ((input = Console.ReadLine()) != "fight")
        {
            try
            {
                
                string[] data = input.Split();
                string commandName = data[0];
                string result = InterpredCommand(data,commandName);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    // TODO: refactor for Problem 4
    private string InterpredCommand(string[] data, string commandName)
    {
        CommandInterpreter ci = new CommandInterpreter(data, this.repository, this.unitFactory);
        return ci.InterpredCommand(commandName);
    }


    //private string ReportCommand(string[] data)
    //{
    //    string output = this.repository.Statistics;
    //    return output;
    //}


    //private string AddUnitCommand(string[] data)
    //{
    //    string unitType = data[1];
    //    IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
    //    this.repository.AddUnit(unitToAdd);
    //    string output = unitType + " added!";
    //    return output;
    //}
}