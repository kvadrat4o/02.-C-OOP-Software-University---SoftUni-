using System;
using System.Collections.Generic;
using System.Text;

public class Song
{
    private string name;
    private string artist;
    private TimeSpan length;

    public TimeSpan Length
    {
        get { return length; }
        set
        {
            if (value.Seconds < 0 || value.Seconds > 899)
            {
                throw new InvalidSongLengthException();
            }
            length = value;
        }
    }

    public string Artist
    {
        get { return artist; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException ();
            }
            artist = value;
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }
            name = value;
        }
    }

    public Song()
    {

    }

    public Song(TimeSpan length,string artist, string name)
    {
        this.Length = length;
        this.Artist = artist;
        this.Name = name;
    }
}