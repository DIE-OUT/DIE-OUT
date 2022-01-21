using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DieOut.GameMode.Interactions {
    public class Tackleable : MonoBehaviour {
        [SerializeField] private float _stunDuration = 2f;
        [SerializeField] private float _immunity = 3f;
        
        public bool tackleImmunity = false;

        private IEnumerator TackleImmunity() {
            yield return new WaitForSeconds(_stunDuration + _immunity);
            Debug.Log("tackle immunity OFF");
            tackleImmunity = false;
        }
        
        private IEnumerator TackleStunDuration() {
            yield return new WaitForSeconds(_stunDuration);
            GetComponent<PlayerController>()._movementSpeed = 5;
            GetComponent<PlayerController>()._jumpForce = 15;
        }
        
        public void TriggerTackle() {
            GetComponent<PlayerController>()._movementSpeed = 0;
            GetComponent<PlayerController>()._jumpForce = 0;
            
            tackleImmunity = true;
            Debug.Log("tackle immunity ON");
            StartCoroutine(TackleImmunity());
            StartCoroutine(TackleStunDuration());
        }
    }
}
