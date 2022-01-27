using System;
using System.Collections;
using System.Collections.Generic;
using DieOut.GameMode.Interactions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.GameMode.Dornenkrone {
    public class PickUpSpeed : MonoBehaviour {
    
        [SerializeField] private DeviceTypes _deviceTypes;
        private InputTable _inputTable;

        private bool _inPickUpRange = false;

        private void Awake() {
            _inputTable = new InputTable();
            
            if(_deviceTypes == DeviceTypes.Gamepad)
                _inputTable.devices = new[] { Gamepad.all[0] };
            else if(_deviceTypes == DeviceTypes.Keyboard)
                _inputTable.devices = new InputDevice[] { Keyboard.current, Mouse.current };
            
            _inputTable.CharacterControls.PickUp.started += OnPickUp;
        }

        private void OnTriggerEnter(Collider other) {
            if (other.GetComponent<SpeedPickUp>() != null) {
                _inPickUpRange = true;
            }
        }
        
        private void OnTriggerExit(Collider other) {
            if (other.GetComponent<SpeedPickUp>() != null) {
                _inPickUpRange = false;
            }
        }
        
        // ? Why does this not work? :(
        private void OnPickUp(InputAction.CallbackContext _) {
            Debug.Log("E pressed");
            if (_inPickUpRange == true) {
                Debug.Log("got the speed pick up");
                GetComponent<Movable>().AddVelocity(Vector3.forward);
                Debug.Log("Speeded");
            }
        }
    }
}
