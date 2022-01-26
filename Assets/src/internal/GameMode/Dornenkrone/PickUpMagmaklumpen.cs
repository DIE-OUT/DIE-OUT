using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.GameMode.Dornenkrone {
    
    [RequireComponent(typeof(CharacterController))]
    public class PickUpMagmaklumpen : MonoBehaviour {

        [SerializeField] Magmaklumpen _magmaklumpen;
        
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
            
            _inputTable.CharacterControls.PickUp.performed += OnPickUp;
            
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
                _magmaklumpenInRange = true;
            }
        }
        
        private void OnTriggerExit(Collider other) {
            if (other.GetComponent<Magmaklumpen>() != null) {
                _magmaklumpenInRange = false;
            }
        }

        private void OnPickUp(InputAction.CallbackContext _) {
            // ? Ich versteh nicht warum es so funktioniert, ich würde denken _magmaklumpen.AttachedToPlayer() muss false sein
            // - brauchen wir aber wahrscheinlich hier eh nicht
            if (_magmaklumpenInRange == true /*&& _magmaklumpen.AttachedToPlayer() == true*/ && _itemPosition.transform.childCount == 0) {
                _itemPosition.TriggerPickUpKlumpen(_magmaklumpen);
            }
        }
    }
}
