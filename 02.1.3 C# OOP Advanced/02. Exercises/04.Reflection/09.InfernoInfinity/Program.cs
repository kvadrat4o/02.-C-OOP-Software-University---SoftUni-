using System;

namespace _09.InfernoInfinity
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new WeaponRepository();
            IFactory<IWeapon> unitFactory = new WeaponFactory();
            Engine engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}
