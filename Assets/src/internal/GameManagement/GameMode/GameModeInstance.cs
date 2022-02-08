using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Afired.GameManagement.Sessions;
using Afired.Helper;
using Afired.SceneManagement;

namespace Afired.GameManagement.GameModes {
    
    public delegate void OnGameModeStart();
    
    public class GameModeInstance {
        
        public TaskQueue OnGameModePrepare = new TaskQueue();
        public event OnGameModeStart OnGameModeStart;
        public TaskQueue OnGameModeEnd = new TaskQueue();
        public GameMode GameMode { get; }
        public Map Map { get; }
        
        
        public GameModeInstance(GameMode gameMode, Map map) {
            GameMode = gameMode;
            Map = map;
        }

        public async Task Load() {
            await LoadGameModeMap(GameMode, Map);
            await OnGameModePrepare.InvokeAsynchronously();
            OnGameModeStart?.Invoke();
        }
        
        private async Task LoadGameModeMap(GameMode gameMode, Map map) {
            List<SceneField> scenesToLoad = new List<SceneField>();
            scenesToLoad.Add(map.Scene);
            scenesToLoad.AddRange(gameMode.AdditionalScenes);
            
            await SceneManager.LoadScenesAsync(scenesToLoad.Select(scene => scene.SceneName).ToArray());
        }
        
        public async void EndGameMode() {
            
            await OnGameModeEnd.InvokeAsynchronously();
            
            #pragma warning disable CS4014
            Session.Current.GoNext();
            #pragma warning restore CS4014
        }
        
    }
    
}
