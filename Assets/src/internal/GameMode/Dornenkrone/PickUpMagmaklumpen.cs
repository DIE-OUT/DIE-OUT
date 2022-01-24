using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.GameMode.Dornenkrone {
    
    public class PickUpMagmaklumpen : MonoBehaviour {

        [SerializeField] private CharacterController _characterController;
        [SerializeField] Magmaklumpen _magmaklumpen;
        private InputTable _inputTable;

        private bool _MagmaklumpenInRange = false;

        private void Awake() {
            
            _inputTable = new InputTable();

            _inputTable.CharacterControls.PickUpItem.performed += OnPickUp;
        }

        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.GetComponent<Magmaklumpen>() != null) {
                _MagmaklumpenInRange = true;
                Debug.Log("in Magmaklumpen range");
            }
        }
        
        private void OnTriggerExit(Collider other) {
            if (other.GetComponent<Magmaklumpen>() != null) {
                _MagmaklumpenInRange = false;
                Debug.Log("not in Magmaklumpen range");
            }
        }

        private void OnPickUp(InputAction.CallbackContext _) {
            if (_MagmaklumpenInRange == true) {
                _magmaklumpen.transform.parent = _characterController.transform;
            }
        }
    }
}
