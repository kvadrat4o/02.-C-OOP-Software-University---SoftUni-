using System;

namespace P09_CustomListIterator
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
