using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.GameMode {
    public class PickUpThrowable : MonoBehaviour {
        // ! Daraus muss eine Liste werden
        [SerializeField] Throwable _throwable;
        
        [SerializeField] private DeviceTypes _deviceTypes;
        private InputTable _inputTable;

        private ItemPosition _itemPosition;
        
        private bool _throwableInRange = false;

        private void Awake() {
            
            _inputTable = new InputTable();

            if(_deviceTypes == DeviceTypes.Gamepad)
                _inputTable.devices = new[] { Gamepad.all[0] };
            else if(_deviceTypes == DeviceTypes.Keyboard)
                _inputTable.devices = new InputDevice[] { Keyboard.current, Mouse.current };
            
            // Variante bei der automatisch aufgehoben wird
            _inputTable.CharacterControls.PickUp.performed += OnPickUp;
            _inputTable.CharacterControls.Throw.performed += OnThrow;
            
            _itemPosition = GetComponentInChildren<ItemPosition>();
        }

        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }

        private void OnTriggerEnter(Collider other) {
            // ! hier muss dann was mit der Liste passieren
            if (other.GetComponent<Throwable>() != null) {
                _throwableInRange = true;
                // Variante bei der automatisch aufgehoben wird
                /*if (_throwableInRange == true && _itemPosition.transform.childCount == 0 && _throwable.AttachedToPlayer() == true) { //&& _throwable.AttachedToPlayer() == true
                    _itemPosition.TriggerPickUpThrowable(_throwable);
                    _throwable.TriggerPickUp();
                }*/
                //
            }
        }

        private void OnTriggerExit(Collider other) {
            // ! hier muss dann was mit der Liste passieren
            if (other.GetComponent<Throwable>() != null) {
                _throwableInRange = false;
            }
        }

        // Variante bei der automatisch aufgehoben wird
        private void OnPickUp(InputAction.CallbackContext _) {
            // ? Ich versteh nicht warum es so funktioniert, ich würde denken _magmaklumpen.AttachedToPlayer() muss false sein
            // - brauchen wir aber möglicherweise eh nicht
            if (_throwableInRange == true && _itemPosition.transform.childCount == 0) { //&& _throwable.AttachedToPlayer() == true
                _itemPosition.TriggerPickUpThrowable(_throwable);
                _throwable.TriggerPickUp();
            }
        }

        private void OnThrow(InputAction.CallbackContext _) {
            _throwable.TriggerThrow();
        }
    }
}
