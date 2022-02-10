using Afired.SceneManagement;
using UnityEngine;

namespace DieOut {
    
    public class StartUp : MonoBehaviour {
        
        [SerializeField] private SceneField _mainMenuScene;
        public static bool HasBeenLoaded { get; private set; }
        
        private void Start() {
            HasBeenLoaded = true;
            SceneManager.LoadScenesAsync(new string[] { _mainMenuScene.SceneName });
            #if UNITY_EDITOR
            #else
            Application.targetFrameRate = -1;
            #endif
        }
        
    }
    
}
