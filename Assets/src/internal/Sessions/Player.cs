using System;
using UnityEngine.InputSystem;

namespace DieOut.Sessions {
    
    [Serializable]
    public class Player {
        
        public InputDevice[] InputDevices { get; }
        
        
        public Player(InputDevice[] inputDevices) {
            InputDevices = inputDevices;
        }
        
    }
    
}
