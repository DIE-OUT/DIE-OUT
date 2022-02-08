using System;
using System.Collections;
using System.Collections.Generic;
using DieOut.GameModes.Interactions;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace DieOut.GameModes.Gewitterwolke {
    public class RandomMovement : MonoBehaviour {

        public NavMeshAgent _navMeshAgent;
        private Vector3 _target;
        
        [SerializeField] private float _timeForNewPath = 1;
        private bool _inCoroutine = false;
        [SerializeField] [MinMaxSlider(0, 20)] private Vector2 _speedRange = new Vector2(1, 5);
        
        void Awake() {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update() {
            if (!_inCoroutine) {
                StartCoroutine(DelayUntilNewPath());
            }
        }

        Vector3 GetNewRandomPosition() {
            float x = Random.Range(-20, 20);
            float z = Random.Range(-20, 20);

            Vector3 pos = new Vector3(x, 0, z);
            return pos;
        }

        IEnumerator DelayUntilNewPath() {
            _inCoroutine = true;
            yield return new WaitForSeconds(_timeForNewPath);
            GetNewPath();
        }

        private void GetNewPath() {
            _target = GetNewRandomPosition();
            if (_navMeshAgent.speed != 0) {
                _navMeshAgent.speed = Random.Range(_speedRange.x, _speedRange.y);
            }
            _navMeshAgent.SetDestination(_target);
            _inCoroutine = false;
        }
    }
}
