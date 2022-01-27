using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DieOut.GameMode.Dornenkrone;

namespace DieOut.GameMode.Interactions {
    public class Tackleable : MonoBehaviour {
        
        [SerializeField] private float _stunDuration = 2f;
        [SerializeField] private float _immunity = 3f;
        public bool tackleImmunity = false;

        private CharacterController _characterController;
        private Movable _movable;
        private Magmaklumpen _magmaklumpen;
        private Throwable _throwable;
        private Tackle _tackle;


        private void Awake() {
            _movable = GetComponent<Movable>();

            _characterController = GetComponent<CharacterController>();
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

                // Wenn der getackelte Player einen Magmaklumpen trägt, geht dieser auf den Angreifer über
                // Wenn der tackelnde und/oder der getackelte Player ein Throwable Item trägt, lässt er dieses fallen
                if (_characterController.GetComponentInChildren<Magmaklumpen>() != null) {

                    if (tacklingPlayer.GetComponentInChildren<Throwable>() != null) {
                        _throwable = tacklingPlayer.GetComponentInChildren<Throwable>();
                        _throwable._rigidbody.constraints = RigidbodyConstraints.None;
                        _throwable._isHolding = false;
                    }
                    _magmaklumpen = _characterController.GetComponentInChildren<Magmaklumpen>();
                    _magmaklumpen.transform.SetParent(tacklingPlayer.GetComponentInChildren<ItemPosition>().transform);
                    _magmaklumpen.transform.position =
                        tacklingPlayer.GetComponentInChildren<ItemPosition>().transform.position;
                }

                if (_characterController.GetComponentInChildren<Throwable>() != null) {
                    _throwable = _characterController.GetComponentInChildren<Throwable>();
                    _throwable._rigidbody.constraints = RigidbodyConstraints.None;
                    _throwable._isHolding = false;
                }
                
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
