using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.GameModes.Interactions {
    public class StoneSpawner : MonoBehaviour {

        [AssetsOnly] [SerializeField] private GameObject _prefabStone;
        private GameObject _stoneGameObject;

        [SerializeField] private float _respawnTime = 5;
        private bool _inCoroutine = false;

        private void Awake() {
            StartCoroutine(Respawn());
        }

        private void Update() {

            if (_stoneGameObject == null && !_inCoroutine) {
                StartCoroutine(Respawn());
            }
        }

        private IEnumerator Respawn() {
            _inCoroutine = true;
            yield return new WaitForSeconds(_respawnTime);
            GameObject newStone = Instantiate(_prefabStone, this.transform.position, Quaternion.identity);
            _stoneGameObject = newStone;
            _inCoroutine = false;
        }

        private void OnDrawGizmosSelected() {
            Gizmos.DrawSphere(transform.position, 0.2f);
        }
    }
}
