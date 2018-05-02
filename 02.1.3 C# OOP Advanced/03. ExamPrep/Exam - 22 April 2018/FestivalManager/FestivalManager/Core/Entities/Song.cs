namespace FestivalManager.Entities
{
	using System;
	using Contracts;

	public class Song : ISong
    {
		public Song(string name, TimeSpan duration)
		{
            var hours = duration.Hours;
            var minutes = duration.Minutes;
			this.Name = name;
			this.Duration = new TimeSpan(0,hours,minutes);
		}

		public string Name { get; }

	    public TimeSpan Duration { get; }

	    public override string ToString()
	    {
		    return $"{this.Name} ({this.Duration:mm\\:ss})";
	    }
    }
}
