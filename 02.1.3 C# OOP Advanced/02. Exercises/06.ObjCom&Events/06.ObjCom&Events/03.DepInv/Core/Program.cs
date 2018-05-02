using _03.DepInv.Core;
using _03.DepInv.IO;
using _03.DepInv.Models;
using System;

namespace _03.DepInv
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var calculator = new Calculator();
            new Engine(calculator, reader, writer).Run();
        }
    }
}
