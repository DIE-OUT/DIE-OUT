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

        [SerializeField] private float _beereGrowAmount = 0.5f; 
        private float _movementSpeed;
        //private float _currentSpeed;
        public float _slowedSpeed;

        public bool _attachedToPlayer = false;

        public void TriggerPickUp(Movable player) {
            
            transform.localScale += new Vector3(_beereGrowAmount, _beereGrowAmount, _beereGrowAmount);
            
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
