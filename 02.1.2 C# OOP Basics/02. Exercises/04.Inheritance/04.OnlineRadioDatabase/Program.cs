using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OnlineRadioDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    var input = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var timeTokens = input[2].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    string artist = input[0];
                    string songname = input[1];
                    var length = TimeSpan.TryParse("00:" + input[2], out TimeSpan result);
                    Song song = new Song(result, artist, songname);
                    ValidateSong(song);
                    if (int.Parse(timeTokens[0]) < 0 || int.Parse(timeTokens[0]) > 14)
                    {
                        throw new InvalidSongMinutesException();
                    }
                    if (int.Parse(timeTokens[1]) < 0 || int.Parse(timeTokens[1]) > 59)
                    {
                        throw new InvalidSongSecondsException();
                    }
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException fe)
                {
                    Console.WriteLine("Invalid song length.");
                }
            }
            var totalSeconds = TimeSpan.FromSeconds(songs.Sum(x => x.Length.Minutes * 60) + songs.Sum(x => x.Length.Seconds));
            Console.WriteLine($"Songs added: {songs.Count}\nPlaylist length: {totalSeconds.Hours}h {totalSeconds.Minutes}m {totalSeconds.Seconds}s");
        }

        private static void ValidateSong(Song song)
        {
            if (song.Artist == null || song.Name == null || song.Length.Seconds < 0 || song.Length.Seconds > 899 || song.Artist == String.Empty || song.Artist == "" || song.Artist == "  " || song.Artist == null || song.Artist == " " || song.Name == String.Empty || song.Name == "" || song.Name == "  " || song.Name == null || song.Name == " ")
            {
                throw new InvalidSongException();
            }
        }
    }
}
