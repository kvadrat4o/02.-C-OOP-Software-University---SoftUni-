using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private IReader reader;
    private IWriter writer;
    private IManager heroManager;

    public Engine(IReader reader, IWriter writer, IManager heroManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            List<string> arguments = this.ParseInput(inputLine);
            this.writer.WriteLine(this.ProcessInput(arguments));
            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private List<string> ParseInput(string input)
    {
        return input.Trim().Split(' ').ToList();
    }

    private string ProcessInput(List<string> arguments)
    {
        string command = arguments[0];
        if (command != "Quit")
        {
            arguments.RemoveAt(0);
        }
        Type commandType = Type.GetType(command + "Command");
        var constructor = commandType.GetConstructors().First();
        ICommand cmd = (ICommand)constructor.Invoke(new object[] { arguments, this.heroManager });
        return cmd.Execute();
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}