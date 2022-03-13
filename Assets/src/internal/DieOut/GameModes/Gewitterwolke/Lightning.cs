using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Afired.GameManagement.Sessions;
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
        [SerializeField] private int _damage = 100;
        public Vector3 _collision = Vector3.zero;
        private Vector3 _height = new Vector3(0, 1, 0);
        public LayerMask _layer;
        [SerializeField] private GameObject _prefab;
        //[SerializeField] private GameObject _prefabShadow;
        //private GameObject _prefabShadowToDestroy;
        private bool _isPrepared;
        [SerializeField] private float _timeBeforeLightningStrikes = 2.5f;

        private void Awake() {
            _gewitterwolke = GetComponent<RandomMovement>();
            _playersUnderGewitterwolke = new List<Movable>();

            Session.Current.GameModeInstance.OnGameModePrepare += OnGameModePrepare;
        }
        

        private Task OnGameModePrepare() {
            _timer = Random.Range(_delayRange.x, _delayRange.y);
            
            Raycast();
            //_prefabShadowToDestroy = Instantiate(_prefabShadow, _collision, Quaternion.identity);
            //Debug.Log(_prefabShadowToDestroy);
            _isPrepared = true;
            
            return Task.CompletedTask;
        }
        
        private void Update() {
            if(!_isPrepared)
                return;
            
            Raycast();
            //_prefabShadowToDestroy.transform.position = _collision;
            
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
            if (Physics.Raycast(ray, out hit, 100,_layer)) {
                _collision = hit.point;
            }
        }

        IEnumerator LightningStrike() {
            //_prefabShadowToDestroy.SetActive(false);
            float currentSpeed = _gewitterwolke._navMeshAgent.speed;
            _gewitterwolke._navMeshAgent.speed = 0;
            yield return new WaitForSeconds(0.25f);
            Raycast();
            GameObject prefabToDestroy = Instantiate(_prefab, _collision, Quaternion.identity);
            Debug.Log(_collision + " | " + prefabToDestroy.transform.position);
            yield return new WaitForSeconds(_timeBeforeLightningStrikes);
            Destroy(prefabToDestroy);
            Debug.Log("Lightning strikes!");
            if (_playersUnderGewitterwolke.Count != 0) {
                foreach (Movable _player in _playersUnderGewitterwolke) {
                    _player.GetComponent<Health>().TriggerDamage(_damage, DamageType.Lightning);
                }
            }
            yield return new WaitForSeconds(1f);
            _gewitterwolke._navMeshAgent.speed = currentSpeed;
            
            //_prefabShadowToDestroy.SetActive(true);
        }
    }
}
