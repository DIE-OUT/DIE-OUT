using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DieOut.GameModes.Management;
using DieOut.SceneManagement;

namespace DieOut.Sessions {
    
    public delegate void OnGameModePrepare();
    public delegate void OnGameModeStart();
    public delegate void OnGameModeEnd();
    
    public class GameModeInstance {
        
        public event OnGameModePrepare OnGameModePrepare;
        public event OnGameModeStart OnGameModeStart;
        public event OnGameModeEnd OnGameModeEnd;
        public GameMode GameMode { get; }
        public Map Map { get; }
        
        
        public GameModeInstance(GameMode gameMode, Map map) {
            GameMode = gameMode;
            Map = map;
        }

        public async Task Load() {
            await LoadGameModeMap(GameMode, Map);
            OnGameModePrepare?.Invoke();
            await Countdown.Run();
            OnGameModeStart?.Invoke();
        }
        
        private async Task LoadGameModeMap(GameMode gameMode, Map map) {
            List<SceneField> scenesToLoad = new List<SceneField>();
            scenesToLoad.Add(map.Scene);
            scenesToLoad.AddRange(gameMode.AdditionalScenes);
            
            await SceneManager.LoadScenesAsync(scenesToLoad.Select(scene => scene.SceneName).ToArray());
        }
        
        public async void EndGameMode(Player[] players, int[] scores) {
            
            //todo: sort scores to figure out who did best in current game mode

            for(int i = 0; i < players.Length; i++) {
                players[i].AddScore(scores[i]);
            }
            
            OnGameModeEnd?.Invoke();
            //todo: show scoreboard (await scoreboard finish)
            
            Session.Current.GoNext();
        }
        
    }
    
}
