using UnityEngine;

namespace DieOut.UI {
    
    public class Screen : MonoBehaviour {

        [SerializeField] private bool _activeAtBeginning;
        
        private void Awake() {
            MoveToOrigin();
            ToggleActive();
        }

        private void MoveToOrigin() {
            transform.localPosition = Vector3.zero;
        }

        private void ToggleActive() {
            gameObject.SetActive(_activeAtBeginning);
        }
        
    }
    
}
