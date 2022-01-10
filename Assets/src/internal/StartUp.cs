using System;
using UnityEngine;

namespace DieOut {
    
    public class StartUp : MonoBehaviour {
        
        private void Start() {
            GameManager.GameState = GameState.MainMenu;
        }
        
    }
    
}
