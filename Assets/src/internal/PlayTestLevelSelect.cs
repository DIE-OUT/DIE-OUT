using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DieOut {
    
    public class PlayTestLevelSelect : MonoBehaviour {

        [SerializeField] private SceneField[] _playtestScenes;


        private void Awake() {
            #if UNITY_EDITOR
            Application.targetFrameRate = 60;
            #else
            Application.targetFrameRate = 60;
            #endif
        }

        public void LoadLevel(int index) {
            SceneManager.LoadScene(_playtestScenes[index].SceneName);
        }
        
    }
    
}
