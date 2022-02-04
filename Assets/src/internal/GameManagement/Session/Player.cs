﻿using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.InputSystem;

namespace Afired.GameManagement.Sessions {

    public delegate void OnScoreChanged();
    
    [Serializable]
    public class Player {
        
        [OdinSerialize] [ReadOnly] public InputDevice[] InputDevices { get; }
        public int Score { get; private set; }
        public event OnScoreChanged OnScoreChanged;


        public Player(InputDevice[] inputDevices) {
            InputDevices = inputDevices;
        }

        public void AddScore(int scoreToAdd) {
            if(scoreToAdd < 0)
                throw new ArgumentOutOfRangeException();
            Score += scoreToAdd;
            OnScoreChanged?.Invoke();
        }
        
    }
    
}
