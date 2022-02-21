using DieOut.GameModes.Interactions;
using UnityEngine;

namespace DieOut.GameModes.Dornenkrone {
    
    [RequireComponent(typeof(CharacterController))]
    public class PickUpMagmaklumpen : MonoBehaviour {
        
        private Magmaklumpen _magmaklumpen;
        private ItemPosition _itemPosition;
        private PlayerControls _playerControls;

        private void Awake() {
            _itemPosition = GetComponentInChildren<ItemPosition>();
            _playerControls = GetComponent<PlayerControls>();
        }
        
        private void OnTriggerEnter(Collider other) {
            
            if (!_playerControls.HasControl) {
                return;
            }
            
            _magmaklumpen = other.GetComponent<Magmaklumpen>();
            
            if (_magmaklumpen != null && _itemPosition.transform.childCount == 0 && _magmaklumpen._attachedToPlayer == false) {
                //_magmaklumpen._rigidbody.gameObject.SetActive(false);
                _magmaklumpen._attachedToPlayer = true;
                _itemPosition.TriggerPickUpKlumpen(_magmaklumpen);
            }
        }
    }
    
}
