using _03.DepInv.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.DepInv.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
