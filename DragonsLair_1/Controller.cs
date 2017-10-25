using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DragonsLair_1
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = new TournamentRepo();

        public void ShowScore(string tournamentName)
        {
            /*
             * TODO: Calculate for each team how many times they have won
             * Sort based on number of matches won (descending)
             */
            Tournament tournament = tournamentRepository.GetTournament(tournamentName);
            IEnumerable<Round> rounds = GetRounds(tournament);
            var enumerable = rounds
                .SelectMany(r => r.GetWinningTeams())
                .GroupBy(t => t.Name)
                .Select(g => new
                    {
                        points = g.Count(),
                        teamName = g.Key
                    }
                )
                .ToDictionary(e => e.teamName);
            string scores = tournament.GetTeams()
                .Select(t =>
                {
                    var points = enumerable.ContainsKey(t.Name) ? enumerable[t.Name].points : 0;
                    return new {TeamName = t.Name, Points = points};
                })
                .OrderByDescending(e => e.Points)
                .Select(e => $"{e.TeamName.PadRight(20)} | points: {e.Points}")
                .Aggregate((a, b) => a + "\n" + b);
            Console.WriteLine(scores);
        }

        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {
            // Do not implement this method
        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            // Do not implement this method
        }

        private IEnumerable<Round> GetRounds(Tournament tournament)
        {
            int numberOfRounds = tournament.GetNumberOfRounds();
            List<Round> rounds = new List<Round>(numberOfRounds);
            for (int i = 0; i < numberOfRounds; i++)
            {
                rounds.Add(tournament.GetRound(i));
            }
            return rounds;
        }
    }
}