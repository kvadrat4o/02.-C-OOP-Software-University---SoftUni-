using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongSecondsException : InvalidSongException
{

    public InvalidSongSecondsException()
        : base("Song seconds should be between 0 and 59.")
    {

    }

    public InvalidSongSecondsException(string message) : base(message)
    {

    }
}
