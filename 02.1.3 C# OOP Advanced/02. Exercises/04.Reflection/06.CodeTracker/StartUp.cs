﻿using System;

namespace _06.CodeTracker
{
    [SoftUni("Ventsi")]
    class StartUp
    {
        [SoftUni("Gosho")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
