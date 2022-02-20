using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Afired.Helper;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityAsync;

namespace Afired.SceneManagement {
        
    /// <summary>
    /// singleton wrapper class for asynchronous scene loading with loading screen and task callbacks
    /// </summary>
    public class SceneManager : MonoBehaviour {
        
        public static TaskQueue OnEndAsyncLevelLoading = new TaskQueue();
        public static float LoadingProgress { get; private set; }
        
        [SerializeField] private SceneField _loadingScreenScene;
        
        private static SingletonInstance<SceneManager> _instance;
        
        private void Awake() {
            _instance.Init(this);
        }
        
        /// <summary>
        /// unloads current scenes and asynchronously loads new scenes with loading screen 
        /// </summary>
        /// <param name="scenes"></param>
        public static async Task LoadScenesAsync(params string[] scenes) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
            
            scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_instance.Get()._loadingScreenScene.SceneName, LoadSceneMode.Single));
            for(int i = 0; i < scenes.Length; i++) {
                scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scenes[i], LoadSceneMode.Additive));
            }
            
            while(scenesLoading.Any(scene => !scene.isDone)) {
                LoadingProgress = scenesLoading.Sum(operation => operation.progress) / scenesLoading.Count;
                await Await.NextUpdate();
            }
            
            await OnEndAsyncLevelLoading.InvokeAsynchronously();
            
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(_instance.Get()._loadingScreenScene.SceneName, UnloadSceneOptions.None);
        }
        
    }

}