using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DieOut.GameMode.Management;
using DieOut.SceneManagement;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityAsync;
using UnityEngine;
using Random = System.Random;

namespace DieOut.Sessions {

    public delegate void OnGameModePrepare();
    public delegate void OnGameModeStart();
    public delegate void OnGameModeEnd();
    
    [Serializable]
    public class Session {

        public event OnGameModePrepare OnGameModePrepare;
        public event OnGameModeStart OnGameModeStart;
        public event OnGameModeEnd OnGameModeEnd;
        [ReadOnly] [OdinSerialize] public int PlayerCount => Player.Length;
        [OdinSerialize] public Player[] Player { get; }
        [OdinSerialize] public HashSet<GameMode.Management.GameMode> ActivatedGameModes { get; }
        [OdinSerialize] public int MaxRounds { get; }
        [OdinSerialize] public int WinningScore { get; }
        
        [ReadOnly] [OdinSerialize] public int CurrentRound { get; private set; }
        
        public Session(Player[] player, HashSet<GameMode.Management.GameMode> activatedGameModes, int maxRounds, int winningScore) {
            Player = player;
            ActivatedGameModes = activatedGameModes;
            MaxRounds = maxRounds;
            WinningScore = winningScore;

            CurrentRound = 0;
        }

        public async Task GoNext() {
            if(ValidateWin())
                throw new NotImplementedException("A player won the game");
            
            await LoadNextGameMode();
            OnGameModePrepare?.Invoke();
            await Countdown.Run();
            OnGameModeStart?.Invoke();
            Debug.Log("Start");
        }

        private async Task LoadNextGameMode() {
            int randomGameModeIndex = new Random().Next(0, ActivatedGameModes.Count - 1);
            GameMode.Management.GameMode newGameMode = ActivatedGameModes.ToArray()[randomGameModeIndex];
            int randomMapIndex = new Random().Next(0, newGameMode.Maps.Length - 1);
            Map newMap = newGameMode.Maps[randomMapIndex];

            List<SceneField> scenesToLoad = new List<SceneField>();
            scenesToLoad.Add(newMap.Scene);
            scenesToLoad.AddRange(newGameMode.AdditionalScenes);

            await SceneManager.LoadScenesAsync(scenesToLoad.Select(scene => scene.SceneName).ToArray());
        }

        public bool ValidateWin() {
            return false;
        }
        
    }
    
}
