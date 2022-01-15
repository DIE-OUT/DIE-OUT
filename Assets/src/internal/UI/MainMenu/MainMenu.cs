using UnityEngine;
using DieOut.SceneManagement;

namespace DieOut.UI {
    
    public class MainMenu : MonoBehaviour {
        
        [SerializeField] private SceneField _sampleScene;
        
        public void PlayGame() {
            SceneManager.LoadScenesAsync(_sampleScene.SceneName);
        }
        
        public void QuitGame() {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
            #endif
            Application.Quit();
        }
        
    }
    
}
