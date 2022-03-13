using System;
using System.Collections;
using System.Collections.Generic;
using DieOut.GameModes;
using DieOut.GameModes.Beerenbusch;
using DieOut.GameModes.Interactions;
using UnityEngine;
using UnityEngine.UI;

namespace DieOut.GameModes.Beerenbusch {
    public class Beere : MonoBehaviour {
        
        private EatBeere _eatBeere;
        private PlayerControls _playerControls;

        [SerializeField] private float _beereGrowAmount = 0.5f; 
        public float _normalMovementSpeed;
        private float _slowedSpeed;

        public bool _attachedToPlayer = false;

        private void Update() {
           
            if (_attachedToPlayer) {
                _playerControls._movementSpeed = _slowedSpeed;
            }
            else {
                if (_playerControls != null) {
                    _playerControls._movementSpeed = _normalMovementSpeed;
                }
            }
        }

        public void TriggerPickUp(Movable player) {
            transform.localScale += new Vector3(_beereGrowAmount, _beereGrowAmount, _beereGrowAmount);

            _playerControls = player.GetComponent<PlayerControls>(); 
            _normalMovementSpeed = _playerControls._movementSpeed;
            _slowedSpeed = _normalMovementSpeed / 2;
            
            _eatBeere = player.GetComponent<EatBeere>();
            _eatBeere.enabled = true;
            _eatBeere.TriggerEating();
        }
    }
}
