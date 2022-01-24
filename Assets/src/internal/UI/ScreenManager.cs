using System.Collections.Generic;
using UnityEngine;

namespace DieOut.UI {
    
    public class ScreenManager : MonoBehaviour {
        
        private List<Screen> _screens = new List<Screen>();
        
        
        private void Awake() {
            _screens.AddRange(GetComponentsInChildren<Screen>());
        }

        public void Activate(Screen screen) {
            for(int i = 0; i < _screens.Count; i++) {
                _screens[i].gameObject.SetActive(false);
            }
            screen.gameObject.SetActive(true);
        }
        
    }
    
}
