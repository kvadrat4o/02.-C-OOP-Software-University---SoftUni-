using System;
using System.Collections.Generic;
using System.Text;
using _01.Event.Contracts;

namespace _01.Event
{
   public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line) => Console.WriteLine(line);
    }
}
