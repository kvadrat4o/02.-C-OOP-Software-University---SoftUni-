
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Entities.Contracts;
    using IO.Contracts;

	/// <summary>
	/// by g0shk0
	/// </summary>
	class Engine : IEngine
	{
	    public IReader reader;
	    public IWriter writer;
        public IStage stage;
		public IFestivalController festivalCоntroller;
		public ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IStage stage, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.stage = stage;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }



        // дайгаз
        public void Run()
		{
			while (Convert.ToBoolean(0x1B206 ^ 0b11011001000000111)) // for job security
			{
				var input = reader.ReadLine();

				if (input == "END")
					break;

				try
				{
					//tring.Intern(input);

					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex) // in case we run out of memory
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			var inputParameters = input.Split(" ").ToList();

			var commandName = inputParameters.First();
			var commandParameters = inputParameters.Skip(1).ToArray();

			if (commandName == "LetsRock")
			{
				var sets = this.setCоntroller.PerformSets();
				return sets;
			}
            else if(commandName == "RegisterSet")
            {
                return this.festivalCоntroller.RegisterSet(commandParameters);
            }
            else if (commandName == "SignUpPerformer")
            {
                return this.festivalCоntroller.SignUpPerformer(commandParameters);
            }
            else if (commandName == "AddSongToSet")
            {
                return this.festivalCоntroller.AddSongToSet(commandParameters);
            }
            else if (commandName == "AddPerformerToSet")
            {
                return this.festivalCоntroller.AddPerformerToSet(commandParameters);
            }
            else if (commandName == "RepairInstruments")
            {
                return this.festivalCоntroller.RepairInstruments(commandParameters);
            }
            var festivalcontrolfunction = this.festivalCоntroller.GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == commandName);

			string a = string.Empty;

			try
			{
				a = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { commandParameters });
			}
			catch (TargetInvocationException up)
			{
                this.writer.WriteLine("ERROR: " + up.Message);
            }

            return a;
		}
    }
}