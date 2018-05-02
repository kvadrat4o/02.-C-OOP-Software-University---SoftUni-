namespace FestivalManager.Entities.Factories
{
	using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
	using Entities.Contracts;

	public class SongFactory : ISongFactory
	{
		public ISong CreateSong(string name, TimeSpan duration)
		{
            //var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == nameof(Song));
            //ISong instance = (ISong)Activator.CreateInstance(type, new object[] { type, duration });
            //return instance;

            var song = new Song(name, duration);
            return song;
        }
	}
}