using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private IRepository Repository { get; set; }

    private IFactory<IWeapon> Factory { get; set; }

    public Engine(IRepository repository,IFactory<IWeapon> factory)
    {
        this.Repository = repository;
        this.Factory = factory;
    }

    public void Run()
    {
        var input = "";
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(';');
            string commandName = tokens[0];
            CommandInterpreter ci = new CommandInterpreter(this.Repository, this.Factory, tokens);
            ci.InterpredCommand(commandName);
        }
    }
}