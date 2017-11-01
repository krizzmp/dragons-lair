using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DragonsLair_1
{
    public class Tournament
    {
        public bool Status = false;
        public string Name { get; set; }
        private readonly List<Round> rounds = new List<Round>();

        public Tournament(string tournamentName)
        {
            Name = tournamentName;
            CreateRound();
        }

        public List<Team> GetTeams()
        {
            return new List<Team>(new Team[]
            {
                new Team("The Valyrians"),
                new Team("The Spartans"),
                new Team("The Cretans"),
                new Team("The Thereans"),
                new Team("The Coans"),
                new Team("The Cnideans"),
                new Team("The Megareans"),
                new Team("The Corinthians")
            });
        }

        public void CreateRound()
        {
            List<Team> teams;
            Round lastRound = null;
            int numberOfRounds = GetNumberOfRounds();
            if (numberOfRounds == 0) {
                teams = GetTeams();
            } else {
                lastRound = GetRound(numberOfRounds - 1);
                if (!lastRound.IsMatchesFinished()) {
                    Console.WriteLine("the current round has not finished");
                    Console.WriteLine("press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }

                teams = lastRound.GetWinningTeams();

                Team lastFreeRider = lastRound.GetFreeRider();
                if (lastFreeRider != null) {
                    teams.Add(lastFreeRider);
                }
            }
            if (teams.Count >= 2) {
                Random rnd = new Random();
                //teams = new List<Team>(teams.OrderBy(t => rnd.Next()));
                List<Team> randomTeams = new List<Team>();
                while (teams.Count > 0) {
                    int randomNr = rnd.Next(0, teams.Count);
                    randomTeams.Add(teams[randomNr]);
                    teams.RemoveAt(randomNr);
                }


                Round newRound = new Round();
                if (randomTeams.Count % 2 == 1) {
                    Team oldFreeRider = lastRound?.GetFreeRider();
                    foreach (Team team in randomTeams) {
                        if (team != oldFreeRider) {
                            randomTeams.Remove(team);
                            newRound.AddFreeRider(team);
                            break;
                        }
                    }
                }

                while (randomTeams.Count != 0) {
                    Match match = new Match();
                    Team first = randomTeams[0];
                    randomTeams.RemoveAt(0);
                    Team second = randomTeams[0];
                    randomTeams.RemoveAt(0);
                    match.FirstOpponent = first;
                    match.SecondOpponent = second;
                    newRound.AddMatch(match);
                }
                AddRound(newRound);
            } else {
                SetStatus(true);
            }
        }
        public void AddRound(Round round)
        {
            rounds.Add(round);
        }

        public int GetNumberOfRounds()
        {
            return rounds.Count;
        }

        public Round GetRound(int idx)
        {
            return rounds[idx];
        }

        public void SetStatus(bool finished = true)
        {
            Status = finished;
        }

        public Team GetTeam(string Teamname)
        {
            return null;
        }


    }
}