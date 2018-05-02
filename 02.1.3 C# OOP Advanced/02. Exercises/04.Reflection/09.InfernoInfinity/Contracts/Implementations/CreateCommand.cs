using System;
using System.Collections.Generic;
using System.Text;

public class CreateCommand : ICommand
{
    public void Execute(IRepository repository, IFactory<IWeapon> factory, params string[] data)
    {
        var weaponToAdd = factory.CreateInstance<IWeapon>(data);
        repository.AddWeapon(weaponToAdd);
    }
}