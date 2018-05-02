using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private IReader consoleReader;

    private IWriter consoleWriter;

    private ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter interpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = interpreter;
        this.consoleReader = reader;
        this.consoleWriter = writer;
    }

    public void Run()
    {
        while (true)
        {
            string input = this.consoleReader.ReadLine();
            IList<string> data = input.Split().ToList();
            this.consoleWriter.WriteLine(this.commandInterpreter.ProcessCommand(data));
            if (data[0] == "Shutdown")
            {
                Environment.Exit(0);
            }
        }
    }
}
