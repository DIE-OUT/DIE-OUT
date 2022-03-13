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
        
        public int PlayerCount => Players.Length;
        public Player[] Players { get; }
        public HashSet<GameMode> ActivatedGameModes { get; }
        public int MaxRounds { get; }
        public int WinningScore { get; }
        public int CurrentRound { get; private set; }
        
        public GameModeInstance GameModeInstance { get; private set; }
        public bool IsRunning => HasStarted && !HasEnded;
        public bool HasStarted { get; private set; }
        public bool HasEnded { get; private set; }
        
        public Session(Player[] players, HashSet<GameMode> activatedGameModes, int maxRounds, int winningScore) {
            Players = players;
            ActivatedGameModes = activatedGameModes;
            MaxRounds = maxRounds;
            WinningScore = winningScore;
            
            CurrentRound = 0;
        }
        
        public static void SetNew(Session session) {
            _current = session;
        }

        public async Task Start() {
            HasStarted = true;
            await LoadRandomGameMode();
        }
        
        public async Task Next() {
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
        
        private bool ValidateSessionWin() {
            if(Players.Any(player => player.Score >= WinningScore))
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
