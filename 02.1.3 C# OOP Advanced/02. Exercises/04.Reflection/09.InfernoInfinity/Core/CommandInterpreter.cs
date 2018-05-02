using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class CommandInterpreter
{
    private IRepository Repository { get; set; }

    private IFactory<IWeapon> Factory { get; set; }

    private string[] Data { get; set; }


    public CommandInterpreter(IRepository repository, IFactory<IWeapon> factory, string[] data)
    {
        this.Repository = repository;
        this.Factory = factory;
        this.Data = data;
    }

    public void InterpredCommand(string commandName)
    {
        var commandType = Assembly.GetExecutingAssembly().GetTypes().Where(c => c.Name.EndsWith("Command")).First(c => c.Name == commandName + "Command");
        var command = (ICommand)Activator.CreateInstance(commandType, new object[] { });
        var method = commandType.GetMethod("Execute").Invoke(command, new object[] { this.Repository,this.Factory,this.Data });
    }
}
