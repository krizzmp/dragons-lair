using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonsLair_1
{
    [TestClass]
    public class ControllerTests
    {
        Controller controller;

        [TestInitialize]
        public void SetupForTest()
        {
            controller = new Controller();
        }

        [TestMethod]
        public void CanSaveMatch()
        {
            controller.SaveMatch("", 1, "The Valyrians");

            Tournament tournament = controller.tournamentRepository.GetTournament("");
            Assert.IsTrue(tournament.GetRound(0).GetWinningTeams().Exists(team => team.Name == "The Valyrians"));
        }
        
    }
}