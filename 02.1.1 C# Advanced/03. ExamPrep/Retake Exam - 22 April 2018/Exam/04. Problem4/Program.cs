namespace _04._Problem4
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, TimeSpan> allMovies = new Dictionary<string, TimeSpan>();
            Dictionary<string, TimeSpan> movies = new Dictionary<string, TimeSpan>();
            string gernePreferred = Console.ReadLine();
            string durationPreferred = Console.ReadLine();
            var input = "";
            while ((input = Console.ReadLine()) != "POPCORN!")
            {
                if (input == "POPCORN!")
                {
                    break;
                }
                var inputTokens = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string movieName = inputTokens[0];
                string movieGerne = inputTokens[1];
                string movieDurationString = inputTokens[2];
                //TimeSpan movieDuration = TimeSpan.ParseExact(movieDurationString, "HH:mm:ss", CultureInfo.InvariantCulture);
                TimeSpan movieDuration = TimeSpan.Parse(movieDurationString);
                if (movieGerne == gernePreferred)
                {
                    if (!movies.ContainsKey(movieName))
                    {
                        movies[movieName] = movieDuration;
                    }
                    else
                    {
                        movies[movieName] = movieDuration;
                    }
                }
                allMovies[movieName] = movieDuration;
            }
            TimeSpan movieTime = new TimeSpan(0, 0, 0);
            foreach (var movie in allMovies.Values)
            {
                movieTime += movie;
            }
            //var totalPlaylistDurationHours = (int)movies.Values.Sum(d => d.Hours);
            //var totalPlaylistDurationMins = (int)movies.Values.Sum(de => de.Minutes);
            //var totalPlaylistDurationSecs = (int)movies.Values.Sum(dr => dr.Seconds);
            //TimeSpan totalMoveiTime = new TimeSpan(totalPlaylistDurationHours,totalPlaylistDurationMins,totalPlaylistDurationSecs);
            string inputAnswer = String.Empty;
            if (durationPreferred == "Short")
            {
                movies = movies.OrderBy(m => m.Value.Ticks).ThenBy(a => a.Key).ToDictionary(m => m.Key, m => m.Value);
            }
            else
            {
                movies = movies.OrderByDescending(m => m.Value.Ticks).ThenBy(a => a.Key).ToDictionary(m => m.Key, m => m.Value);
            }
            foreach (var moviesNamesDurations in movies)
            {
                var movieDur = moviesNamesDurations.Value;
                var movieNam = moviesNamesDurations.Key;
                Console.WriteLine($"{movieNam}");
                if ((inputAnswer = Console.ReadLine()) == "Yes")
                {
                    Console.WriteLine($"We're watching {movieNam} - {movieDur}");
                    Console.WriteLine($"Total Playlist Duration: {movieTime}");
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
