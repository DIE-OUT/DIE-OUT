using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Afired.GameManagement.GameModes;
using UnityEngine;

namespace DieOut.GameModes.Interactions {
    
    [RequireComponent(typeof(Collider))]
    public class Tackle : MonoBehaviour, IDeviceReceiver {

        [SerializeField] private Animator _animator;
        
        [SerializeField] private DeviceTypes _deviceTypes;
        private InputTable _inputTable;
        
        [SerializeField] private List<Tackleable> _tackleablesToIgnore;
        private Movable _player;
        
        [SerializeField] private float _cooldown = 3f;
        private bool _onCooldown;
        [SerializeField] private float _tackleDistance = 50;
        public bool _tackling = false;

        private void Awake() {
            _inputTable = new InputTable();
            
            if(_deviceTypes == DeviceTypes.Gamepad)
                _inputTable.devices = new[] { Gamepad.all[0] };
            else if(_deviceTypes == DeviceTypes.Keyboard)
                _inputTable.devices = new InputDevice[] { Keyboard.current, Mouse.current };
            
            _inputTable.CharacterControls.Tackle.performed += OnTackle;

            _player = GetComponentInParent<Movable>();
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

        private void OnTriggerStay(Collider other) {
            Tackleable enemyPlayer = other.GetComponent<Tackleable>();

            if (_tackling == true && enemyPlayer != null && !_tackleablesToIgnore.Contains(enemyPlayer)) {
                enemyPlayer.TriggerTackle(_player);
                _tackling = false;
            }
        }

        private IEnumerator TackleDuration() {
            _tackling = true;
            _animator.SetBool(AnimatorStringHashes.IsTackling, true);
            yield return new WaitForSeconds(0.25f);
            _tackling = false;
            _animator.SetBool(AnimatorStringHashes.IsTackling, false);
        }
        
        private IEnumerator TackleCooldown() {
            yield return new WaitForSeconds(_cooldown);
            Debug.Log("cooldown finished");
            _onCooldown = false;
        }

        private void OnTackle(InputAction.CallbackContext _) {
            // dont do anything if tackle is on cooldown
            if(_onCooldown) {
                Debug.Log("tackle has cooldown");
                return;
            }

            if (_player != null) {
                StartCoroutine(TackleDuration());
                PlayerControls _playerControls = _player.GetComponent<PlayerControls>();
                _player.AddVelocity(_playerControls._direction * Vector3.forward.normalized * _tackleDistance);
            }

            _onCooldown = true;
            StartCoroutine(TackleCooldown());
        }
        
    }
    
}
