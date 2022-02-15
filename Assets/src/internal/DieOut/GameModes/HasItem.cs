using DieOut.GameModes.Beerenbusch;
using DieOut.GameModes.Dornenkrone;
using UnityEngine;

namespace DieOut.GameModes {
    public class HasItem : MonoBehaviour {

        [SerializeField] private Animator _animator;
        
        private Magmaklumpen _magmaklumpen;
        private Throwable _throwable;
        private Beere _beere;

        private void Update() {
            HasItemAttached();
        }

        private void HasItemAttached() {

            _magmaklumpen = GetComponentInChildren<Magmaklumpen>();
            _throwable = GetComponentInChildren<Throwable>();
            _beere = GetComponentInChildren<Beere>();

            bool hasItem = _magmaklumpen != null || _throwable != null || _beere != null;
            _animator.SetBool(AnimatorStringHashes.HasItem, hasItem);
        }
    }
}
