using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            List<Team> teams = new List<Team>();
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(new char[] { ';' },StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (tokens[0])
                    {
                        case "Add":
                            string teamNames = tokens[1];
                            if (!teams.Any(a => a.Name == teamNames))
                            {
                                throw new ArgumentException($"Team {teamNames} does not exist.");
                            }
                            string playaName = tokens[2];
                            int playaEndurance = int.Parse(tokens[3]);
                            int playaSprint = int.Parse(tokens[4]);
                            int playaDribble = int.Parse(tokens[5]);
                            int playaPassing = int.Parse(tokens[6]);
                            int playaShooting = int.Parse(tokens[7]);
                            Player playa = new Player(playaShooting, playaPassing, playaDribble, playaSprint, playaEndurance, playaName);
                            Team teamOne = teams.FirstOrDefault(a => a.Name == teamNames);
                            teamOne.AddPlayer(playa);
                            break;
                        case "Remove":
                            string teamName = tokens[1];
                            string playerName = tokens[2]; Team team1 = teams.FirstOrDefault(a => a.Name == teamName);
                            Player player1 = new Player(playerName);
                            team1.RemovePlayer(player1);
                            break;
                        case "Team":
                            string name = tokens[1];
                            Team tm = new Team(name);
                            teams.Add(tm);
                            break;
                        case "Rating":
                            string tName = tokens[1];
                            if (!teams.Any(a => a.Name == tName))
                            {
                                throw new ArgumentException($"Team {tName} does not exist.");
                            }
                            Team team = teams.FirstOrDefault(a => a.Name == tName);
                            Console.WriteLine($"{team.Name} - {team.GetTeamRating()}");
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
               

            }
        }
    }
}
