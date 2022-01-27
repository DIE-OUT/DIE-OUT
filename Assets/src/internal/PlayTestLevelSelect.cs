using UnityEngine;
using UnityEngine.SceneManagement;

namespace DieOut {
    
    public class PlayTestLevelSelect : MonoBehaviour {

        [SerializeField] private SceneField[] _playtestScenes;
        
        public void LoadLevel(int index) {
            SceneManager.LoadScene(_playtestScenes[index].SceneName);
        }
        
    }
    
}
