using System;
using System.Collections.Generic;
using System.Text;


public class RemoveCommand : ICommand
{
    public void Execute(IRepository repository, IFactory<IWeapon> factory, params string[] data)
    {
        var weaponName = data[1];

    }
}
