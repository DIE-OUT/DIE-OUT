using System;
using System.Collections.Generic;
using System.Linq;
using Afired.GameManagement.Sessions;
using Afired.Helper;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.UI.CharacterSelect {
    
    public class PlayerManager : MonoBehaviour {

        [SerializeField] private List<CharacterSelectCard> _characterSelectCards;
        private InputTable _inputTable;
        private List<InputDevice> _playerInputDevices;
        
        private void Awake() {
            _playerInputDevices = new List<InputDevice>();
            _inputTable = new InputTable();
            _inputTable.Navigation.SessionJoin.performed += OnSessionJoinInput;
        }

        private void OnSessionJoinInput(InputAction.CallbackContext ctx) {
            if(_playerInputDevices.Contains(ctx.control.device)) {
                Debug.LogWarning($"{ctx.control.device.displayName} cant join multiple times");
                return;
            }

            if(_playerInputDevices.Count >= _characterSelectCards.Count) {
                Debug.LogWarning($"{ctx.control.device.displayName} cant join, cause the session is already full");
                return;
            }

            _characterSelectCards[_playerInputDevices.Count].AssignDevice(ctx.control.device);
            _playerInputDevices.Add(ctx.control.device);
            Debug.Log($"{ctx.control.device.displayName} joined the session");
        }

        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
            Reset();
        }

        private void Reset() {
            _playerInputDevices.Clear();
        }

        public Player[] CreatePlayers() {
            Player[] players = new Player[_playerInputDevices.Count];
            HashSet<PlayerColor> usedColors = new HashSet<PlayerColor>();
            for(int i = 0; i < _playerInputDevices.Count; i++) {
                PlayerColor playerColor = _characterSelectCards[i].PlayerColor;
                if(usedColors.Contains(playerColor))
                    return null;
                players[i] = new Player(new InputDevice[] { _playerInputDevices[i] }, playerColor);
                usedColors.Add(playerColor);
            }
            return players;
        }
        
    }
    
}
