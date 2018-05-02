using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class CommandInterpreter
{

    private string[] data;
    private IUnitFactory unitFactory;
    private IRepository repository;

    public IRepository Repository
    {
        get { return repository; }
        set { repository = value; }
    }


    public IUnitFactory UnitFactory
    {
        get { return unitFactory; }
        set { unitFactory = value; }
    }

    public string[] Data
    {
        get { return data; }
        set { data = value; }
    }


    public CommandInterpreter(string[] data,IRepository repository,IUnitFactory unitFactory)
    {
        this.Data = data;
        this.UnitFactory = unitFactory;
        this.Repository = repository;
    }

    public string InterpredCommand(string commandName)
    {
        var typeOfCommand = Type.GetType(commandName);
        var commands = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name.EndsWith("Command") && t.Name.Length > 8).ToArray();
        var commandType = commands.First(c => c.Name.ToLower().Contains(commandName));
        var command = (IExecutable)Activator.CreateInstance(commandType,new object[] { this.Data,this.Repository,this.UnitFactory });
        string result = commandType.GetMethod("Execute").Invoke(command,new object[] { }).ToString();
        return result;
    }
}
