namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PerformerFactory : IPerformerFactory
	{
		public IPerformer CreatePerformer(string name, int age)
		{
            var performerType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == nameof(Performer));
            IPerformer instance = (IPerformer)Activator.CreateInstance(performerType, new object[] { name, age });
            return instance;

            //var performer = new Performer(name, age);

            //return performer;
        }
	}
}