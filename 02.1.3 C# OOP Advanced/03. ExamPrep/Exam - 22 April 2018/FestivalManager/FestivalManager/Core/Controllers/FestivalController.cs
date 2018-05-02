namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private readonly IStage stage;
        private ISetFactory setFactory;
        private IPerformerFactory performerFactory;
        private ISongFactory songFactory;
        private IInstrumentFactory instrumentFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.setFactory = new SetFactory();
            this.songFactory = new SongFactory();
            this.performerFactory = new PerformerFactory();
            this.instrumentFactory = new InstrumentFactory();
        }

        public string ProduceReport()
        {
            StringBuilder sb = new StringBuilder();
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
            if (totalFestivalLength == new TimeSpan(1,0,0))
            {
                sb.AppendLine($"Festival length: 60:00");
            }
            else
            {
                sb.AppendLine($"Festival length: {totalFestivalLength.ToString(TimeFormat)}");
            }
            foreach (var set in this.stage.Sets)
            {
                if (set.ActualDuration == new TimeSpan(1, 0, 0))
                {
                    sb.AppendLine($"--{set.Name} (60:00):");
                }
                else
                {
                    sb.AppendLine($"--{set.Name} ({set.ActualDuration.ToString(TimeFormat)}):");
                }
                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));
                    
                    sb.AppendLine($"---{performer.Name} ({instruments})");
                }

                if (!set.Songs.Any())
                {
                    sb.AppendLine("--No songs played");
                }
                else
                {
                    sb.AppendLine("--Songs played:");
                    foreach (var song in set.Songs)
                    {
                        sb.AppendLine($"----{song.Name} ({song.Duration.ToString(TimeFormat)})");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RegisterSet(string[] args)
        {
            //RegisterSet {name} {type}

            string name = args[0];
            string type = args[1];
            var performer = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(performer);
            return $"Registered {type} set";
        }

        public string SignUpPerformer(string[] args)
        {
            //SignUpPerformer {name} {age} {instrument1} {instrument2} {instrumentN}
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumentParams = args.Skip(2).ToArray();

            var instruments = instrumentParams
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            // RegisterSong {name} {mm:ss}
            string songName = args[0];
            TimeSpan duration = TimeSpan.Parse(args[1]);
            var song = this.songFactory.CreateSong(songName, duration);
            this.stage.AddSong(song);
            return $"Registered song {songName} ({song.Duration.ToString(TimeFormat)})";
        }

        public string AddSongToSet(string[] args)
        {
            //AddSongToSet {songName} {setName}
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {songName} ({song.Duration.ToString(TimeFormat)}) to {set.Name}";
        }

        // Временно!!! Чтобы работало делаем срез на конец месяца
        public string AddPerformerToSet(string[] args)
        {
            //AddPerformerToSet {performerName} {setName}
            return PerformerRegistration(args);
        }

        public string PerformerRegistration(string[] args)
        {
            //AddPerformerToSet {performerName} {setName}
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }


            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);
            //AddPerformerToSet(args);
            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {
            //RepairInstruments
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }
    }
}