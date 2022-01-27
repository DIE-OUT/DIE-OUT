using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DieOut.GameMode.Interactions;
using UnityEngine;
using UnityEngine.UI;

// die ganze Klasse wird probably nochmal anders geschrieben werden
namespace DieOut.GameMode.Dornenkrone {
    public class Win : MonoBehaviour {
        // ! statt [SerializeField] sollten alle Objects in der Szene mit dem type of Movable automatisch gefunden und in die Liste gefügt werden
        [SerializeField] private List<Movable> _players;
        
        private void Update() {
            if (CheckHealth()) {
                transform.GetChild(2).gameObject.SetActive(true);
            }
        }

        private bool CheckHealth() {
            return _players.Any(player => player._health <= 0);
        }
    }
}
