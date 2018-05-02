using System;
using System.Collections.Generic;
using System.Text;

public abstract class Command : IExecutable
{

    private string[] data;
    private IRepository repository;
    private IUnitFactory unitFactory;

    protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
    {
        this.Data = data;
        this.Repository = repository;
        this.UnitFactory = unitFactory;
    }

    public IUnitFactory UnitFactory
    {
        get { return unitFactory; }
        private set { this.unitFactory = value; }
    }

    public IRepository Repository
    {
        get { return repository; }
        private set { this.repository = value; }
    }

    public string[] Data
    {
        get { return data; }
        private set { this.data = value; }
    }

    public abstract string Execute();
}