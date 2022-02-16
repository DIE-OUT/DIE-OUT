using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Mathematics;

namespace DieOut.GameModes.Beerenbusch {
    public class GrowBack : MonoBehaviour {
        
        private List<BeerenSpawnpoint> _beerenSpawnpoints;
        [SerializeField] private Beere _prefabBeere;
        
        [SerializeField] public bool _firstBusch = false;

        private void Awake() {
            _beerenSpawnpoints = GetComponentsInChildren<BeerenSpawnpoint>().ToList(); 
        }

        public bool BeerenbuschEmpty() {
            Beere _anyBeere = GetComponentInChildren<Beere>();
            
            if (_anyBeere == null) {
                return true;
            }
            else {
                return false;
            }
        }

        public void BeerenGrowBack() { 
            foreach (BeerenSpawnpoint beerenSpawnpoint in _beerenSpawnpoints) {
                Beere beere = Instantiate(_prefabBeere, beerenSpawnpoint.transform.position, Quaternion.identity);
                beere.transform.parent = beerenSpawnpoint.transform;
            }
        }

    }
}