using System;
using Afired.GameManagement.Characters;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.InputSystem;

namespace Afired.GameManagement.Sessions {

    public delegate void OnScoreChanged();
    
    [Serializable]
    public class Player {
        
        [OdinSerialize] [ReadOnly] public InputDevice[] InputDevices { get; }
        [OdinSerialize] [ReadOnly] public Character Character { get; }
        [OdinSerialize] [ReadOnly] public string DisplayName => Character.DisplayName;
        public int Score { get; private set; }
        public event OnScoreChanged OnScoreChanged;
        
        
        public Player(InputDevice[] inputDevices, Character character) {
            InputDevices = inputDevices;
            Character = character;
        }
        
        public void AddScore(int scoreToAdd) {
            if(scoreToAdd < 0)
                throw new ArgumentOutOfRangeException();
            Score += scoreToAdd;
            OnScoreChanged?.Invoke();
        }
        
    }
    
}
