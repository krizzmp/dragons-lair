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
            return matches.Where(m => (
                                          m.FirstOpponent.Name == teamName1 &&
                                          m.SecondOpponent.Name == teamName2
                                      ) || (
                                          m.SecondOpponent.Name == teamName1 &&
                                          m.FirstOpponent.Name == teamName2
                                      )
            ).Single();
        }

        public bool IsMatchesFinished()
        {
            return matches.TrueForAll(m => m.Winner != null);
        }

        public List<Team> GetWinningTeams()
        {
            List<Team> WinningTeams = new List<Team>();

            foreach (var Match in matches)
            {
                Team Winner = Match.Winner;
                if (Winner != null)
                {
                    WinningTeams.Add(Winner);
                }
            }
            // TODO: Implement this method
            return WinningTeams;
        }

        public List<Team> GetLosingTeams()
        {
            List<Team> LosingTeams = new List<Team>();

            foreach (var Match in matches)
            {
                string WinnerName = Match.Winner.Name ?? "";
                if (WinnerName == Match.FirstOpponent.Name)
                {
                    LosingTeams.Add(Match.SecondOpponent);
                }
                else if (WinnerName == Match.SecondOpponent.Name)
                {
                    LosingTeams.Add(Match.FirstOpponent);
                }
            }

            return LosingTeams;
        }
    }
}