﻿namespace DragonsLair_1
{
    public class TournamentRepo
    {
        private Tournament winterTournament = new Tournament("Vinter Turnering");

        public Tournament GetTournament(string name)
        {
            if (name == "Vinter Turnering")
            {
                return winterTournament;
            }
            return winterTournament;
        }
    }
}