﻿using DieOut.Sessions;
using DieOut.UI.Elements;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.UI.SessionScreen {
    
    public class SessionScreen : MonoBehaviour {
        
        [SerializeField] private SessionBuilder _sessionBuilder;
        
        [Title("References")]
        [SerializeField] private Switcher _winningScoreSwitcher;
        
        private void Awake() {
            _sessionBuilder = new SessionBuilder();

            ISwitchControl winningScoreSwitchControl = new RangedIntSwitchControl(new RangedIntSwitchControl.Range<int>(1, 10));
            winningScoreSwitchControl.OnValueChanged += (value, valueAsText) => _sessionBuilder.WinningScore = (int) value;
            _winningScoreSwitcher.AssignControl(winningScoreSwitchControl);
            
            _winningScoreSwitcher.AssignControl( new EnumSwitchControl<KeyCode>());
        }
        
    }
    
}
