using System.Collections;
using Afired.SceneManagement;
using UnityEngine;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

namespace DieOut.UI.ControllerRecommendation {
    
    public class ControllerRecommendationScreen : MonoBehaviour {

        [SerializeField] private float _timeToWaitBeforeLoadingMainMenu = 5f;
        [SerializeField] private SceneRef _mainMenuScene;
        
        private void Start() {
            StartCoroutine(LoadMainMenuWithDelay(_timeToWaitBeforeLoadingMainMenu));
        }

        private IEnumerator LoadMainMenuWithDelay(float delay) {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(_mainMenuScene.SceneName);
        }
        
    }
    
}
