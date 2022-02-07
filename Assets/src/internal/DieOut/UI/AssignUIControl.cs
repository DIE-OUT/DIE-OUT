using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace DieOut.UI {
    
    [RequireComponent(typeof(PlayerInput))]
    public class AssignUIControl : MonoBehaviour {
        
        private PlayerInput _playerInput;
        
        
        private void Awake() {
            _playerInput = GetComponent<PlayerInput>();
        }
        
        private void Start() {
            _playerInput.SwitchCurrentControlScheme(new InputDevice[] { Gamepad.all[0] });
        }
        
    }
    
}
