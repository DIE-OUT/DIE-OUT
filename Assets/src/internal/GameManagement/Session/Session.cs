using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Afired.GameManagement.GameModes;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using Random = System.Random;

namespace Afired.GameManagement.Sessions {
    
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
            if(ValidateSessionWin()) {
                EndSession();
                return;
            }
            await LoadRandomGameMode();
        }

        public async Task LoadRandomGameMode() {
            int randomGameModeIndex = UnityEngine.Random.Range(0, ActivatedGameModes.Count);
            GameMode newGameMode = ActivatedGameModes.ToArray()[randomGameModeIndex];
            int randomMapIndex = UnityEngine.Random.Range(0, newGameMode.Maps.Length);
            Map newMap = newGameMode.Maps[randomMapIndex];
            
            await LoadGameMode(newGameMode, newMap);
        }
        
        public async Task LoadGameMode(GameMode gameMode, Map map) {
            CurrentRound++;
            GameModeInstance = new GameModeInstance(gameMode, map);
            await GameModeInstance.Load();
        }
        
        public bool ValidateSessionWin() {
            //todo: figure out who won
            if(Player.Any(player => player.Score >= WinningScore))
                return true;
            if(CurrentRound >= MaxRounds)
                return true;
            return false;
        }

        private void EndSession() {
            Debug.Log($"Session ended, a player won {Player.OrderByDescending(player => player.Score).FirstOrDefault()?.InputDevices.FirstOrDefault()?.displayName} with a score of {Player.OrderByDescending(player => player.Score).FirstOrDefault()?.Score}");
            //TODO: load into Siegerehrung
        }
        
    }
    
}
