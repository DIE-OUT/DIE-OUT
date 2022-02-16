using System.Collections;
using DieOut.GameModes.Interactions;
using UnityEngine;
using DieOut.GameModes.Dornenkrone;

namespace DieOut.GameModes {
    public class Throwable : MonoBehaviour {
        
        private Movable _player;
        private Movable _enemyPlayer;
        private Tackleable _tackleable;
        private Magmaklumpen _magmaklumpen;
        private Throwable _throwable;
        private ItemPosition _itemPosition;
        public Rigidbody _rigidbody;
        
        [SerializeField] float _throwForce = 800;
        public bool _attachedToPlayer = false;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        void Update() {
            if (_attachedToPlayer == true) {
                GetComponent<Rigidbody>().useGravity = false;
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
            else {
                transform.SetParent(null);
                GetComponent<Rigidbody>().useGravity = true;
                _rigidbody.constraints = RigidbodyConstraints.None;
            }
        }

        // Wenn man einen Enemy mit Throwable hitted, geht dessen Magmaklumpen auf den Werfer über bzw lässt dieser sein Throwable Item fallen
        private void OnCollisionEnter(Collision collision) {
            _enemyPlayer = collision.gameObject.GetComponent<Movable>();

            if (_enemyPlayer != null) {
                _tackleable = _enemyPlayer.GetComponent<Tackleable>();
                
                if (!_tackleable._ccImmunity && !_attachedToPlayer) {
                    _tackleable.TriggerCC_Immunity();
                    _tackleable.TriggerThrowableStun();
                    _magmaklumpen = _enemyPlayer.GetComponentInChildren<Magmaklumpen>();

                    if (_magmaklumpen != null) {
                        _itemPosition = _player.GetComponentInChildren<ItemPosition>();
                        _magmaklumpen.transform.parent = _itemPosition.transform;
                        _magmaklumpen.transform.position = _itemPosition.transform.position;
                    }

                    _throwable = _enemyPlayer.GetComponentInChildren<Throwable>();

                    if (_throwable != null) {
                        _throwable._attachedToPlayer = false;
                    }
                    
                    Destroy(this.gameObject);
                }
            }
        }

        public void TriggerPickUp() {
            _player = GetComponentInParent<Movable>();
        }

        public void TriggerThrow() {
            GetComponent<Rigidbody>().AddForce(GetComponentInParent<ItemPosition>().transform.forward * _throwForce);
        }
        
    }
    
}
