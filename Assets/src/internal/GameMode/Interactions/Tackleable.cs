using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DieOut.GameMode.Interactions {
    public class Tackleable : MonoBehaviour {
        
        [SerializeField] private float _stunDuration = 2f;
        [SerializeField] private float _immunity = 3f;
        private Movable _movable;
        public bool tackleImmunity = false;


        private void Awake() {
            _movable = GetComponent<Movable>();
        }

        private IEnumerator TackleImmunity() {
            yield return new WaitForSeconds(_stunDuration + _immunity);
            Debug.Log("tackle immunity OFF");
            tackleImmunity = false;
        }
        
        private IEnumerator TackleStunDuration() {
            yield return new WaitForSeconds(_stunDuration);
            //TODO: reenable character controls
        }

        public void TriggerTackle(Movable tacklingPlayer) {
            if (_movable != null) {
                //TODO: disable character controls
                // ! Sollte erst passieren, wenn der Angreifer mit seinem Ziel collided
                _movable.AddVelocity((_movable.transform.position - tacklingPlayer.transform.position).normalized / 5);
            }

            tackleImmunity = true;
            Debug.Log("tackle immunity ON");
            StartCoroutine(TackleImmunity());
            StartCoroutine(TackleStunDuration());
        }
    }
}
