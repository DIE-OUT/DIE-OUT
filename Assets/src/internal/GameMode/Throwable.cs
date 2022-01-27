using System;
using System.Collections;
using System.Collections.Generic;
using DieOut.GameMode.Interactions;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using DieOut.GameMode.Dornenkrone;
using UnityEngine.UI;

namespace DieOut.GameMode {
    public class Throwable : MonoBehaviour {
        [SerializeField] float _throwForce = 800;
        public bool _isHolding = false;

        private Movable _player;
        private Movable _enemyPlayer;
        private Magmaklumpen _magmaklumpen;
        public Rigidbody _rigidbody;
        
        // - brauchen wir wahrscheinlich nicht
        public bool _attachedToPlayer = false;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        void Update() {
            if (_isHolding == true) {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
            else {
                transform.SetParent(null);
                GetComponent<Rigidbody>().useGravity = true;
            }
        }

        // Wenn man einen Enemy mit Throwable hitted, geht dessen Magmaklumpen auf den Werfer über
        private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.GetComponent<Movable>() != null) {
                _enemyPlayer = collision.gameObject.GetComponent<Movable>();
                // _enemyPlayer.Stun();
                if (_enemyPlayer.GetComponentInChildren<Magmaklumpen>() != null && _attachedToPlayer == false) {
                    _magmaklumpen = _enemyPlayer.GetComponentInChildren<Magmaklumpen>();
                    _magmaklumpen.transform.parent = _player.GetComponentInChildren<ItemPosition>().transform;
                    _magmaklumpen.transform.position =
                        _player.GetComponentInChildren<ItemPosition>().transform.position;
                }
            }
        }

        public void TriggerPickUp() {
            // ! hier muss noch irgendwas passieren, damit sich der stone bei collision nicht mehr bewegt
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _isHolding = true;
            GetComponent<Rigidbody>().useGravity = false;
            _player = GetComponentInParent<Movable>();
            // - brauchen wir wahrscheinlich nicht
            //item.GetComponent<Rigidbody>().detectCollisions = true;
        }

        public void TriggerThrow() {
            if (_isHolding == true) {
                _rigidbody.constraints = RigidbodyConstraints.None;
                GetComponent<Rigidbody>()
                    .AddForce(GetComponentInParent<ItemPosition>().transform.forward * _throwForce);
                _isHolding = false;
            }
        }

        // - brauchen wir wahrscheinlich nicht
        /*public bool AttachedToPlayer() {
            if (transform.parent != null) {
                return _attachedToPlayer == true;
            }
            else {
                return _attachedToPlayer == false;
            }
        }*/
    }
}