using UnityEngine;

namespace DieOut.GameModes.Interactions {
    
    [RequireComponent(typeof(Animation))]
    public class CooldownIndicator : MonoBehaviour {
        
        private Animation _cooldownIndicatorActivatedAnimation;
        
        
        private void Awake() {
            _cooldownIndicatorActivatedAnimation = GetComponent<Animation>();
        }
        
        public void Activate() {
            gameObject.SetActive(true);
            _cooldownIndicatorActivatedAnimation.Play();
        }
        
        public void Deactivate() {
            gameObject.gameObject.SetActive(false);
        }
        
    }
    
}
