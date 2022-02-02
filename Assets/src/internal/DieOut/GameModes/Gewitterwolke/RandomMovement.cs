using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DieOut.GameModes.Gewitterwolke {
    public class RandomMovement : MonoBehaviour {

        public NavMeshAgent _navMeshAgent;
        //private NavMeshPath _path;
        private Vector3 _target;
        [SerializeField] private float _timeForNewPath = 1;
        private bool _inCoroutine = false;
        //private bool _validPath;
        
        void Start() {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            //_path = new NavMeshPath();
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
            /*_validPath = _navMeshAgent.CalculatePath(_target, _path);

            while (!_validPath) {
                yield return new WaitForSeconds(0.01f);
                GetNewPath();
                _validPath = _navMeshAgent.CalculatePath(_target, _path);
            }*/
            _inCoroutine = false;
        }

        private void GetNewPath() {
            _target = GetNewRandomPosition();
            _navMeshAgent.SetDestination(_target);
        }
    }
}
