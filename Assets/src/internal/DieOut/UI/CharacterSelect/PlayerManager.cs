using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.UI.CharacterSelect {
    
    public class PlayerManager : MonoBehaviour {

        [SerializeField] private List<CharacterSelectCard> _characterSelectCards;
        private InputTable _inputTable;
        public List<InputDevice> PlayerInputDevices { get; private set; }
        
        private void Awake() {
            PlayerInputDevices = new List<InputDevice>();
            _inputTable = new InputTable();
            _inputTable.Navigation.SessionJoin.performed += OnSessionJoinInput;
        }

        private void OnSessionJoinInput(InputAction.CallbackContext ctx) {
            if(PlayerInputDevices.Contains(ctx.control.device)) {
                Debug.LogWarning($"{ctx.control.device.displayName} cant join multiple times");
                return;
            }

            if(PlayerInputDevices.Count >= _characterSelectCards.Count) {
                Debug.LogWarning($"{ctx.control.device.displayName} cant join, cause the session is already full");
                return;
            }

            _characterSelectCards[PlayerInputDevices.Count].AssignDevice(ctx.control.device);
            PlayerInputDevices.Add(ctx.control.device);
            Debug.Log($"{ctx.control.device.displayName} joined the session");
        }

        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }
        
    }
    
}
