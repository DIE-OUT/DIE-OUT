using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DieOut.GameMode.Dornenkrone {
    public class Magmaklumpen : MonoBehaviour {

        private bool _attachedToPlayer = false;

        public bool AttachedToPlayer() {
            if (transform.parent != null) {
                Debug.Log("has parent");
                return _attachedToPlayer == true;
            }
            else {
                Debug.Log("no parent");
                return _attachedToPlayer == false;
            }
        }
    }
}
