using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DieOut.GameModes.Beerenbusch {
    public class GrowBack : MonoBehaviour {
        
        [SerializeField] private float _growBackTime = 10;
        private bool _allInactive;
        private bool _inCoroutine = false;

        private void Update() {
            if (AllBeerenInactive() && !_inCoroutine) {
                _inCoroutine = true;
                StartCoroutine(BeerenGrowBack());
            }
        }

        private bool AllBeerenInactive() {

            _allInactive = transform.Cast<Transform>().All(child => !child.gameObject.activeInHierarchy);

            if (_allInactive) {
                return true;
            }
            else {
                return false;
            }
        }
        
        

        private IEnumerator BeerenGrowBack() {
            yield return new WaitForSeconds(_growBackTime);

            foreach (Transform child in transform) {
                child.gameObject.SetActive(true);
            }

            _inCoroutine = false;
        }
    }
}