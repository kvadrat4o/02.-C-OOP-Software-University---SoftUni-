using System;
using System.Collections.Generic;
using System.Text;

public class AddComand : ICommand
{
    public void Execute(IRepository repository, IFactory<IWeapon> factory, params string[] data)
    {


        throw new NotImplementedException();
    }
}
