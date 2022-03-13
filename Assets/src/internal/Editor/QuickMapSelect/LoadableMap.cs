using System;
using System.Collections.Generic;
using Afired.GameManagement.GameModes;
using Afired.GameManagement.Sessions;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

namespace DieOut.Editor {
    
    [Serializable]
    public struct LoadableMap {

        private GameMode _gameMode;
        private Map _map;
        
        public LoadableMap(GameMode gameMode, Map map) {
            _map = map;
            _gameMode = gameMode;
        }
        
        private string GetTitle() {
            return string.IsNullOrEmpty(_map.DisplayName) ? "Untitled Map" : _map.DisplayName;
        }
        
        [Button("@GetTitle()")]
        public void Load() {
            Session.SetNew(new Session(CreatePlayers(), new HashSet<GameMode>(), 1, 1));
            Session.Current.LoadGameMode(_gameMode , _map);
        }
        
        private Player[] CreatePlayers() {
            
            List<InputDevice> playerInputDevices = new List<InputDevice>();
            
            if(Keyboard.current != null)
                playerInputDevices.Add(Keyboard.current);
            
            for(int i = 0; i < Gamepad.all.Count; i++) {
                playerInputDevices.Add(Gamepad.all[i]);
            }
            
            Player[] players = new Player[playerInputDevices.Count];
            for(int i = 0; i < playerInputDevices.Count; i++) {
                if(playerInputDevices[i] is Keyboard)
                    players[i] = new Player(new InputDevice[] { playerInputDevices[i], Mouse.current }, CharacterRegister.Characters[i]);
                else
                    players[i] = new Player(new InputDevice[] { playerInputDevices[i] }, CharacterRegister.Characters[i]);
            }
            
            return players;
        }
        
    }
    
}
