namespace _03._Problem3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> seats = new List<string>();
            List<int> seatsNumbers = new List<int>();
            var ticketInfo = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            string destinationCountry = ticketInfo[0];
            string destinationTown = ticketInfo[1];
            var suitcase = Console.ReadLine();
            var firstSubstringOfSquareBracet = suitcase.IndexOf('[');
            var lastSubstringOfSquareBracet = suitcase.IndexOf(']');
            var firstSubstringOfcurlyeBracet = suitcase.IndexOf('{');
            var lasttSubstringOfCurlyBracet = suitcase.IndexOf('}');
            string ticketRegex1 = @"\[[\x00-\x7F]*?\{(?<CountryCode>[A-Z]{3})\s(?<TownCode>[A-Z]{2})\}[\x00-\x7F]*?\{(?<TicketSeat>[A-Z]{1}[\d+]*?)\}[\x00-\x7F]*?\]";
            string ticketRegex2 = @"\{[^\x5B\x5D\x7D\x7B]*?\[(?<CountryCode>[A-Z]{3})\s(?<TownCode>[A-Z]{2})\][^\x5B\x5D\x7D\x7B]*?\[(?<TicketSeat>[A-Z]{1}[\d+]*?)\][\x00-\x7F]*?\}";
            var matches1 = Regex.Matches(suitcase, ticketRegex1);
            List<string> seatsMatched = new List<string>();
            foreach (Match match in matches1)
            {
                var destinationC = match.Groups["CountryCode"].Value;
                var destinationT = match.Groups["TownCode"].Value;
                var ticketSeat = match.Groups["TicketSeat"].Value;
                if (destinationC == destinationCountry && destinationT == destinationTown)
                {
                    seats.Add(ticketSeat);
                }
            }
            var matches2 = Regex.Matches(suitcase, ticketRegex2);
            foreach (Match match in matches2)
            {
                var destinationC = match.Groups["CountryCode"].Value;
                var destinationT = match.Groups["TownCode"].Value;
                var ticketSeat = match.Groups["TicketSeat"].Value;
                if (destinationC == destinationCountry && destinationT == destinationTown)
                {
                    seats.Add(ticketSeat);
                }
            }
            bool areMatched = false;
            foreach (var ticket in seats)
            {
                for (int i = 1; i < seats.Count; i++)
                {
                    var substr = seats[i].Substring(1);
                    if (ticket.EndsWith(substr))
                    {
                        seatsMatched.Add(ticket);
                        seatsMatched.Add(seats[i]);
                        areMatched = true;
                        break;
                    }
                }
                if (areMatched)
                {
                    break;
                }
            }
            seatsMatched = seatsMatched.Distinct().ToList();
            if (seatsMatched.Count == 2)
            {
                Console.WriteLine($"You are traveling to {destinationCountry} {destinationTown} on seats {seatsMatched[0]} and {seatsMatched[1]}.");
            }
            else
            {
                Console.WriteLine($"You are traveling to {destinationCountry} {destinationTown} on seats {seats[0]} and {seats[1]}.");
            }
        }
    }
}
