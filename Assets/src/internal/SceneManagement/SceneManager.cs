﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Afired.Helper;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityAsync;

namespace Afired.SceneManagement {

    public delegate void StartAsyncLevelLoading();
    public delegate void EndAsyncLevelLoading();

    public class SceneManager : MonoBehaviour {
        
        public static event StartAsyncLevelLoading StartAsyncLevelLoading;
        public static event EndAsyncLevelLoading EndAsyncLevelLoading;
        public static float LoadingProgress { get; private set; }
        [SerializeField] private SceneField _loadingScreenScene;
        private static SingletonInstance<SceneManager> _instance;

        private void Awake() {
            _instance.Init(this);
        }
        
        public static async Task LoadScenesAsync(string[] scenes, float minLoadingTime = 0f) {
            StartAsyncLevelLoading?.Invoke();
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
            
            while(stopwatch.Elapsed.TotalSeconds < minLoadingTime) {
                await Await.NextUpdate();
            }
            
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(_instance.Get()._loadingScreenScene.SceneName, UnloadSceneOptions.None);
            EndAsyncLevelLoading?.Invoke();
        }
        
        public static int sceneCount => UnityEngine.SceneManagement.SceneManager.sceneCount;
        public static int sceneCountInBuildSettings => UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        public static Scene GetSceneByName(string name) => UnityEngine.SceneManagement.SceneManager.GetSceneByName(name);
        public static Scene GetSceneAt(int index) => UnityEngine.SceneManagement.SceneManager.GetSceneAt(index);
        public static Scene GetActiveScene() => UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        public static Scene GetSceneByBuildIndex(int index) => UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(index);
        public static Scene GetSceneByPath(string scenePath) => UnityEngine.SceneManagement.SceneManager.GetSceneByPath(scenePath);

    }

}