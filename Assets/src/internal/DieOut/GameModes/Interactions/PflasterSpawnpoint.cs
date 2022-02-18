using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DieOut.GameModes.Interactions {
    public class PflasterSpawnpoint : MonoBehaviour {

        [SerializeField] private Pflaster _prefabPflaster;
        private Pflaster _currentPflaster;

        [SerializeField] private float _respawnTime = 5;
        private bool _inCoroutine = false;

        private void Awake() {
            _currentPflaster = this.GetComponentInChildren<Pflaster>();
        }

        private void Update() {

            if (_currentPflaster == null && !_inCoroutine) {
                StartCoroutine(Respawn());
            }
        }

        private IEnumerator Respawn() {
            _inCoroutine = true;
            yield return new WaitForSeconds(_respawnTime);
            Pflaster newPflaster = Instantiate(_prefabPflaster, this.transform.position, Quaternion.identity);
            _currentPflaster = newPflaster;
            _inCoroutine = false;
        }
    }
}
