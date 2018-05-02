using System;

namespace P07_CustomListSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandInterpreter = new CommandInterpreter();
            commandInterpreter.ReadCommands();
        }
    }
}
