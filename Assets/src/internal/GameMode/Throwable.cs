using System;
using System.Collections;
using System.Collections.Generic;
using DieOut.GameMode.Interactions;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

namespace DieOut.GameMode {
    public class Throwable : MonoBehaviour {
        [SerializeField] float _throwForce = 800;
        public bool _isHolding = false;

        // - brauchen wir wahrscheinlich nicht
        private bool _attachedToPlayer = false;

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

        private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.GetComponent<Movable>()) {
                Debug.Log("hit");
            }
        }

        public void TriggerPickUp() {
            // ! hier muss noch irgendwas passieren, damit sich der stone bei collision nicht mehr bewegt
            _isHolding = true;
            GetComponent<Rigidbody>().useGravity = false;
            // - brauchen wir wahrscheinlich nicht
            //item.GetComponent<Rigidbody>().detectCollisions = true;
        }

        public void TriggerThrow() {
            if (_isHolding == true) {
                GetComponent<Rigidbody>()
                    .AddForce(GetComponentInParent<ItemPosition>().transform.forward * _throwForce);
                _isHolding = false;
            }
        }

        // - brauchen wir wahrscheinlich nicht
        public bool AttachedToPlayer() {
            if (transform.parent != null) {
                return _attachedToPlayer == true;
            }
            else {
                return _attachedToPlayer == false;
            }
        }
    }
}