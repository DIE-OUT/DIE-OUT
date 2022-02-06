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
        public List<Beere> _beeren;
        private Beere _beere;
        private Beere _targetBeere;

        private void Awake() {
            _inputTable = new InputTable();
            _inputTable.CharacterControls.PickUp.performed += OnPickUp;

            _player = GetComponent<Movable>();

            _beeren = new List<Beere>();
        }
        
        public void SetDevices(InputDevice[] devices) {
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

            if (_beere != null) {
                _beeren.Remove(_beere);
            }
        }

        private void OnPickUp(InputAction.CallbackContext _) {
            if (_beeren.Count == 0) {
                return;
            }
            
            _targetBeere = _beeren
                .OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).First();
            
            _targetBeere.TriggerPickUp(_player);
        }
    }
}
