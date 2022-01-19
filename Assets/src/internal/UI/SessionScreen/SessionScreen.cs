using System;
using System.Collections.Generic;
using DieOut.Sessions;
using DieOut.UI.Elements;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace DieOut.UI.SessionScreen {
    
    public class SessionScreen : MonoBehaviour {
        
        [SerializeField] private SessionBuilder _sessionBuilder;
        
        [Title("References")]
        [SerializeField] private Switcher _winningScoreSwitcher;
        
        private void Awake() {
            _sessionBuilder = new SessionBuilder();

            GenericSwitchControl<int> winningScoreSwitchControl = new GenericSwitchControl<int>(new List<int>() { 1, 2, 3, 4, 5 });
            winningScoreSwitchControl.OnValueChanged += (value, valueAsText) => _sessionBuilder.WinningScore = (int) value;
            _winningScoreSwitcher.SetSwitchControl(winningScoreSwitchControl);
        }
        
    }
    
}
