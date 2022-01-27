using System.Collections;
using System.Collections.Generic;
using DieOut.GameMode.Interactions;
using UnityEngine;

namespace DieOut.GameMode.Dornenkrone {
    public class Magmaklumpen : MonoBehaviour {

        [SerializeField] private float _damage = 5;
        [SerializeField] private float _damageTickRate = 2;
        private bool _finishedTick = true;
        private bool _attachedToPlayer = false;

        private Movable _movable;

        private void Update() {
            // ? geht das performanter? -> weil AttachedToPlayer() ständig überprüft wird
            if (AttachedToPlayer() == false && _finishedTick == true) {
                StartCoroutine(DamageTickRate());
            }
        }
        
        public bool AttachedToPlayer() {
            if (transform.parent != null) {
                _movable = GetComponentInParent<Movable>();
                return _attachedToPlayer == true;
            }
            else {
                return _attachedToPlayer == false;
            }
        }
        
        private IEnumerator DamageTickRate() {
            _finishedTick = false;
            yield return new WaitForSeconds(_damageTickRate);
            _finishedTick = true;
            ApplyDamage();
        }

        private void ApplyDamage() {
            _movable.TriggerDamage(_damage);
        }
    }
}
