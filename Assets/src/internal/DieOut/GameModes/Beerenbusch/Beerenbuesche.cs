using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using System.Threading.Tasks;
using Afired.GameManagement.Sessions;
using Random = UnityEngine.Random;

namespace DieOut.GameModes.Beerenbusch {
    public class Beerenbuesche : MonoBehaviour {

        private List<GrowBack> _buesche;
        private GrowBack _buschFirst;
        private List<GrowBack> _buescheWithoutBeeren;

        private bool _isPrepared;
        
        private void Awake() {
            _buesche = GetComponentsInChildren<GrowBack>().ToList();
            _buescheWithoutBeeren = GetComponentsInChildren<GrowBack>().ToList();

            Session.Current.GameModeInstance.OnGameModePrepare += OnGameModePrepare;
        }
        
        private Task OnGameModePrepare() {
            foreach (GrowBack busch in _buesche) {
                if (busch._firstBusch) {
                    _buschFirst = busch;
                }
            }
            _buschFirst.BeerenGrowBack();

            _buescheWithoutBeeren.Remove(_buschFirst);

            _isPrepared = true;
            
            return Task.CompletedTask;
        }

        private void Update() {
            if(!_isPrepared)
                return;
            
            foreach (GrowBack busch in _buesche) {
                busch.BeerenbuschEmpty();
            }
            
            if (_buesche.All(i => i.BeerenbuschEmpty())) {
                TriggerBeerenGrowBack();
            }
        }

        private void TriggerBeerenGrowBack() {
            int random = Random.Range(0, _buescheWithoutBeeren.Count);
            GrowBack chosenBusch = _buescheWithoutBeeren[random];
            chosenBusch.BeerenGrowBack();
            _buescheWithoutBeeren = GetComponentsInChildren<GrowBack>().ToList();
            _buescheWithoutBeeren.Remove(chosenBusch);
        }
    }
}
