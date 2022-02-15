using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Afired.GameManagement.GameModes;
using DieOut.GameModes.Interactions;

namespace DieOut.GameModes.Beerenbusch {
    public class EatBeere : MonoBehaviour, IDeviceReceiver {

        [SerializeField] private Animator _animator;
        
        private InputTable _inputTable;

        private Movable _player;
        private Beere _beere;

        [SerializeField] private int _eatCount = 5;
        private int _currentEatCount;
        [SerializeField] private float _damage = 2;

        private void Awake() {
            _inputTable = new InputTable();
            
            _inputTable.CharacterControls.PickUp.performed += OnEat;

            _player = GetComponent<Movable>();

            _currentEatCount = _eatCount;
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

        public void TriggerEating() {
            _beere = GetComponentInChildren<Beere>();
        }

        private IEnumerator MiniDelay() {
            OnDisable();
            yield return new WaitForSeconds(0.2f);
            OnEnable();
        }

        private void OnEat(InputAction.CallbackContext _) {
            StartCoroutine(MiniDelay());
            if (_beere != null) {
                if (_currentEatCount >= 1) {
                    _animator.SetTrigger(AnimatorStringHashes.TriggerEatBerry);
                    _player.GetComponent<Health>().TriggerDamage(_damage, DamageType.Poison);
                    _beere.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
                    _currentEatCount -= 1;

                    if (_currentEatCount == 0) {
                        _beere._attachedToPlayer = false;
                        _beere._slowedSpeed = _player.GetComponent<PlayerControls>()._movementSpeed;
                        _player.GetComponent<PlayerControls>()._movementSpeed = _beere._slowedSpeed * 2;
                        Destroy(_beere.gameObject);
                        _currentEatCount = _eatCount;
                        this.enabled = false;
                    }
                }
            }
        }
    }
}
