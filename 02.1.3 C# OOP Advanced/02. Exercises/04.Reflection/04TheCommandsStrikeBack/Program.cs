using _03BarracksFactory.Data;
using System;

namespace _04.BarrackWars_TheCommandsStrikeBack
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}
