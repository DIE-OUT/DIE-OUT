using Afired.SceneManagement;
using UnityEngine;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

namespace DieOut {
    
    public class StartUp : MonoBehaviour {

        [SerializeField] private bool _skipControllerRecommendationsInEditor = true;
        [SerializeField] private SceneRef _mainMenuScene;
        [SerializeField] private SceneRef _controllerRecommendationScene;
        public static bool HasBeenLoaded { get; private set; }
        
        private void Start() {
            HasBeenLoaded = true;
            
            #if UNITY_EDITOR
            SceneManager.LoadScene(_skipControllerRecommendationsInEditor ? _mainMenuScene.SceneName : _controllerRecommendationScene.SceneName);
            #else
            Application.targetFrameRate = -1;
            SceneManager.LoadScene(_controllerRecommendationScene.SceneName);
            #endif
        }
        
    }
    
}
