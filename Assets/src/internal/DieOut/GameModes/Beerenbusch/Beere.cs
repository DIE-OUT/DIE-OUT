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
        
        private PickUpBeere _pickUpBeere;
        private EatBeere _eatBeere;

        private float _movementSpeed;
        //private float _currentSpeed;
        public float _slowedSpeed;

        public bool _attachedToPlayer = false;

        public void TriggerPickUp(Movable player) {
            _pickUpBeere = player.GetComponent<PickUpBeere>();
            _pickUpBeere._beeren.Remove(this);
            
            _movementSpeed = player.GetComponent<PlayerControls>()._movementSpeed;
            //_currentSpeed = _movementSpeed;
            player.GetComponent<PlayerControls>()._movementSpeed = _movementSpeed / 2;
            //_movementSpeed = _currentSpeed / 2;
            
            _eatBeere = player.GetComponent<EatBeere>();
            _eatBeere.enabled = true;
            _eatBeere.TriggerEating();
        }
    }
}
