using UnityEngine;

namespace DieOut.GameModes {
    
    public static class AnimatorStringHashes {
        public static readonly int IsTackling = Animator.StringToHash("isTackling");
        public static readonly int WalkingSpeed = Animator.StringToHash("walkingSpeed");
        public static readonly int TriggerJump = Animator.StringToHash("triggerJump");
        public static readonly int IsGrounded = Animator.StringToHash("isGrounded");
        public static readonly int HasItem = Animator.StringToHash("hasItem");
    }
    
}
