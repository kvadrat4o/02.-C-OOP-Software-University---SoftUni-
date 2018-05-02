namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            if (type == null)
            {
                throw new ArgumentNullException("Args cannot be null!");
            }

            var entityType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            IInstrument instance = (IInstrument)Activator.CreateInstance(entityType, new object[] { });
            return instance;


			//if (type == "Drums")
			//{
			//	return new Drums();
			//}
			//else if (type == "Guitar")
			//{
			//	return new Guitar();
			//}
			//else
			//{
			//	return new Microphone();
			//}
		}
	}
}