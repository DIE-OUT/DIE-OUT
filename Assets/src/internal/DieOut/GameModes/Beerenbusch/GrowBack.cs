using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Mathematics;

namespace DieOut.GameModes.Beerenbusch {
    public class GrowBack : MonoBehaviour {

        private List<Beere> _beeren;

        //[SerializeField] private float _firstGrowTime = 10;
        //[SerializeField] private float _growBackTime = 10;
        private bool _beerenbuschEmpty;
        //private bool _inCoroutine = false;
        [SerializeField] private bool _firstBusch = false;

        private List<BeerenSpawnpoint> _beerenSpawnpoints;
        [SerializeField] private Beere _prefabBeere;
        public bool _empty = false;

        private void Awake() {
            _beerenSpawnpoints = GetComponentsInChildren<BeerenSpawnpoint>().ToList();
            
            _beeren = GetComponentsInChildren<Beere>().ToList();
            if (!_firstBusch) {
                foreach (Beere beere in _beeren) {
                    beere.gameObject.SetActive(false);
                }
            }
        }

        /*private void Start() {
            StartCoroutine(FirstGrow());
        }*/
        
        /*private void Update() {
            if (BeerenbuschEmpty() && !_inCoroutine) {
                _inCoroutine = true;
                StartCoroutine(BeerenGrowBack());
            }
        }*/

        private void Update() {
            if (BeerenbuschEmpty()) {
                _empty = true;
            }
            else {
                _empty = false;
            }
        }

        private bool BeerenbuschEmpty() {
            Beere _anyBeere = GetComponentInChildren<Beere>();
            
            if (_anyBeere == null) {
                return true;
            }
            else {
                return false;
            }
        }

        /*private IEnumerator FirstGrow() {
            yield return new WaitForSeconds(_firstGrowTime);
            foreach (Beere beere in _beeren) {
                beere.gameObject.SetActive(true);
            }
        }*/

        public void BeerenGrowBack() { 
            foreach (BeerenSpawnpoint beerenSpawnpoint in _beerenSpawnpoints) {
                Instantiate(_prefabBeere, beerenSpawnpoint.transform.position, Quaternion.identity);
            }
        }
    }
}