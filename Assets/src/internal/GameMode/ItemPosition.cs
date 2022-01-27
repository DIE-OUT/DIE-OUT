using System.Collections;
using System.Collections.Generic;
using DieOut.GameMode.Dornenkrone;
using UnityEngine;

namespace DieOut.GameMode {
    public class ItemPosition : MonoBehaviour {

        public void TriggerPickUpKlumpen(Magmaklumpen _magmaklumpen) {
            _magmaklumpen.transform.SetParent(transform);
            _magmaklumpen.transform.position = transform.position;
        }

        public void TriggerPickUpThrowable(Throwable _throwable) {
            _throwable.transform.SetParent(transform);
            _throwable.transform.position = transform.position;
        }
    }
}

