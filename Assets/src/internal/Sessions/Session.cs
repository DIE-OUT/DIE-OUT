using System;
using System.Collections.Generic;
using System.Linq;
using DieOut.GameMode.Management;
using DieOut.SceneManagement;

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

        public void GoNext() {
            if(ValidateWin())
                throw new NotImplementedException("A player won the game");

            LoadNextGameMode();
        }

        private void LoadNextGameMode() {
            int randomGameModeIndex = new Random().Next(0, ActivatedGameModes.Count - 1);
            GameMode.Management.GameMode newGameMode = ActivatedGameModes.ToArray()[randomGameModeIndex];
            int randomMapIndex = new Random().Next(0, newGameMode.Maps.Length - 1);
            Map newMap = newGameMode.Maps[randomMapIndex];
            SceneManager.LoadScenesAsync(newMap.Scene); //todo: add newGameMode.AdditionalScenes
        }

        public bool ValidateWin() {
            return false;
        }
        
    }
    
}
