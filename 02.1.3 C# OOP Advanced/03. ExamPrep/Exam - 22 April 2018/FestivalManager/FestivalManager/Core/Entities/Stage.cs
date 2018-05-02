namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;
    using System.Linq;
    using System.Collections.ObjectModel;

    public class Stage : IStage
	{
		// да си вкарват през полетата бе
		private List<ISet> sets;
		private List<ISong> songs;
		private List<IPerformer> performers;


        public IReadOnlyCollection<ISet> Sets { get { return this.sets.AsReadOnly(); } }

        public IReadOnlyCollection<ISong> Songs { get { return this.songs.AsReadOnly(); } }

        public IReadOnlyCollection<IPerformer> Performers { get { return this.performers.AsReadOnly(); } }

        public Stage()
        {
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
            this.sets = new List<ISet>();
        }
 
        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.Performers.FirstOrDefault(p => p.Name == name);
            return performer;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.Songs.FirstOrDefault(s => s.Name == name);
            return song;
        }

        public ISet GetSet(string name)
        {
            ISet set = this.Sets.FirstOrDefault(s => s.Name == name);
            return set;
        }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }
 
        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public bool HasPerformer(string name)
        {
            if (!this.Performers.Any(p => p.Name == name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool HasSong(string name)
        {
            if (!this.Songs.Any(p => p.Name == name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool HasSet(string name)
        {
            if (!this.Sets.Any(p => p.Name == name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
