using System.Collections;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace DieOut.GameModes.Dornenkrone {
    
    public class Magmaklumpen : MonoBehaviour {
        
        public bool _attachedToPlayer = false;
        [SerializeField] private float _damage = 5;
        [SerializeField] private float _damageTickRate = 2;
        private bool _finishedTick = true;
        private Movable _player;
        
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
