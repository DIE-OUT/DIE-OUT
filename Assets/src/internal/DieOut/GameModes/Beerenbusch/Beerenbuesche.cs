using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DieOut.GameModes.Beerenbusch {
    public class Beerenbuesche : MonoBehaviour {

        private List<GrowBack> _buesche;
        private List<GrowBack> _buescheWithoutBeeren;
        
        private void Awake() {
            _buesche = GetComponentsInChildren<GrowBack>().ToList();
            /*_buescheWithoutBeeren = _buesche;

            foreach (GrowBack buschWithoutBeeren in _buescheWithoutBeeren) {
                if (_buescheWithoutBeeren.Any(i => !i.BeerenbuschEmpty())) {
                    _buescheWithoutBeeren.Remove(buschWithoutBeeren);
                }
            }*/
        }

        private void Update() {
            if (_buesche.All(i => i._empty)) {
                    Debug.Log("All empty");
                    TriggerBeerenGrowBack();
            }
        }

        private void TriggerBeerenGrowBack() {
            /*int random = Random.Range(0, _buescheWithoutBeeren.Count);
            GrowBack chosenBusch = _buescheWithoutBeeren[random];
            chosenBusch.BeerenGrowBack();
            _buescheWithoutBeeren = _buesche;
            _buescheWithoutBeeren.Remove(chosenBusch);*/
            
            int random = Random.Range(0, _buesche.Count);
            Debug.Log("random: " + random);
            GrowBack chosenBusch = _buesche[random];
            Debug.Log("chosen busch: " + chosenBusch);
            chosenBusch.BeerenGrowBack();
        }
    }
}
