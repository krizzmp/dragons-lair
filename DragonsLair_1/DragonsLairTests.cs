using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonsLair_1
{
    [TestClass]
    public class DragonsLairTests
    {
        Tournament currentTournament;

        [TestInitialize]
        public void SetupForTest()
        {
            currentTournament = new Tournament("Vinter Turnering");
        }

        [TestMethod]
        public void TournamentHasEvenNumberOfTeams()
        {
            int numberOfTeams = currentTournament.GetTeams().Count;
            Assert.AreEqual(0, numberOfTeams % 2);
        }

        [TestMethod]
        public void EqualNumberOfWinnersAndLosersPerRound()
        {
            int numberOfRounds = currentTournament.GetNumberOfRounds();
            for (int round = 0; round < numberOfRounds - 1; round++)
            {
                Round currentRound = currentTournament.GetRound(round);
                int numberOfWinningTeams = currentRound.GetWinningTeams().Count;
                int numberOfLosingTeams = currentRound.GetLosingTeams().Count;
                Assert.AreEqual(numberOfWinningTeams, numberOfLosingTeams);
            }
        }

        //[TestMethod]
        //public void OneWinnerInLastRound()
        //{
        //    // Verifies there is exactly one winner in last round
        //    int numberOfRounds = currentTournament.GetNumberOfRounds();
        //    Round currentRound = currentTournament.GetRound(numberOfRounds - 1);
        //    int numberOfWinningTeams = currentRound.GetWinningTeams().Count;
        //    Assert.AreEqual(1, numberOfWinningTeams);
        //}

        [TestMethod]
        public void AllMatchesInPreviousRoundsFinished()
        {
            bool matchesFinished = true;
            int numberOfRounds = currentTournament.GetNumberOfRounds();
            for (int round = 0; round < numberOfRounds - 1; round++)
            {
                Round currentRound = currentTournament.GetRound(round);
                if (currentRound.IsMatchesFinished() == false)
                    matchesFinished = false;
            }
            Assert.AreEqual(true, matchesFinished);
        }

        [TestMethod]
        public void CanAddRound()
        {
            Round round = new Round();
            round.AddMatch(new Match {FirstOpponent = new Team("abc"), SecondOpponent = new Team("bcd")});
            currentTournament.AddRound(round);
            Assert.AreEqual(round, currentTournament.GetRound(1));
        }
        [TestMethod]
        public void CanChangeStatus() {
            currentTournament.SetStatus(true);
            Assert.AreEqual(true, currentTournament.Status);
        }
        [TestMethod]
        public void CanAddFreeRider() {
            Team team = new Team("test");
            Round round = new Round();
            round.AddFreeRider(team);
            Assert.AreEqual(team, round.GetFreeRider());
        }
        [TestMethod]
        public void ScheduleRoundForEmptyTournament() {
            
            //Assert.AreEqual(team, round.GetFreeRider());
        }

        [TestMethod]
        public void CanGetMatch()
        {
            
            string Teamname = "Team4";
            Round round = new Round();
            Match match2 = new Match { FirstOpponent = new Team("Team3"), SecondOpponent = new Team("Team4") };
            Match match1 = new Match { FirstOpponent = new Team("Team1"), SecondOpponent = new Team("Team2") };

            round.AddMatch(match1);
            round.AddMatch(match2);

            //currentTournament.AddRound(round);
            Assert.AreEqual(match2, round.GetMatch(Teamname));
        }
        [TestMethod]
        public void CanGetTeam()
        {
            string Teamname = "The Coans";

            string TeamName = currentTournament.GetTeam(Teamname).Name;
            //currentTournament.AddRound(round);
            Assert.AreEqual(Teamname, TeamName);
        }

    }
}