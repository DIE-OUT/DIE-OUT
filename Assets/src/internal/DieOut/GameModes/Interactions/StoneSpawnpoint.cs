using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DieOut.GameModes.Interactions {
    public class StoneSpawnpoint : MonoBehaviour {

        [SerializeField] private Stone _prefabStone;
        private Stone _currentStone;

        [SerializeField] private float _respawnTime = 5;
        private bool _inCoroutine = false;

        private void Awake() {
            _currentStone = this.GetComponentInChildren<Stone>();
        }

        private void Update() {

            if (_currentStone == null && !_inCoroutine) {
                StartCoroutine(Respawn());
            }
        }

        private IEnumerator Respawn() {
            _inCoroutine = true;
            yield return new WaitForSeconds(_respawnTime);
            Stone newStone = Instantiate(_prefabStone, this.transform.position, Quaternion.identity);
            _currentStone = newStone;
            _inCoroutine = false;
        }
    }
}
