using System.Collections.Generic;
using System.Linq;

namespace DragonsLair_1
{
    public class Round
    {
        private List<Match> matches = new List<Match>();
        
        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string teamName1, string teamName2)
        {
            // TODO: Implement this method
            return null;
        }

        public bool IsMatchesFinished()
        {
            // TODO: Implement this method
            return false;
        }

        public List<Team> GetWinningTeams()
        {
            
            List<Team> WinningTeams = new List<Team>();

            foreach (var Match in matches)
            {
                Team Winner = Match.Winner;
                WinningTeams.Add(Winner);
            }
            // TODO: Implement this method
            return WinningTeams;
        }

        public List<Team> GetLosingTeams()
        {
            // TODO: Implement this method
            return null;
        }
    }
}
