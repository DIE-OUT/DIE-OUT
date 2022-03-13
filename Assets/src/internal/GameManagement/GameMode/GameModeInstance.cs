using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Afired.GameManagement.Sessions;
using Afired.Helper;
using Afired.SceneManagement;
using UnityEngine;

namespace Afired.GameManagement.GameModes {
    
    public class GameModeInstance {
        
        public TaskQueue OnGameModePrepare = new TaskQueue();
        public TaskQueue OnGameModeStart = new TaskQueue();
        public TaskQueue OnGameModeEnd = new TaskQueue();
        public GameMode GameMode { get; }
        public Map Map { get; }
        private bool _hasEnded;
        
        
        public GameModeInstance(GameMode gameMode, Map map) {
            GameMode = gameMode;
            Map = map;
        }

        public async Task Load() {
            await LoadGameModeMap(GameMode, Map);
            await OnGameModePrepare.InvokeAsynchronously();
            await OnGameModeStart.InvokeAsynchronously();
        }
        
        private static async Task LoadGameModeMap(GameMode gameMode, Map map) {
            List<SceneRef> scenesToLoad = new List<SceneRef>();
            scenesToLoad.Add(map.Scene);
            scenesToLoad.AddRange(gameMode.AdditionalScenes);
            await SceneManager.LoadScenesAsync(scenesToLoad.Select(scene => scene.SceneName).ToArray());
        }
        
        public async void EndGameMode() {
            if(_hasEnded) {
                Debug.Log($"{GameMode.DisplayName} has already been ended but it has been tried to end it a second time");
                return;
            }
            _hasEnded = true;
            await OnGameModeEnd.InvokeAsynchronously();
            
            #pragma warning disable CS4014
            Session.Current.Next();
            #pragma warning restore CS4014
        }
        
    }
    
}
