using System;

namespace P07_CustomList
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
