using System.Collections;
using System.Collections.Generic;
using DieOut.GameModes.Dornenkrone;
using UnityEngine;

namespace DieOut.GameModes {
    public class SpeedSpawnpoint : MonoBehaviour {
    
        [SerializeField] private SpeedPickUp _prefabSpeedPickUp;
        private SpeedPickUp _currentSpeedPickUp;

        [SerializeField] private float _respawnTime = 5;
        private bool _inCoroutine = false;

        private void Awake() {
            _currentSpeedPickUp = this.GetComponentInChildren<SpeedPickUp>();
        }

        private void Update() {

            if (_currentSpeedPickUp == null && !_inCoroutine) {
                StartCoroutine(Respawn());
            }
        }

        private IEnumerator Respawn() {
            _inCoroutine = true;
            yield return new WaitForSeconds(_respawnTime);
            SpeedPickUp newStone = Instantiate(_prefabSpeedPickUp, this.transform.position, Quaternion.identity);
            _currentSpeedPickUp = newStone;
            _inCoroutine = false;
        }
    }
}
