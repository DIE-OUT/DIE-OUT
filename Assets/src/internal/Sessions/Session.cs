using System;
using System.Collections.Generic;

namespace DieOut.Sessions {
    
    [Serializable]
    public class Session {

        public int PlayerCount => Player.Length;
        public Player[] Player { get; }
        public HashSet<GameMode.Management.GameMode> ActivatedGameModes { get; }
        public int MaxRounds { get; }
        public int WinningScore { get; }
        
        public int CurrentRound { get; private set; }
        
        public Session(Player[] player, HashSet<GameMode.Management.GameMode> activatedGameModes, int maxRounds, int winningScore) {
            Player = player;
            ActivatedGameModes = activatedGameModes;
            MaxRounds = maxRounds;
            WinningScore = winningScore;

            CurrentRound = 0;
        }
        
    }
    
}
