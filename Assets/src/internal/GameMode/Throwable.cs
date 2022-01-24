using System;
using System.Collections;
using System.Collections.Generic;
using DieOut.GameMode.Interactions;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

namespace DieOut.GameMode {
    public class Throwable : MonoBehaviour {
        // ! Rotation fehlt noch
        
        private InputTable _inputTable;
        [SerializeField] private DeviceTypes _deviceTypes;

        private float _throwForce = 800;
        private bool _inPickUpRange = false;
        
        public GameObject item;
        // ! das tempParent sollte immer der ThrowPoint des Players sein, welcher das throwable item aufhebt
        // ! -> entspricht dem Player, der E drückt und am nähesten am throwable item ist
        public GameObject tempParent;
        public bool _isHolding = false;
        
        private void Awake() {
            _inputTable = new InputTable();

            if(_deviceTypes == DeviceTypes.Gamepad)
                _inputTable.devices = new[] { Gamepad.all[0] };
            else if(_deviceTypes == DeviceTypes.Keyboard)
                _inputTable.devices = new InputDevice[] { Keyboard.current, Mouse.current };
            
            _inputTable.CharacterControls.PickUp.performed += OnPickUp;
            _inputTable.CharacterControls.Throw.performed += OnThrow;
        }

        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }

        void Update() {

            if (_isHolding == true) {
                item.GetComponent<Rigidbody>().velocity = Vector3.zero;
                item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                item.transform.SetParent(tempParent.transform);
                item.transform.position = tempParent.transform.position;
            }
            else {
                item.transform.SetParent(null);
                item.GetComponent<Rigidbody>().useGravity = true;
            }
        }

        private void OnTriggerEnter(Collider other) {

            if (other.gameObject.GetComponent<Tackle>()) {
                _inPickUpRange = true;
            }
        }
        
        private void OnTriggerExit(Collider other) {

            if (other.gameObject.GetComponent<Tackle>()) {
                _inPickUpRange = false;
            }
        }

        void OnPickUp(InputAction.CallbackContext _) {
            if (_inPickUpRange == true) {
                _isHolding = true;
                item.GetComponent<Rigidbody>().useGravity = false;
                //item.GetComponent<Rigidbody>().detectCollisions = true;
            }
        }

        void OnThrow(InputAction.CallbackContext _) {
            if (_isHolding == true) {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * _throwForce);
                _isHolding = false;
            }
        }
    }
}