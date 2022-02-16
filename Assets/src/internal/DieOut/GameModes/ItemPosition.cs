using Afired.GameManagement.Characters;
using DieOut.GameModes.Dornenkrone;
using DieOut.GameModes.Beerenbusch;
using UnityEngine;
using UnityEngine.Animations;

namespace DieOut.GameModes {
    
    [RequireComponent(typeof(ParentConstraint))]
    public class ItemPosition : MonoBehaviour, IItemPositionTagReceiver {

        public void TriggerPickUpKlumpen(Magmaklumpen _magmaklumpen) {
            _magmaklumpen.transform.SetParent(transform);
            _magmaklumpen.transform.position = transform.position;
            _magmaklumpen.transform.rotation = transform.rotation;
        }

        public void TriggerPickUpThrowable(Throwable _throwable) {
            _throwable.transform.SetParent(transform);
            _throwable.transform.position = transform.position;
        }
        
        public void TriggerPickUpBeere(Beere _beere) {
            _beere.transform.SetParent(transform);
            _beere.transform.position = transform.position;
        }

        public void SetItemPositionTag(ItemPositionTag itemPositionTag) {
            ParentConstraint parentConstraint = GetComponent<ParentConstraint>();
            parentConstraint.AddSource(new ConstraintSource() { sourceTransform = itemPositionTag.transform, weight = 1 });
        }
        
    }
    
}

