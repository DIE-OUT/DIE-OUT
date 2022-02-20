using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Afired.GameManagement.GameModes;
using System.Linq;
using DieOut.GameModes.Interactions;

namespace DieOut.GameModes.Beerenbusch {
    public class PickUpBeere : MonoBehaviour, IDeviceReceiver {

        private InputTable _inputTable;

        private Movable _player;
        private PlayerControls _playerControls;
        public List<Beere> _beeren;
        private Beere _beere;
        private Beere _targetBeere;

        private void Awake() {
            _inputTable = new InputTable();
            _inputTable.CharacterControls.PickUp.performed += OnPickUp;

            _player = GetComponent<Movable>();
            _playerControls = GetComponent<PlayerControls>();

            _beeren = new List<Beere>();
        }
        
        public void ReceiveDevices(InputDevice[] devices) {
            _inputTable.devices = devices;
        }
        
        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }

        private void OnTriggerEnter(Collider other) {
            _beere = other.GetComponent<Beere>();

            if (_beere != null) {
                _beeren.Add(_beere);
            }
        }
        
        private void OnTriggerExit(Collider other) {
            _beere = other.GetComponent<Beere>();
            
            _beeren.Remove(_beere);
        }

        private void OnPickUp(InputAction.CallbackContext _) {
            
            if (_beeren.Count == 0) {
                return;
            }

            foreach (Beere beere in _beeren) {
                if (beere == null) {
                    _beeren.Remove(beere);
                    return;
                }
            }
            
            if (!_playerControls.HasControl) {
                Debug.Log("can`t pick up while player controls are disabled");
                return;
            }
            
            _targetBeere = _beeren
                .OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).First();

            if (_targetBeere == null) {
                _beeren.Remove(_targetBeere);
                return;
            }
            
            ItemPosition _itemPosition = _player.GetComponentInChildren<ItemPosition>();
            if (_itemPosition.transform.childCount == 0 && _targetBeere._attachedToPlayer == false) {
                _beeren.Remove(_targetBeere);
                _targetBeere._attachedToPlayer = true;
                _itemPosition.TriggerPickUpBeere(_targetBeere);
                _targetBeere.TriggerPickUp(_player);
            }
        }
    }
}
