using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DieOut.GameModes.Interactions {
    public class RespawnStone : MonoBehaviour {

        private List<StoneSpawnpoint> _stoneSpawnpoints;
        private List<Stone> _stones;
        [SerializeField] private Stone _prefabStone;

        private void Awake() {
            _stoneSpawnpoints = GetComponentsInChildren<StoneSpawnpoint>().ToList();
            Debug.Log(_stoneSpawnpoints.Count);
            _stones = GetComponentsInChildren<Stone>().ToList();
            Debug.Log(_stones.Count);
        }

        /*private void Update() {
            Stone destroyedStone = _stones.Find(i => i == null);

            if (destroyedStone != null) {
                _stones.Remove(destroyedStone);

                StoneSpawnpoint emptySpawn = _stoneSpawnpoints.Find(j => !j.GetComponentInChildren<Stone>());
                Stone newStone = Instantiate(_prefabStone, emptySpawn.transform.position, Quaternion.identity);
                newStone.transform.parent = emptySpawn.transform;
            }
        }*/
    }
}
