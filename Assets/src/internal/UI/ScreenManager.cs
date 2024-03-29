﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Afired.UI {
    
    public class ScreenManager : MonoBehaviour {
        
        private readonly List<Screen> _screens = new List<Screen>();
        
        
        private void Awake() {
            _screens.AddRange(GetComponentsInChildren<Screen>(true));
        }

        public void Activate(Screen screenToBeActivated) {
            _screens.ForEach(screen => screen.gameObject.SetActive(false));
            screenToBeActivated.gameObject.SetActive(true);
        }
        
    }
    
}
