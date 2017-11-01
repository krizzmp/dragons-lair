using System.Collections.Generic;
using System.Linq;

namespace DragonsLair_1
{
    public class Round
    {
        public List<Match> matches = new List<Match>();
        private Team FreeRider;


        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string teamName)
        {
            Match foundMatch = null;
            foreach (Match match in matches)
            {
                if(match.FirstOpponent.Name == teamName)
                {
                    foundMatch = match;
                    break;
                }else if (match.SecondOpponent.Name == teamName)
                {
                    foundMatch = match;
                    break;
                } 
            }

            return foundMatch;
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

        public void AddFreeRider(Team team)
        {
            FreeRider = team;
        }

        public Team GetFreeRider()
        {
            return FreeRider;
        }
    }
}