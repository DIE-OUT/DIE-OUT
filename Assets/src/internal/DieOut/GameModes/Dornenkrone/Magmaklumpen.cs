using System;
using System.Collections;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace DieOut.GameModes.Dornenkrone {
    
    public class Magmaklumpen : MonoBehaviour {

        public Rigidbody _rigidbody;

        public bool _attachedToPlayer = false;
        [SerializeField] private float _damage = 5;
        [SerializeField] private float _damageTickRate = 2;
        private bool _finishedTick = true;
        private Movable _player;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update() {
            if (_attachedToPlayer == true) {
                GetAttachedPlayer();
                GetComponent<Rigidbody>().useGravity = false;
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;

                if (_finishedTick == true) {
                    StartCoroutine(ApplyTickDamage());
                }
            }
            else {
                transform.SetParent(null);
                GetComponent<Rigidbody>().useGravity = true;
                _rigidbody.constraints = RigidbodyConstraints.None;
            }
        }
        
        private void GetAttachedPlayer() {
            _player = GetComponentInParent<Movable>();
        }
        
        private IEnumerator ApplyTickDamage() {
            _finishedTick = false;
            yield return new WaitForSeconds(_damageTickRate);
            _finishedTick = true;
            Health _health = _player.GetComponent<Health>();
            _health.TriggerDamage(_damage, DamageType.Fire);
            
            if (_health.IsDead) {
                this._attachedToPlayer = false;
                transform.SetParent(null);
                GetComponent<Rigidbody>().useGravity = true;
                _rigidbody.constraints = RigidbodyConstraints.None;
                _rigidbody.AddForce(transform.forward * 100);
            }
            
        }
        
    }
    
}
