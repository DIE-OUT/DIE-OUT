using System;
using System.Collections;
using System.Collections.Generic;
using DieOut.GameModes.Beerenbusch;
using DieOut.GameModes.Dornenkrone;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace DieOut.GameModes {
    public class HasItem : MonoBehaviour {

        private Magmaklumpen _magmaklumpen;
        private Throwable _throwable;
        private Beere _beere;

        public bool _hasItem = false;

        private void Update() {
            HasItemAttached();
        }

        private void HasItemAttached() {

            _magmaklumpen = GetComponentInChildren<Magmaklumpen>();
            _throwable = GetComponentInChildren<Throwable>();
            _beere = GetComponentInChildren<Beere>();

            if (_magmaklumpen != null || _throwable != null || _beere != null) {
                _hasItem = true;
                Debug.Log("has item");
            }
            else {
                _hasItem = false;
            }
        }
    }
}
