using System;
using System.Collections.Generic;
using Afired.GameManagement.GameModes;
using DieOut.UI.CharacterSelect;
using UnityEngine.InputSystem;

namespace Afired.GameManagement.Sessions {
    
    [Serializable]
    public class SessionBuilder {

        public HashSet<GameMode> ActivatedGameModes = new HashSet<GameMode>();
        public int MaxRounds;
        public int WinningScore;
        public Player[] Players;
        
        
        public Session Create() {
            // validate
            if(Players == null) throw new Exception("Duplicate player colors");
            if(Players.Length < 2) throw new Exception("Session Builder is invalid or incomplete: too less players");
            if(ActivatedGameModes.Count == 0) throw new Exception("Session Builder is invalid or incomplete: required to have one or more game modes activated");
            
            return new Session(Players, ActivatedGameModes, MaxRounds, WinningScore);
        }
        
    }
    
}
