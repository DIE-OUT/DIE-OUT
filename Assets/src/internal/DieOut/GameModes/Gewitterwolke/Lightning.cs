using System;
using System.Collections;
using System.Collections.Generic;
using DieOut.GameModes.Dornenkrone;
using DieOut.GameModes.Interactions;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DieOut.GameModes.Gewitterwolke {
    public class Lightning : MonoBehaviour {
        
        private RandomMovement _gewitterwolke;
        private List<Movable> _playersUnderGewitterwolke;
        
        private float _timer = 0;
        [SerializeField] [MinMaxSlider(0, 60)] private Vector2 _delayRange = new Vector2(10, 30);
        
        public GameObject _lastHit;
        public Vector3 _collision = Vector3.zero;
        private Vector3 _height = new Vector3(0, 1, 0);
        public LayerMask _layer;
        [SerializeField] private GameObject _prefab;

        void Awake() {
            _gewitterwolke = GetComponent<RandomMovement>();
            _playersUnderGewitterwolke = new List<Movable>();
        }

        private void Start() {
            _timer = Random.Range(_delayRange.x, _delayRange.y);
        }

        void Update() {
            _timer -= Time.deltaTime;
            
            if (_timer <= 0) {
                StartCoroutine(LightningStrike());
                _timer = Random.Range(_delayRange.x, _delayRange.y);
            }
        }

        private void OnTriggerEnter(Collider other) {
            Movable _player = other.gameObject.GetComponent<Movable>();

            if (_player != null) {
                _playersUnderGewitterwolke.Add(_player);
            }
        }
        
        private void OnTriggerExit(Collider other) {
            Movable _player = other.gameObject.GetComponent<Movable>();

            if (_player != null) {
                _playersUnderGewitterwolke.Remove(_player);
            }
        }

        private void Raycast() {
            var ray = new Ray(this.transform.position - _height, -this.transform.up);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)) {
                _lastHit = hit.transform.gameObject;
                _collision = hit.point;
            }
        }

        IEnumerator LightningStrike() {
            float currentSpeed = _gewitterwolke._navMeshAgent.speed;
            _gewitterwolke._navMeshAgent.speed = 0;
            Raycast();
            GameObject prefabToDestroy = Instantiate(_prefab, _collision, Quaternion.identity);
            yield return new WaitForSeconds(2.5f);
            Destroy(prefabToDestroy);
            Debug.Log("Lightning strikes!");
            if (_playersUnderGewitterwolke.Count != 0) {
                foreach (Movable _player in _playersUnderGewitterwolke) {
                    _player.GetComponent<Health>().TriggerDamage(100);
                }
            }
            yield return new WaitForSeconds(1f);
            _gewitterwolke._navMeshAgent.speed = currentSpeed;
        }
    }
}
