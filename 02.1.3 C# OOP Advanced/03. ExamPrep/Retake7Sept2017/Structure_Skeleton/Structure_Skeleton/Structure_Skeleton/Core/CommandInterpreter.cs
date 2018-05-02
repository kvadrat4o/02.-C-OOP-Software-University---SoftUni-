using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public string ProcessCommand(IList<string> args)
    {
        string commandName = args[0];
        Type commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(c => c.Name == commandName + "Command");
        var ctorParams = commandType.GetConstructors().FirstOrDefault().GetParameters();
        object[] constParams = new object[ctorParams.Length];
        for (int i = 0; i < constParams.Length; i++)
        {
            if (ctorParams[i].Name == "harvesterController")
            {
                constParams[i] = this.HarvesterController;
            }
            else if (ctorParams[i].Name == "providerController")
            {
                constParams[i] = this.ProviderController;
            }
            else
            {
                constParams[i] = args;
            }
        }
        ICommand command = (ICommand)Activator.CreateInstance(commandType, constParams);
        string result =  command.Execute();
        return result;
    }
}