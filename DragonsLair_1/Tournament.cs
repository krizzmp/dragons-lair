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
            //Round r1 = new Round();
            //Match match11 = new Match();
            //match11.FirstOpponent = new Team("The Valyrians");
            //match11.SecondOpponent = new Team("The Spartans");
            //match11.Winner = new Team("The Valyrians");
            //r1.AddMatch(match11);

            //Match match12 = new Match();
            //match12.FirstOpponent = new Team("The Cretans");
            //match12.SecondOpponent = new Team("The Thereans");
            //match12.Winner = new Team("The Thereans");
            //r1.AddMatch(match12);

            //Match match13 = new Match();
            //match13.FirstOpponent = new Team("The Coans");
            //match13.SecondOpponent = new Team("The Cnideans");
            //match13.Winner = new Team("The Coans");
            //r1.AddMatch(match13);

            //Match match14 = new Match();
            //match14.FirstOpponent = new Team("The Megareans");
            //match14.SecondOpponent = new Team("The Corinthians");
            //match14.Winner = new Team("The Corinthians");
            //r1.AddMatch(match14);
            //rounds.Add(r1);
            //Round r2 = new Round();

            //Match match21 = new Match();
            //match21.FirstOpponent = new Team("The Valyrians");
            //match21.SecondOpponent = new Team("The Thereans");
            //match21.Winner = new Team("The Valyrians");
            //r2.AddMatch(match21);

            //Match match22 = new Match();
            //match22.FirstOpponent = new Team("The Coans");
            //match22.SecondOpponent = new Team("The Corinthians");
            //match22.Winner = new Team("The Coans");
            //r2.AddMatch(match22);

            //Round r3 = new Round();
            //Match match31 = new Match();
            //match31.FirstOpponent = new Team("The Valyrians");
            //match31.SecondOpponent = new Team("The Coans");
            //match31.Winner = new Team("The Coans");
            //r3.AddMatch(match31);
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
    }
}