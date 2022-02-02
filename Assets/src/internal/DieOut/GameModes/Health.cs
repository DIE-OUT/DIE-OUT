using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DieOut.GameModes {
    public class Health : MonoBehaviour {
        [SerializeField] private float _health = 100;
        
        public void TriggerDamage(float damage) {
            _health -= damage;
        }
    }
}
