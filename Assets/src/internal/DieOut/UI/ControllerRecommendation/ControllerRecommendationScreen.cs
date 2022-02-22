using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DieOut.UI.ControllerRecommendation {
    
    public class ControllerRecommendationScreen : MonoBehaviour {

        [SerializeField] private float _timeToWaitBeforeLoadingMainMenu = 5f;
        [SerializeField] private SceneField _mainMenuScene;
        
        private void Start() {
            StartCoroutine(LoadMainMenuWithDelay(_timeToWaitBeforeLoadingMainMenu));
        }

        private IEnumerator LoadMainMenuWithDelay(float delay) {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(_mainMenuScene.SceneName);
        }
        
    }
    
}
