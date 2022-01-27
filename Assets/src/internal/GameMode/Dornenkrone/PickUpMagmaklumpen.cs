using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.GameMode.Dornenkrone {
    
    [RequireComponent(typeof(CharacterController))]
    public class PickUpMagmaklumpen : MonoBehaviour {

        Magmaklumpen _magmaklumpen;
        
        [SerializeField] private DeviceTypes _deviceTypes;
        private InputTable _inputTable;

        private ItemPosition _itemPosition;
        
        private bool _magmaklumpenInRange = false;

        private void Awake() {
            
            _inputTable = new InputTable();
            
            if(_deviceTypes == DeviceTypes.Gamepad)
                _inputTable.devices = new[] { Gamepad.all[0] };
            else if(_deviceTypes == DeviceTypes.Keyboard)
                _inputTable.devices = new InputDevice[] { Keyboard.current, Mouse.current };
            
            // Variante bei der automatisch aufgehoben wird
            //_inputTable.CharacterControls.PickUp.performed += OnPickUp;
            
            _itemPosition = GetComponentInChildren<ItemPosition>();
        }

        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }
        
        private void OnTriggerEnter(Collider other) {
            if (other.GetComponent<Magmaklumpen>() != null) {
                _magmaklumpen = other.GetComponent<Magmaklumpen>();
                _magmaklumpenInRange = true;
                // Variante bei der automatisch aufgehoben wird
                if (_itemPosition.transform.childCount == 0 && _magmaklumpen._attachedToPlayer == false) { // && _magmaklumpen.AttachedToPlayer() == true
                    _itemPosition.TriggerPickUpKlumpen(_magmaklumpen);
                    _magmaklumpen._attachedToPlayer = true;
                }
                //
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.GetComponent<Magmaklumpen>() != null) {
                _magmaklumpenInRange = false;
            }
        }

        /* Variante bei der automatisch aufgehoben wird
        private void OnPickUp(InputAction.CallbackContext _) {
            // ? Ich versteh nicht warum es so funktioniert, ich würde denken _magmaklumpen.AttachedToPlayer() muss false sein
            // - brauchen wir aber wahrscheinlich hier eh nicht
            if (_magmaklumpenInRange == true && _itemPosition.transform.childCount == 0) { // && _magmaklumpen.AttachedToPlayer() == true
                _itemPosition.TriggerPickUpKlumpen(_magmaklumpen);
            }
        }*/
    }
}
