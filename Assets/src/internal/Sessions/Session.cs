using System;

namespace DieOut.Sessions {
    
    [Serializable]
    public class Session {

        public int PlayerCount => Player.Length;
        public Player[] Player { get; }
        public int MaxRounds { get; }
        public int WinningScore { get; }
        
        public int CurrentRound { get; private set; }
        
        public Session(Player[] player, int maxRounds, int winningScore) {
            Player = player;
            MaxRounds = maxRounds;
            winningScore = WinningScore;

            CurrentRound = 0;
        }
        
    }
    
}
