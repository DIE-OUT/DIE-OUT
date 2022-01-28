using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.GameMode.Dornenkrone {
    
    [RequireComponent(typeof(CharacterController))]
    public class PickUpMagmaklumpen : MonoBehaviour {

        private Magmaklumpen _magmaklumpen;
        private ItemPosition _itemPosition;

        private void Awake() {
            _itemPosition = GetComponentInChildren<ItemPosition>();
        }

        private void OnTriggerEnter(Collider other) {
            _magmaklumpen = other.GetComponent<Magmaklumpen>();
            
            if (_magmaklumpen != null && _itemPosition.transform.childCount == 0 && _magmaklumpen._attachedToPlayer == false) {
                _magmaklumpen._attachedToPlayer = true;
                _itemPosition.TriggerPickUpKlumpen(_magmaklumpen);
            }
        }
    }
}
