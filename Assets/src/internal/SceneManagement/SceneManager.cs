using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DieOut.SceneManagement {

    public delegate void StartAsyncLevelLoading();
    public delegate void EndAsyncLevelLoading();

    public class SceneManager : MonoBehaviour {
        
        public static event StartAsyncLevelLoading StartAsyncLevelLoading;
        public static event EndAsyncLevelLoading EndAsyncLevelLoading;
        public static float LoadingProgress { get; private set; }
        [SerializeField] private SceneAsset _loadingScreenScene;
        private List<AsyncOperation> _scenesLoading = new List<AsyncOperation>();
        private static SceneManager v_instance;
        private static SceneManager _instance {
            get {
                if(v_instance == null)
                    Debug.LogWarning("there is no SceneManager instance initialized");
                return v_instance;
            }
        }


        private void Awake() {
            if(v_instance != null) {
                Debug.LogWarning("only one SceneManager can be active at once");
                return;
            }
            v_instance = this;
        }
        
        public static void LoadScenesAsync(params SceneAsset[] scenes) {
            StartAsyncLevelLoading?.Invoke();

            _instance._scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_instance._loadingScreenScene.name, LoadSceneMode.Single));
            for(int i = 0; i < scenes.Length; i++) {
                _instance._scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scenes[i].name, LoadSceneMode.Additive));
            }

            _instance.StartCoroutine(_instance.GetSceneLoadProgress());
        }
        
        private IEnumerator GetSceneLoadProgress() {
            for(int i = 0; i < _scenesLoading.Count; i++) {
                while(!_scenesLoading[i].isDone) {
                    LoadingProgress = _scenesLoading.Sum(operation => operation.progress) / _scenesLoading.Count;
                    yield return null;
                }
            }
            EndAsyncLevelLoading?.Invoke();
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(_loadingScreenScene.name, UnloadSceneOptions.None);
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