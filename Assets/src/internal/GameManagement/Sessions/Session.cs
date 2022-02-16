using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Afired.GameManagement.GameModes;
using Afired.SceneManagement;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Afired.GameManagement.Sessions {
    
    [Serializable]
    public class Session {

        private static Session _current;
        public static Session Current => _current ?? throw new Exception("There is no current session");
        public static bool HasCurrent => _current != null;
        
        public static void SetNew(Session session) {
            _current = session;
        }
        
        [ReadOnly] [OdinSerialize] public int PlayerCount => Player.Length;
        [OdinSerialize] public Player[] Player { get; }
        [OdinSerialize] public HashSet<GameMode> ActivatedGameModes { get; }
        [OdinSerialize] public int MaxRounds { get; }
        [OdinSerialize] public int WinningScore { get; }
        [ReadOnly] [OdinSerialize] public int CurrentRound { get; private set; }
        
        public GameModeInstance GameModeInstance;
        public bool IsRunning => HasStarted && !HasEnded;
        public bool HasStarted { get; private set; }
        public bool HasEnded { get; private set; }
        
        public Session(Player[] player, HashSet<GameMode> activatedGameModes, int maxRounds, int winningScore) {
            Player = player;
            ActivatedGameModes = activatedGameModes;
            MaxRounds = maxRounds;
            WinningScore = winningScore;
            
            CurrentRound = 0;
        }

        public async Task Start() {
            HasStarted = true;
            await LoadRandomGameMode();
        }
        
        public async Task GoNext() {
            HasStarted = true;
            if(ValidateSessionWin()) {
                EndSession();
                return;
            }
            await LoadRandomGameMode();
        }

        public async Task LoadRandomGameMode() {
            HasStarted = true;
            int randomGameModeIndex = UnityEngine.Random.Range(0, ActivatedGameModes.Count);
            GameMode newGameMode = ActivatedGameModes.ToArray()[randomGameModeIndex];
            int randomMapIndex = UnityEngine.Random.Range(0, newGameMode.Maps.Length);
            Map newMap = newGameMode.Maps[randomMapIndex];
            
            await LoadGameMode(newGameMode, newMap);
        }
        
        public async Task LoadGameMode(GameMode gameMode, Map map) {
            HasStarted = true;
            CurrentRound++;
            GameModeInstance = new GameModeInstance(gameMode, map);
            await GameModeInstance.Load();
        }
        
        public bool ValidateSessionWin() {
            if(Player.Any(player => player.Score >= WinningScore))
                return true;
            if(CurrentRound >= MaxRounds)
                return true;
            return false;
        }

        private void EndSession() {
            if(!IsRunning)
                throw new Exception("Session cant be ended if it is not running");
            HasEnded = true;
            SceneManager.LoadScenesAsync(SceneRegister.AwardCeremony.SceneName);
        }
        
    }
    
}
