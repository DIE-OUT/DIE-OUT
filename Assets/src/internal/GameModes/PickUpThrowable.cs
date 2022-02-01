using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using DieOut.GameModes.Management;

namespace DieOut.GameModes {
    
    public class PickUpThrowable : MonoBehaviour, IDeviceReceiver {

        [SerializeField] private DeviceTypes _deviceTypes;
        private InputTable _inputTable;
        
        private List<Throwable> _throwables;
        private Throwable _aStone;
        private Throwable _targetStone;
        private ItemPosition _itemPosition;

        private void Awake() {
            
            _inputTable = new InputTable();

            if(_deviceTypes == DeviceTypes.Gamepad)
                _inputTable.devices = new[] { Gamepad.all[0] };
            else if(_deviceTypes == DeviceTypes.Keyboard)
                _inputTable.devices = new InputDevice[] { Keyboard.current, Mouse.current };
            
            _inputTable.CharacterControls.PickUp.performed += OnPickUp;
            _inputTable.CharacterControls.Throw.performed += OnThrow;
            
            _itemPosition = GetComponentInChildren<ItemPosition>();

            _throwables = new List<Throwable>();
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
            _aStone = other.GetComponent<Throwable>();
            
            if (_aStone != null) {
                _throwables.Add(_aStone);
            }
        }

        private void OnTriggerExit(Collider other) {
            _aStone = other.GetComponent<Throwable>();
            
            if (_aStone != null) {
                _throwables.Remove(_aStone);
            }
        }
        
        private void OnPickUp(InputAction.CallbackContext _) {
            
            if (_throwables.Count == 0) {
                return;
            }
            
            _targetStone = _throwables
                .OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).First();
            
            if (_itemPosition.transform.childCount == 0 && _targetStone._attachedToPlayer == false) {
                _targetStone._attachedToPlayer = true;
                _itemPosition.TriggerPickUpThrowable(_targetStone);
                _targetStone.TriggerPickUp();
            }
        }

        private void OnThrow(InputAction.CallbackContext _) {
            if (_targetStone != null) {
                _targetStone._attachedToPlayer = false;
                _targetStone.TriggerThrow();
            }
        }
        
    }
    
}
