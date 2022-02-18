using UnityEngine;

namespace DieOut.GameModes {
    
    public static class AnimatorStringHashes {
        public static readonly int IsTackling = Animator.StringToHash("IsTackling");
        public static readonly int WalkingSpeed = Animator.StringToHash("WalkingSpeed");
        public static readonly int TriggerJump = Animator.StringToHash("TriggerJump");
        public static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
        public static readonly int TriggerFireDeath = Animator.StringToHash("TriggerFireDeath");
        public static readonly int TriggerLightningDeath = Animator.StringToHash("TriggerLightningDeath");
        public static readonly int TriggerPoisonDeath = Animator.StringToHash("TriggerPoisonDeath");
        public static readonly int TriggerEatBerry = Animator.StringToHash("TriggerEatBerry");
        public static readonly int TriggerThrow = Animator.StringToHash("TriggerThrow");
        public static readonly int ItemState = Animator.StringToHash("ItemState");
    }
    
}
