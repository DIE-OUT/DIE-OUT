using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DieOut.GameModes.Management;
using DieOut.SceneManagement;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using Random = System.Random;

namespace DieOut.Sessions {

    public delegate void OnGameModePrepare();
    public delegate void OnGameModeStart();
    public delegate void OnGameModeEnd();
    
    [Serializable]
    public class Session {

        private static Session _current;
        public static Session Current => _current ?? throw new Exception("There is no current session");
        public static bool HasCurrent => _current != null;
        
        public static void SetNew(Session session) {
            _current = session;
        }
        
        public event OnGameModePrepare OnGameModePrepare;
        public event OnGameModeStart OnGameModeStart;
        public event OnGameModeEnd OnGameModeEnd;
        [ReadOnly] [OdinSerialize] public int PlayerCount => Player.Length;
        [OdinSerialize] public Player[] Player { get; }
        [OdinSerialize] public HashSet<GameMode> ActivatedGameModes { get; }
        [OdinSerialize] public int MaxRounds { get; }
        [OdinSerialize] public int WinningScore { get; }
        
        [ReadOnly] [OdinSerialize] public int CurrentRound { get; private set; }
        
        public Session(Player[] player, HashSet<GameMode> activatedGameModes, int maxRounds, int winningScore) {
            Player = player;
            ActivatedGameModes = activatedGameModes;
            MaxRounds = maxRounds;
            WinningScore = winningScore;

            CurrentRound = 0;
        }
        
        public async Task GoNextRandom() {
            if(ValidateWin())
                throw new NotImplementedException("A player won the game");
            
            int randomGameModeIndex = new Random().Next(0, ActivatedGameModes.Count - 1);
            GameMode newGameMode = ActivatedGameModes.ToArray()[randomGameModeIndex];
            int randomMapIndex = new Random().Next(0, newGameMode.Maps.Length - 1);
            Map newMap = newGameMode.Maps[randomMapIndex];
            await GoNext(newGameMode, newMap);
        }
        
        public async Task GoNextSelect(GameMode gameMode, Map map) {
            if(ValidateWin())
                throw new NotImplementedException("A player won the game");
            
            await GoNext(gameMode, map);
        }
        
        private async Task GoNext(GameMode gameMode, Map map) {
            ClearEvents();
            await LoadGameModeMap(gameMode, map);
            OnGameModePrepare?.Invoke();
            await Countdown.Run();
            OnGameModeStart?.Invoke();
        }

        private void ClearEvents() {
            OnGameModePrepare = null;
            OnGameModeStart = null;
            OnGameModeEnd = null;
        }
        
        private async Task LoadGameModeMap(GameMode gameMode, Map map) {
            List<SceneField> scenesToLoad = new List<SceneField>();
            scenesToLoad.Add(map.Scene);
            scenesToLoad.AddRange(gameMode.AdditionalScenes);
            
            await SceneManager.LoadScenesAsync(scenesToLoad.Select(scene => scene.SceneName).ToArray());
        }

        public bool ValidateWin() {
            return false;
        }
        
    }
    
}
