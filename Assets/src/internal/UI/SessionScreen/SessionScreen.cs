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

            ISwitchControl winningScoreSwitchControl = new RangedIntSwitchControl(new RangedIntSwitchControl.Range<int>(1, 10));
            winningScoreSwitchControl.OnValueChanged += (value, valueAsText) => _sessionBuilder.WinningScore = (int) value;
            _winningScoreSwitcher.AssignSwitchControl(winningScoreSwitchControl);
            
            _winningScoreSwitcher.AssignSwitchControl( new EnumSwitchControl<KeyCode>());
        }
        
    }
    
}
