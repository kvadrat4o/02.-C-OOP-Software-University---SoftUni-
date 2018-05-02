using _02.KingsGambit.Core;
using _02.KingsGambit.IO;
using System;

namespace _02.KingsGambit
{
    class Program
    {
        static void Main(string[] args)
        {
            new Engine(new ConsoleReader(), new ConsoleWriter()).Run();
        }
    }
}
