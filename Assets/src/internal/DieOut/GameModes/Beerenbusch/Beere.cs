using System.Collections;
using System.Collections.Generic;
using DieOut.GameModes;
using DieOut.GameModes.Beerenbusch;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace DieOut.GameModes.Beerenbusch {
    public class Beere : MonoBehaviour {

        private PickUpBeere _pickUpBeere;
        private float _movementSpeed;
        //private float _currentSpeed;

        public bool _attachedToPlayer;
    
        public void TriggerPickUp(Movable player) {
            _movementSpeed = player.GetComponent<PlayerControls>()._movementSpeed;
            //_currentSpeed = _movementSpeed;
            player.GetComponent<PlayerControls>()._movementSpeed = _movementSpeed / 2;
            //_movementSpeed = _currentSpeed / 2;

            player.GetComponent<Health>().TriggerDamage(5);
            //this.gameObject.SetActive(false);

            _pickUpBeere = player.GetComponent<PickUpBeere>();
            _pickUpBeere._beeren.Remove(this);
        }
    }
}
