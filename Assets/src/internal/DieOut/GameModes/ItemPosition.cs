using DieOut.GameModes.Dornenkrone;
using DieOut.GameModes.Beerenbusch;
using UnityEngine;

namespace DieOut.GameModes {
    
    public class ItemPosition : MonoBehaviour {

        public void TriggerPickUpKlumpen(Magmaklumpen _magmaklumpen) {
            _magmaklumpen.transform.SetParent(transform);
            _magmaklumpen.transform.position = transform.position;
        }

        public void TriggerPickUpThrowable(Throwable _throwable) {
            _throwable.transform.SetParent(transform);
            _throwable.transform.position = transform.position;
        }
        
        public void TriggerPickUpBeere(Beere _beere) {
            _beere.transform.SetParent(transform);
            _beere.transform.position = transform.position;
        }
        
    }
    
}

