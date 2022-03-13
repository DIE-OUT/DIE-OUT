using UnityEngine;

namespace Afired.GameManagement.Characters {
    
    /// <summary>
    /// interface for custom injection of animator component
    /// </summary>
    public interface IAnimatorReceiver {
        
        public void ReceiveAnimator(Animator animator);
        
    }
    
}
