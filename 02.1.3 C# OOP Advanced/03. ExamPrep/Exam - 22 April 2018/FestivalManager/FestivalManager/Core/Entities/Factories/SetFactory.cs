using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;





namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            var setType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            ISet instance = (ISet)Activator.CreateInstance(setType, new object[] { name });
            return instance;
            

            //Type clazz = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type + "Provider");
            //var ctors = clazz.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            //IProvider provider = (IProvider)Activator.CreateInstance(clazz, new object[] { id, energyOutput });
            //return provider;

            //         if (type == "Short")
            //{
            //	return new Short(name);
            //}
            //else if (type == "Medium")
            //{
            //	return new Medium(name);
            //}
            //else if (type == "Long")
            //{
            //	return new Long(name);
            //}
        }
	}




}
