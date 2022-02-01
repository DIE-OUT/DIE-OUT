using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DieOut.GameModes.Management;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Random = System.Random;

namespace Afired.SessionManagement {
    
    [Serializable]
    public class Session {

        private static Session _current;
        public static Session Current => _current ?? throw new Exception("There is no current session");
        public static bool HasCurrent => _current != null;
        
        public static void SetNew(Session session) {
            _current = session;
        }

        public GameModeInstance GameModeInstance;
            
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
        
        public async Task GoNext() {
            if(ValidateSessionWin())
                throw new NotImplementedException("A player won the game");

            await LoadRandomGameMode();
        }

        public async Task LoadRandomGameMode() {
            int randomGameModeIndex = new Random().Next(0, ActivatedGameModes.Count - 1);
            GameMode newGameMode = ActivatedGameModes.ToArray()[randomGameModeIndex];
            int randomMapIndex = new Random().Next(0, newGameMode.Maps.Length - 1);
            Map newMap = newGameMode.Maps[randomMapIndex];
            
            await LoadGameMode(newGameMode, newMap);
        }
        
        public async Task LoadGameMode(GameMode gameMode, Map map) {
            GameModeInstance = new GameModeInstance(gameMode, map);
            await GameModeInstance.Load();
        }
        
        public bool ValidateSessionWin() {
            //todo: figure out who won
            return Player.Any(player => player.Score >= WinningScore);
        }
        
    }
    
}
