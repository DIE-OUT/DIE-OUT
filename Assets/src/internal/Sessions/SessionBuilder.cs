using System;
using System.Collections.Generic;

namespace DieOut.Sessions {
    
    [Serializable]
    public class SessionBuilder {

        public int PlayerCount;
        public HashSet<GameMode.Management.GameMode> ActivatedGameModes = new HashSet<GameMode.Management.GameMode>();
        public int MaxRounds = 5;
        public int WinningScore = 3;

        public bool IsValid() {
            if(MaxRounds < 1) return false;
            if(PlayerCount < 2) return false;
            if(ActivatedGameModes.Count == 0) return false;
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
