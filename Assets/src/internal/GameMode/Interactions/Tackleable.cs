using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DieOut.GameMode.Interactions {
    public class Tackleable : MonoBehaviour {
        
        [SerializeField] private float _stunDuration = 2f;
        [SerializeField] private float _immunity = 3f;
        [SerializeField] private Movable _movable;
        public bool tackleImmunity = false;
        
        
        private IEnumerator TackleImmunity() {
            yield return new WaitForSeconds(_stunDuration + _immunity);
            Debug.Log("tackle immunity OFF");
            tackleImmunity = false;
        }
        
        private IEnumerator TackleStunDuration() {
            yield return new WaitForSeconds(_stunDuration);
            //TODO: reenable character controls
        }
        
        public void TriggerTackle() {
            if(_movable != null)
                _movable.AddVelocity(new Vector3(0, 0.1f, 0));
            //TODO: disable character controls
            
            tackleImmunity = true;
            Debug.Log("tackle immunity ON");
            StartCoroutine(TackleImmunity());
            StartCoroutine(TackleStunDuration());
        }
    }
}
