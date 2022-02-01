using System;
using DieOut.SceneManagement;
using UnityEditor;
using UnityEngine;

namespace DieOut {
    
    public class StartUp : MonoBehaviour {
        
        [SerializeField] private SceneField _mainMenuScene;
        public static bool HasBeenLoaded { get; private set; }
        
        private void Start() {
            HasBeenLoaded = true;
            SceneManager.LoadScenesAsync(_mainMenuScene.SceneName);
        }
        
    }
    
}
