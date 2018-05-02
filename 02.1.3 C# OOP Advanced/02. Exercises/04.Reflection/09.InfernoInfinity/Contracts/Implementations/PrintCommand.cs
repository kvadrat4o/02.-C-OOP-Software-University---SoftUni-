using System;
using System.Collections.Generic;
using System.Text;

public class PrintCommand : ICommand
{
    public void Execute(IRepository repository, IFactory<IWeapon> factory, params string[] data)
    {
        Console.WriteLine(repository.Statistics); 
    }
}