using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.InputSystem;

namespace DieOut.Sessions {
    
    [Serializable]
    public class Player {
        
        [OdinSerialize] [ReadOnly] public InputDevice[] InputDevices { get; }
        
        
        public Player(InputDevice[] inputDevices) {
            InputDevices = inputDevices;
        }
        
    }
    
}
