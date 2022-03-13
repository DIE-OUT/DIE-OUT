using DieOut.GameModes.Interactions;
using UnityEngine;

namespace DieOut.GameModes {
    
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Throwable : MonoBehaviour {
        
        protected Movable _player;
        protected Movable _enemyPlayer;
        protected ItemPosition _itemPosition;
        protected Throwable _throwable;
        protected Rigidbody _rigidbody;

        [SerializeField] float _throwForce = 800;
        [SerializeField] private float _throwAngle = 20;
        public bool _attachedToPlayer = false;

        void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }                                         
        
        void Update() {
            if (_attachedToPlayer == true) {
                _rigidbody.useGravity = false;
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                
                Health _health = _player.GetComponent<Health>();

                if (_health.IsDead) {
                    _attachedToPlayer = false;
                    transform.SetParent(null);
                    _rigidbody.useGravity = true;
                    _rigidbody.constraints = RigidbodyConstraints.None;
                    _rigidbody.AddForce(transform.forward * 100);
                }
            }
            else {
                transform.SetParent(null);
                _rigidbody.useGravity = true;
                _rigidbody.constraints = RigidbodyConstraints.None;
            }
        }

        public void TriggerPickUp() {
            _player = GetComponentInParent<Movable>();
        }

        public void TriggerThrow(Vector3 startPosition, Vector3 direction) {
            _rigidbody.MovePosition(startPosition);
            _rigidbody.AddForce(direction * _throwForce);
        }
    }
    
}
