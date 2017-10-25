using System.Collections.Generic;

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
            // TODO: Implement this method
            return null;
        }

        public List<Team> GetLosingTeams()
        {
            List<Team> LosingTeams = new List<Team>();
            
            foreach(var Match in matches)
            {
                Team Winner = Match.Winner;
                if(Winner == Match.FirstOpponent)
                {
                    LosingTeams.Add(Match.SecondOpponent);
                }else if (Winner == Match.SecondOpponent)
                {
                    LosingTeams.Add(Match.FirstOpponent);
                }
            }
           
            return LosingTeams;
        }
    }
}
