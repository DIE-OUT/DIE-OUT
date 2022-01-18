using System;

namespace DieOut.Sessions {
    
    public class SessionBuilder {
        
        public int PlayerCount { get; set; }
        public GameMode.GameMode ActivatedGameModes { get; set; } = GameMode.GameMode.Dornenkrone;
        public int MaxRounds { get; set; } = 5;
        public int WinningScore { get; set; } = 3;

        public bool IsValid() {
            if(MaxRounds < 1) return false;
            if(PlayerCount < 2) return false;
            if(ActivatedGameModes == 0) return false;
            return true;
        }
        
        public Session Create() {
            if(!IsValid())
                throw new Exception("Session Builder is invalid or incomplete - check before creating");
            
            Player[] players = new Player[PlayerCount];
            for(int i = 0; i < PlayerCount; i++) {
                players[i] = new Player();
            }
            
            return new Session(players, MaxRounds, WinningScore);
        }
        
    }
    
}
