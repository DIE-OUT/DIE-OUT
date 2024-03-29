using UnityEngine;
using System.Collections;
using DieOut.GameModes.Dornenkrone;
using DieOut.GameModes.Beerenbusch;
using Afired.GameManagement.Characters;

namespace DieOut.GameModes.Interactions {
    public class Tackleable : MonoBehaviour, IAnimatorReceiver {
        
        private Animator _animator;
        
        private Movable _movable;
        private PlayerControls _playerControls;
        private Magmaklumpen _magmaklumpen;
        private Throwable _throwable;
        private Beere _beere;
        private Tackle _tackle;
        private ItemPosition _itemPosition;
        
        private SkinnedMeshRenderer _meshRenderer;
        private Color _origColor;
        private float flickerTime = 0.5f;
        
        [SerializeField] private float _stunDuration = 3f;
        [SerializeField] private float _immunity = 3f;
        public bool _ccImmunity = false;
        [SerializeField] private float _tackleDistance = 30;

        private void Awake() {
            _movable = GetComponent<Movable>();
            _playerControls = GetComponent<PlayerControls>();
        }

        private void Start() {
            _meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            _origColor = _meshRenderer.material.color;
        }
        
        public void ReceiveAnimator(Animator animator) {
            _animator = animator;
        }

        public void TriggerCC_Immunity() {
            StartCoroutine(CC_Immunity());
        }
        
        private IEnumerator CC_Immunity() {
            if (_ccImmunity == false) {
                _ccImmunity = true;
                Debug.Log("cc immunity ON");
                FlickerStart();
                yield return new WaitForSeconds(_stunDuration + _immunity);
                Debug.Log("cc immunity OFF");
                _ccImmunity = false;
                _meshRenderer.material.color = _origColor;
            }
        }
        
        private IEnumerator TackleStunDuration() {
            _animator.SetBool(AnimatorStringHashes.IsStunned, true);
            yield return new WaitForSeconds(_stunDuration);
            _animator.SetBool(AnimatorStringHashes.IsStunned, false);

            Health health = GetComponent<Health>();
            if (!health.IsDead) {
                _movable.GetComponent<PlayerControls>().HasControl = true;
            }
        }

        public void TriggerThrowableStun() {
            StartCoroutine(ThrowableStunDuration());
        }
        
        private IEnumerator ThrowableStunDuration() {
            _playerControls.HasControl = false;
            yield return new WaitForSeconds(_stunDuration);
            _playerControls.HasControl = true;
        }

        private void FlickerStart() {
            _meshRenderer.material.color = Color.gray;
            StartCoroutine(FlickerStop());
        }

        private IEnumerator FlickerStop() {
            yield return new WaitForSeconds(flickerTime);
            _meshRenderer.material.color = _origColor;
            
            if (_ccImmunity) {
                yield return new WaitForSeconds(flickerTime);
                FlickerStart();
            }
        }

        public void TriggerTackle(Movable tacklingPlayer) {
            if (_movable != null && _ccImmunity == false) {
                _movable.GetComponent<PlayerControls>().HasControl = false;

                // Wenn der getacklete Player einen Magmaklumpen trägt, geht dieser auf den tacklenden Player über
                _magmaklumpen = GetComponentInChildren<Magmaklumpen>();
                
                if (_magmaklumpen != null) {
                    _itemPosition = tacklingPlayer.GetComponentInChildren<ItemPosition>();
                    _magmaklumpen.transform.SetParent(_itemPosition.transform);
                    _magmaklumpen.transform.position = _itemPosition.transform.position;
                }

                // Wenn der getacklete Player ein Throwable Item trägt, lässt er dieses Fallen
                _throwable = GetComponentInChildren<Throwable>();
                if (_throwable != null) {
                    _throwable._attachedToPlayer = false;
                }

                // Wenn der getacklete Player eine Beere trägt, wird diese zerstört
                _beere = GetComponentInChildren<Beere>();
                if (_beere != null) {
                    _movable.GetComponent<PlayerControls>()._movementSpeed = _beere._normalMovementSpeed;
                    EatBeere eatBeere = GetComponent<EatBeere>();
                    eatBeere.enabled = false;
                    _beere._attachedToPlayer = false;
                    Destroy(_beere.gameObject);
                }

                // Der getacklete Player bewegt sich in die entgegengesetzte Richtung des tacklenden Players
                _animator.SetTrigger(AnimatorStringHashes.TriggerKnockback);
                Vector3 distance = _movable.transform.position - tacklingPlayer.transform.position;
                _movable.AddVelocity(new Vector3(distance.x, 0, distance.z).normalized * _tackleDistance);
                
                // mit Höhe:
                //_movable.AddVelocity((_movable.transform.position - tacklingPlayer.transform.position).normalized * _tackleDistance);
            }
            
            StartCoroutine(CC_Immunity());
            StartCoroutine(TackleStunDuration());
        }
    }
}
