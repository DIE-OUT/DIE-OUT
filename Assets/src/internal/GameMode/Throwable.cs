using System;
using System.Collections;
using System.Collections.Generic;
using DieOut.GameMode.Interactions;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

namespace DieOut.GameMode {
    public class Throwable : MonoBehaviour {
        // ! Rotation fehlt noch

        private float _throwForce = 800;
        public bool _isHolding = false;
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
        
        public void TriggerPickUp() {
            _isHolding = true;
            GetComponent<Rigidbody>().useGravity = false;
            //item.GetComponent<Rigidbody>().detectCollisions = true;
        }

        public void TriggerThrow() {
            if (_isHolding == true) {
                GetComponent<Rigidbody>().AddForce(GetComponentInParent<ItemPosition>().transform.forward * _throwForce);
                _isHolding = false;
            }
        }

        public bool AttachedToPlayer() {
            if (transform.parent != null) {
                Debug.Log("has parent");
                return _attachedToPlayer == true;
            }
            else {
                Debug.Log("no parent");
                return _attachedToPlayer == false;
            }
        }
    }
}