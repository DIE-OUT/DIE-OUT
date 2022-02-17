using System.Collections;
using DieOut.GameModes.Interactions;
using UnityEngine;
using DieOut.GameModes.Dornenkrone;

namespace DieOut.GameModes {
    public abstract class Throwable : MonoBehaviour {
        
        protected Movable _player;
        protected Movable _enemyPlayer;
        protected ItemPosition _itemPosition;
        protected Throwable _throwable;
        protected Rigidbody _rigidbody;

        [SerializeField] float _throwForce = 800;
        [SerializeField] private float _throwAngle = 20;
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

        public void TriggerPickUp() {
            _player = GetComponentInParent<Movable>();
        }

        public void TriggerThrow() {
            GetComponent<Rigidbody>().GetComponentInParent<ItemPosition>().transform.Rotate(_throwAngle, 0, 0, Space.Self);
            GetComponent<Rigidbody>().AddForce(GetComponentInParent<ItemPosition>().transform.forward * _throwForce);
        }
    }
}
