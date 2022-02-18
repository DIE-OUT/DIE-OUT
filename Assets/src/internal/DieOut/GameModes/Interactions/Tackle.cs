using System;
using System.Collections;
using System.Collections.Generic;
using Afired.GameManagement.Characters;
using UnityEngine.InputSystem;
using Afired.GameManagement.GameModes;
using DieOut.GameModes.Dornenkrone;
using UnityEngine;

namespace DieOut.GameModes.Interactions {
    
    [RequireComponent(typeof(Collider))]
    public class Tackle : MonoBehaviour, IDeviceReceiver, IAnimatorReceiver {

        private Animator _animator;
        private InputTable _inputTable;
        
        [SerializeField] private List<Tackleable> _tackleablesToIgnore;
        private Movable _player;
        private PlayerControls _playerControls;
        private ItemPosition _itemPosition;
        private CooldownIndicator _cooldownIndicator;
        private Throwable _throwable;
        private Magmaklumpen _magmaklumpen;

        [SerializeField] private float _cooldown = 3f;
        private bool _onCooldown;
        [SerializeField] private float _tackleDistance = 50;
        public bool _tackling = false;

        private void Awake() {
            _inputTable = new InputTable();
            _inputTable.CharacterControls.Tackle.performed += OnTackle;

            _player = GetComponentInParent<Movable>();
            _playerControls = GetComponentInParent<PlayerControls>();
            _itemPosition = _player.GetComponentInChildren<ItemPosition>();
            _cooldownIndicator = _player.GetComponentInChildren<CooldownIndicator>();
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
            if (_cooldownIndicator != null) {
                _cooldownIndicator.gameObject.SetActive(true);
            }
        }

        private void OnTackle(InputAction.CallbackContext _) {
            // dont do anything if tackle is on cooldown
            if (_onCooldown) {
                Debug.Log("tackle has cooldown");
                return;
            }

            // dont do anything if tackling player is stunned
            if (!_playerControls.HasControl) {
                Debug.Log("can`t tackle while player controls are disabled");
                return;
            }

            // dont do anything if tackling player has an item (excluding beeren)
            if (_itemPosition.transform.childCount > 0) {
                _magmaklumpen = _itemPosition.GetComponentInChildren<Magmaklumpen>();
                _throwable = _itemPosition.GetComponentInChildren<Throwable>();

                if (_magmaklumpen != null || _throwable != null) {
                    Debug.Log("can`t tackle with item");
                    return;
                }
            }

            if (_player != null) {
                StartCoroutine(TackleDuration());
                PlayerControls _playerControls = _player.GetComponent<PlayerControls>();
                _player.AddVelocity(_playerControls._direction * Vector3.forward.normalized * _tackleDistance);
            }

            _onCooldown = true;
            if (_cooldownIndicator != null) {
                _cooldownIndicator.gameObject.SetActive(false);
            }
            StartCoroutine(TackleCooldown());
        }
        
    }
    
}
