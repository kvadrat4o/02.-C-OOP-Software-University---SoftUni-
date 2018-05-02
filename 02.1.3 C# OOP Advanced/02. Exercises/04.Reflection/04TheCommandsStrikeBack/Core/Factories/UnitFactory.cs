using System;
using System.Linq;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        //TODO: implement for Problem 3
        var typeOfUnit = Type.GetType(unitType);
        var instance = (IUnit)Activator.CreateInstance(typeOfUnit,true);
        return instance;
    }
}
