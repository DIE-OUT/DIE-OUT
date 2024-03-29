using System.Collections;
using System.Collections.Generic;
using Afired.GameManagement.Characters;
using UnityEngine;
using UnityEngine.InputSystem;
using Afired.GameManagement.GameModes;
using DieOut.GameModes.Interactions;

namespace DieOut.GameModes.Beerenbusch {
    public class EatBeere : MonoBehaviour, IDeviceReceiver, IAnimatorReceiver {

        private Animator _animator;
        private InputTable _inputTable;

        private Movable _player;
        private PlayerControls _playerControls;
        private Beere _beere;
        
        [SerializeField] private int _eatCount = 5;
        private int _currentEatCount;
        [SerializeField] private float _damage = 2;
        [SerializeField] private float _beereShrinkAmount = 0.05f;

        private void Awake() {
            _inputTable = new InputTable();
            
            _inputTable.CharacterControls.PickUp.performed += OnEat;

            _player = GetComponent<Movable>();
            _playerControls = GetComponent<PlayerControls>();

            _currentEatCount = _eatCount;
        }

        public void ReceiveDevices(InputDevice[] devices) {
            _inputTable.devices = devices;
        }
        
        public void ReceiveAnimator(Animator animator) {
            _animator = animator;
        }
        
        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }

        public void TriggerEating() {
            _beere = GetComponentInChildren<Beere>();
        }

        private IEnumerator MiniDelay() {
            OnDisable();
            yield return new WaitForSeconds(0.2f);
            OnEnable();
        }

        private void OnEat(InputAction.CallbackContext _) {
            
            if (!_playerControls.HasControl) {
                Debug.Log("can`t eat while player controls are disabled");
                return;
            }
            
            StartCoroutine(MiniDelay());
            if (_beere != null) {
                if (_currentEatCount >= 1) {
                    _animator.SetTrigger(AnimatorStringHashes.TriggerEatBerry);
                    Health _health = _player.GetComponent<Health>();
                    _health.TriggerDamage(_damage, DamageType.Poison);
                    _beere.transform.localScale -= new Vector3(_beereShrinkAmount, _beereShrinkAmount, _beereShrinkAmount);
                    _currentEatCount -= 1;

                    if (_health.IsDead) {
                        Destroy(_beere.gameObject);
                    }

                    if (_currentEatCount == 0) {
                        _beere._attachedToPlayer = false;
                        _player.GetComponent<PlayerControls>()._movementSpeed = _beere._normalMovementSpeed;
                        Destroy(_beere.gameObject);
                        _currentEatCount = _eatCount + 1;
                        this.enabled = false;
                    }
                }
            }
        }
    }
}
