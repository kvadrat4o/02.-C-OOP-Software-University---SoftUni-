using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongMinutesException : InvalidSongException
{
    public InvalidSongMinutesException() : base("Song minutes should be between 0 and 14.")
    {

    }

    public InvalidSongMinutesException(string message) : base(message)
    {

    }
}
