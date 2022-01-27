using System.Collections;
using System.Collections.Generic;
using DieOut.GameMode.Interactions;
using UnityEngine;

namespace DieOut.GameMode.Dornenkrone {
    public class Magmaklumpen : MonoBehaviour {

        [SerializeField] private float _damage = 5;
        [SerializeField] private float _damageTickRate = 2;
        private bool _finishedTick = true;
        public bool _attachedToPlayer = false;

        private Movable _movable;

        private void Update() {
            if (_attachedToPlayer == true && _finishedTick == true) {
                GetAttachedPlayer();
                StartCoroutine(ApplyTickDamage());
            }
        }

        private void GetAttachedPlayer() {
            if (_attachedToPlayer == true) {
                _movable = GetComponentInParent<Movable>();
            }
        }
        
        /*public bool AttachedToPlayer() {
            if (transform.parent != null) {
                _movable = GetComponentInParent<Movable>();
                return _attachedToPlayer == true;
            }
            else {
                return _attachedToPlayer == false;
            }
        }*/
        
        private IEnumerator ApplyTickDamage() {
            _finishedTick = false;
            yield return new WaitForSeconds(_damageTickRate);
            _finishedTick = true;
            _movable.TriggerDamage(_damage);
        }
    }
}
