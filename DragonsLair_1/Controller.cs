using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DragonsLair_1
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = new TournamentRepo();

        public void ShowScore_(string tournamentName)
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

        public void ShowScore__(string tournamentName)
        {
            Tournament tournament = tournamentRepository.GetTournament(tournamentName);
            IEnumerable<Round> rounds = GetRounds(tournament);

            IEnumerable<string> scores = rounds
                .SelectMany(r => r.GetWinningTeams())
                // IEnumerable<Team> : list of all winning teams with each team being reprecented as many times as they have won
                .Concat(tournament.GetTeams())
                // IEnumerable<Team> : list of all winning teams + all teams
                .GroupBy(team => team.Name)
                // IEnumerable<IGrouping<string, Team>> : a list of groups of teams grouped by team name
                .OrderByDescending(group => group.Count() - 1)
                // sorted by number of wins in decending order
                .Select(group => $"{group.Key.PadRight(20)} | points: {group.Count() - 1}");
                // list of strings eg. "teamName             | points: 1"
                // we have to subtract one from count because we added all the teams to the winning teams so they are counted twice
            foreach (string score in scores)
            {
                Console.WriteLine(score);
            }
        }

        public void ShowScore(string tournamentName)
        {
            Tournament tournament = tournamentRepository.GetTournament(tournamentName);
            IEnumerable<Round> rounds = GetRounds(tournament);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (Team team in tournament.GetTeams())
            {
                dict[team.Name] = 0;
            }
            foreach (Round round in rounds)
            {
                foreach (Team team in round.GetWinningTeams())
                {
                    dict[team.Name] += 1;
                }
            }

            IOrderedEnumerable<KeyValuePair<string, int>> orderedDict = dict.OrderByDescending(d => d.Value);
            foreach (KeyValuePair<string, int> group in orderedDict)
            {
                string paddedTeamName = group.Key.PadRight(20);
                int points = group.Value;
                Console.WriteLine($"{paddedTeamName} | points: {points}");
            }
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