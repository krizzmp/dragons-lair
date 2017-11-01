using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonsLair_1
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = new TournamentRepo();

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
            Tournament tournament = tournamentRepository.GetTournament(tournamentName);
            int numberOfRounds = tournament.GetNumberOfRounds();
            List<Team> teams;
            Round lastRound = null;
            if (numberOfRounds == 0)
            {
                teams = tournament.GetTeams();
            }
            else
            {
                lastRound = tournament.GetRound(numberOfRounds - 1);
                if (!lastRound.IsMatchesFinished())
                {
                    Console.WriteLine("the current round has not finished");
                    Console.WriteLine("press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }

                teams = lastRound.GetWinningTeams();

                Team lastFreeRider = lastRound.GetFreeRider();
                if (lastFreeRider != null)
                {
                    teams.Add(lastFreeRider);
                }
            }
            if (teams.Count >= 2)
            {
                Random rnd = new Random();
                //teams = new List<Team>(teams.OrderBy(t => rnd.Next()));
                List<Team> randomTeams = new List<Team>();
                while (teams.Count > 0)
                {
                    int randomNr = rnd.Next(0, teams.Count);
                    randomTeams.Add(teams[randomNr]);
                    teams.RemoveAt(randomNr);
                }


                Round newRound = new Round();
                if (randomTeams.Count % 2 == 1)
                {
                    Team oldFreeRider = lastRound?.GetFreeRider();
                    foreach (Team team in randomTeams)
                    {
                        if (team != oldFreeRider)
                        {
                            randomTeams.Remove(team);
                            newRound.AddFreeRider(team);
                            break;
                        }
                    }
                }

                while (randomTeams.Count != 0)
                {
                    Match match = new Match();
                    Team first = randomTeams[0];
                    randomTeams.RemoveAt(0);
                    Team second = randomTeams[0];
                    randomTeams.RemoveAt(0);
                    match.FirstOpponent = first;
                    match.SecondOpponent = second;
                    newRound.AddMatch(match);
                }
                tournament.AddRound(newRound);
                if (printNewMatches)
                {
                    ShowRound(newRound);
                }
            }
            else
            {
                tournament.SetStatus(true);
            }
        }

        private void ShowRound(Round round)
        {
            foreach (Match match in round.matches)
            {
                Console.WriteLine($"{match.FirstOpponent.Name} vs. {match.SecondOpponent.Name}");
            }
            string freeRider = round.GetFreeRider()?.Name ?? "none";
            Console.WriteLine($"free rider is: {freeRider}");
        }

        public Result SaveMatch(string tournamentName, int roundNumber, string winningTeam)
        {
            Tournament tournament = tournamentRepository.GetTournament(tournamentName);
            Round round = tournament.GetRound(roundNumber - 1);
            Match match = round.GetMatch(winningTeam);
            if (match != null && match.Winner == null)
            {
                var winner = tournament.GetTeam(winningTeam);
                match.Winner = winner;
                return Result.Succes;
            }
            return Result.Failure;
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

    public enum Result {
        Succes,
        Failure
    }
}