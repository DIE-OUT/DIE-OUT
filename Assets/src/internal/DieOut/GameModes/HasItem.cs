using Afired.GameManagement.Characters;
using DieOut.GameModes.Dornenkrone;
using UnityEngine;

namespace DieOut.GameModes {
    
    public class HasItem : MonoBehaviour, IAnimatorReceiver {

        private Animator _animator;
        
        public void ReceiveAnimator(Animator animator) {
            _animator = animator;
        }
        
        private void Update() {
            HasItemAttached();
        }

        private void HasItemAttached() {
            
            if(GetComponentInChildren<Magmaklumpen>() != null) {
                _animator.SetInteger(AnimatorStringHashes.ItemState, (int) ItemState.Large);
            } else if(GetComponentInChildren<Throwable>() != null) {
                _animator.SetInteger(AnimatorStringHashes.ItemState, (int) ItemState.Normal);
            } else if(GetComponentInChildren<Throwable>() != null) {
                _animator.SetInteger(AnimatorStringHashes.ItemState, (int) ItemState.Normal);
            } else {
                _animator.SetInteger(AnimatorStringHashes.ItemState, (int) ItemState.None);
            }
            
        }
        
    }
    
}
