using UnityEngine;
using System.Collections;
using DieOut.GameModes.Dornenkrone;

namespace DieOut.GameModes.Interactions {
    public class Tackleable : MonoBehaviour {
        
        private Movable _movable;
        private Magmaklumpen _magmaklumpen;
        private Throwable _throwable;
        private Tackle _tackle;
        private ItemPosition _itemPosition;
        
        [SerializeField] private float _stunDuration = 2f;
        [SerializeField] private float _immunity = 3f;
        public bool tackleImmunity = false;
        [SerializeField] private float _tackleDistance = 30;

        private void Awake() {
            _movable = GetComponent<Movable>();
        }

        private IEnumerator TackleImmunity() {
            yield return new WaitForSeconds(_stunDuration + _immunity);
            Debug.Log("tackle immunity OFF");
            tackleImmunity = false;
        }
        
        private IEnumerator TackleStunDuration() {
            yield return new WaitForSeconds(_stunDuration);
            _movable.GetComponent<PlayerControls>().HasControl = true;
        }

        public void TriggerTackle(Movable tacklingPlayer) {
            if (_movable != null && tackleImmunity == false) {
                _movable.GetComponent<PlayerControls>().HasControl = false;

                // Wenn der getacklete Player einen Magmaklumpen trägt, geht dieser auf den tacklenden Player über
                // -> Wenn der tacklende Player dabei ein Throwable Item trägt, lässt er dieses Fallen um den Itemposition Platz für den Magmaklumpen frei zu machen
                _magmaklumpen = GetComponentInChildren<Magmaklumpen>();
                
                if (_magmaklumpen != null) {
                    _throwable = tacklingPlayer.GetComponentInChildren<Throwable>();

                    if (_throwable != null) {
                        _throwable._attachedToPlayer = false;
                    }

                    _itemPosition = tacklingPlayer.GetComponentInChildren<ItemPosition>();
                    _magmaklumpen.transform.SetParent(_itemPosition.transform);
                    _magmaklumpen.transform.position = _itemPosition.transform.position;
                }

                // Wenn der getacklete Player ein Throwable Item trägt, lässt er dieses Fallen
                _throwable = GetComponentInChildren<Throwable>();
                if (_throwable != null) {
                    _throwable._attachedToPlayer = false;
                }
                
                // Der getacklete Player bewegt sich in die entgegengesetzte Richtung des tacklenden Players
                _movable.AddVelocity(new Vector3(_movable.transform.position.x - tacklingPlayer.transform.position.x, 0, _movable.transform.position.y - tacklingPlayer.transform.position.y).normalized * _tackleDistance);
                
                // mit Höhe:
                //_movable.AddVelocity((_movable.transform.position - tacklingPlayer.transform.position).normalized * _tackleDistance);
            }

            tackleImmunity = true;
            Debug.Log("tackle immunity ON");
            StartCoroutine(TackleImmunity());
            StartCoroutine(TackleStunDuration());
        }
    }
}
