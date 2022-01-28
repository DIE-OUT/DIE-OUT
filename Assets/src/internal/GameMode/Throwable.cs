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

        private PlayerControls _playerControls;
        private Movable _player;
        private Movable _enemyPlayer;
        private Magmaklumpen _magmaklumpen;
        private Throwable _throwable;
        private ItemPosition _itemPosition;
        public Rigidbody _rigidbody;
        
        [SerializeField] float _throwForce = 800;
        [SerializeField] private float _stunDuration = 2;
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
                _playerControls = _enemyPlayer.GetComponent<PlayerControls>();
                StartCoroutine(Stun());
                _magmaklumpen = _enemyPlayer.GetComponentInChildren<Magmaklumpen>();

                if (_magmaklumpen != null && _attachedToPlayer == false) {
                    _itemPosition = _player.GetComponentInChildren<ItemPosition>();
                    _magmaklumpen.transform.parent = _itemPosition.transform;
                    _magmaklumpen.transform.position = _itemPosition.transform.position;
                }

                _throwable = _enemyPlayer.GetComponentInChildren<Throwable>();

                if (_throwable != null && _attachedToPlayer == false) {
                    _throwable._attachedToPlayer = false;
                }
            }
        }

        private IEnumerator Stun() {
            _playerControls.HasControl = false;
            yield return new WaitForSeconds(_stunDuration);
            _playerControls.HasControl = true;
        }

        public void TriggerPickUp() {
            _player = GetComponentInParent<Movable>();
        }

        public void TriggerThrow() {
            GetComponent<Rigidbody>().AddForce(GetComponentInParent<ItemPosition>().transform.forward * _throwForce);
        }
    }
}