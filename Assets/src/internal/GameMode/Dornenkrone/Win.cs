using System;
using System.Collections;
using System.Collections.Generic;
using DieOut.GameMode.Interactions;
using UnityEngine;
using UnityEngine.UI;

// die ganze Klasse wird probably nochmal anders geschrieben werden
namespace DieOut.GameMode.Dornenkrone {
    public class Win : MonoBehaviour {
        // ! statt [SerializeField] sollten alle Objects in der Szene mit dem type of Movable automatisch gefunden und in die Liste gefügt werden
        [SerializeField] private List<Movable> _players;
        private Movable _winner;

        private bool _win = false;

        private void Update() {
            if (CheckHealth() == true) {
                if (_winner._name == "Max") {
                    transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (_winner._name == "Mia") {
                    transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }

        private bool CheckHealth() {
            foreach (Movable player in _players) 
            {
                if (player._health <= 0) {
                    _winner = player;
                    return _win = true;
                }
            }
            return _win = false;
        }
    }
}
