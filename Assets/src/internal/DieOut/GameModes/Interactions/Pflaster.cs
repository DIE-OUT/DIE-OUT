using DieOut.GameModes.Interactions;
using UnityEngine;
using DieOut.GameModes.Dornenkrone;

namespace DieOut.GameModes.Interactions {
    
    public class Pflaster : Throwable {
        
        [SerializeField] private float _healAmount = 30;
        
        private void OnCollisionEnter(Collision collision) {
            _enemyPlayer = collision.gameObject.GetComponent<Movable>();

            if (_enemyPlayer != null && !_attachedToPlayer) {
                Health _health = _enemyPlayer.GetComponent<Health>(); 
                _health.Heal(_healAmount);

                _throwable = _enemyPlayer.GetComponentInChildren<Throwable>();

                if (_throwable != null) {
                    _throwable._attachedToPlayer = false;
                }
                PickUpThrowable _pickUpThrowable = _enemyPlayer.GetComponent<PickUpThrowable>();
                _pickUpThrowable._throwables.Remove(this);    
                Destroy(this.gameObject);
            }
        }
    }
}