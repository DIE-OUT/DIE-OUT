using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.InputSystem;

namespace Afired.SessionManagement {
    
    [Serializable]
    public class Player {
        
        [OdinSerialize] [ReadOnly] public InputDevice[] InputDevices { get; }
        public int Score { get; private set; }
        
        
        public Player(InputDevice[] inputDevices) {
            InputDevices = inputDevices;
        }

        public void AddScore(int scoreToAdd) {
            if(scoreToAdd < 0)
                throw new ArgumentOutOfRangeException();
            Score += scoreToAdd;
        }
        
    }
    
}
