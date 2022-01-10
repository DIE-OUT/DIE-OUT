using System;
using DieOut.SceneManagement;
using UnityEditor;
using UnityEngine;

namespace DieOut {
    
    public class StartUp : MonoBehaviour {
        
        [SerializeField] private SceneField _mainMenuScene;
        
        private void Start() {
            GameManager.GameState = GameState.MainMenu;
            SceneManager.LoadScenesAsync(_mainMenuScene.SceneName);
        }
        
    }
    
}
