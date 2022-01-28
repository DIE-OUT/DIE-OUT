using System.Collections;
using System.Collections.Generic;
using DieOut.GameMode.Interactions;
using UnityEngine;

namespace DieOut.GameMode.Dornenkrone {
    public class Magmaklumpen : MonoBehaviour {

        private Movable _player;
        
        [SerializeField] private float _damage = 5;
        [SerializeField] private float _damageTickRate = 2;
        private bool _finishedTick = true;
        public bool _attachedToPlayer = false;

        private void Update() {
            if (_attachedToPlayer == true && _finishedTick == true) {
                GetAttachedPlayer();
                StartCoroutine(ApplyTickDamage());
            }
        }

        private void GetAttachedPlayer() {
            _player = GetComponentInParent<Movable>();
        }

        private IEnumerator ApplyTickDamage() {
            _finishedTick = false;
            yield return new WaitForSeconds(_damageTickRate);
            _finishedTick = true;
            _player.TriggerDamage(_damage);
        }
    }
}
