using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using Afired.GameManagement.Characters;
using Afired.GameManagement.GameModes;

namespace DieOut.GameModes {
    
    public class PickUpThrowable : MonoBehaviour, IDeviceReceiver, IAnimatorReceiver {
        
        private Animator _animator;
        private InputTable _inputTable;
        private List<Throwable> _throwables;
        private Throwable _aThrowable;
        private Throwable _targetThrowable;
        private ItemPosition _itemPosition;

        private void Awake() {
            
            _inputTable = new InputTable();
            _inputTable.CharacterControls.PickUp.performed += OnPickUp;
            _inputTable.CharacterControls.Throw.performed += OnThrow;
            
            _itemPosition = GetComponentInChildren<ItemPosition>();

            _throwables = new List<Throwable>();
        }

        public void SetDevices(InputDevice[] devices) {
            _inputTable.devices = devices;
        }
        
        public void SetAnimator(Animator animator) {
            _animator = animator;
        }
        
        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }

        private void OnTriggerEnter(Collider other) {
            _aThrowable = other.GetComponent<Throwable>();
            
            if (_aThrowable != null) {
                _throwables.Add(_aThrowable);
            }
        }

        private void OnTriggerExit(Collider other) {
            _aThrowable = other.GetComponent<Throwable>();
            
            if (_aThrowable != null) {
                _throwables.Remove(_aThrowable);
            }
        }
        
        private void OnPickUp(InputAction.CallbackContext _) {
            
            if (_throwables.Count == 0) {
                return;
            }
            
            _targetThrowable = _throwables
                .OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).First();
            
            if (_itemPosition.transform.childCount == 0 && _targetThrowable._attachedToPlayer == false) {
                _targetThrowable._attachedToPlayer = true;
                _itemPosition.TriggerPickUpThrowable(_targetThrowable);
                _targetThrowable.TriggerPickUp();
            }
        }

        private void OnThrow(InputAction.CallbackContext _) {
            if (_targetThrowable != null) {
                _animator.SetTrigger(AnimatorStringHashes.TriggerThrow);
                _targetThrowable._attachedToPlayer = false;
                _targetThrowable.TriggerThrow();
            }
        }
        
    }
    
}
