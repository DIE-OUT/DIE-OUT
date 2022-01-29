using UnityEngine;
using DieOut.SceneManagement;

namespace DieOut.UI.MainMenu {
    
    public class StartingScreen : MonoBehaviour {
        
        public void QuitGame() {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
            #endif
            Application.Quit();
        }
        
    }
    
}
