using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace DieOut.Sessions {
    
    [Serializable]
    public class SessionBuilder {

        public HashSet<GameMode.Management.GameMode> ActivatedGameModes = new HashSet<GameMode.Management.GameMode>();
        public int MaxRounds;
        public int WinningScore;
        
        
        public Session Create() {

            Player[] players = CreatePlayers();
            
            // validate
            if(players.Length < 2) throw new Exception("Session Builder is invalid or incomplete: too less players");
            if(ActivatedGameModes.Count == 0) throw new Exception("Session Builder is invalid or incomplete: required to have one or more game modes activated");
            
            return new Session(players, ActivatedGameModes, MaxRounds, WinningScore);
        }

        private Player[] CreatePlayers() {
            
            List<Player> players = new List<Player>();
            
            if(Keyboard.current != null && Mouse.current != null)
                players.Add(new Player(new InputDevice[] { Keyboard.current, Mouse.current }));
            
            for(int i = 0; i < Gamepad.all.Count; i++) {
                players.Add(new Player(new InputDevice[] { Gamepad.all[0] }));
            }
            
            return players.ToArray();
        }
        
    }
    
}
