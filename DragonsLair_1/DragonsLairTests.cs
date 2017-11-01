using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonsLair_1
{
    [TestClass]
    public class DragonsLairTests
    {
        private Tournament currentTournament;

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
        public void CanChangeStatus()
        {
            currentTournament.SetStatus(true);
            Assert.AreEqual(true, currentTournament.Status);
        }

        [TestMethod]
        public void CanAddFreeRider()
        {
            Team team = new Team("test");
            Round round = new Round();
            round.AddFreeRider(team);
            Assert.AreEqual(team, round.GetFreeRider());
        }

        [TestMethod]
        public void TournamentStartsWithSingleRound()
        {
            Assert.AreEqual(1, currentTournament.GetNumberOfRounds());
        }

        [TestMethod]
        public void CanGetMatch()
        {
            string teamName = "Team4";
            Round round = new Round();
            Match match2 = new Match {FirstOpponent = new Team("Team3"), SecondOpponent = new Team("Team4")};
            Match match1 = new Match {FirstOpponent = new Team("Team1"), SecondOpponent = new Team("Team2")};

            round.AddMatch(match1);
            round.AddMatch(match2);

            Assert.AreEqual(match2, round.GetMatch(teamName));
        }

        [TestMethod]
        public void CanGetTeam()
        {
            string teamName = "The Coans";
            Team team = currentTournament.GetTeam(teamName);

            Assert.AreEqual(teamName, team.Name);
        }
    }
}