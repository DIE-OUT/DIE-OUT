using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Mathematics;

namespace DieOut.GameModes.Beerenbusch {
    public class GrowBack : MonoBehaviour {

        [SerializeField] private float _growBackTime = 10;
        private bool _beerenbuschEmpty;
        private bool _inCoroutine = false;

        private void Update() {
            if (BeerenbuschEmpty() && !_inCoroutine) {
                Debug.Log("empty");
                _inCoroutine = true;
                StartCoroutine(BeerenGrowBack());
            }
        }

        private bool BeerenbuschEmpty() {
            Beere _anyBeere = GetComponentInChildren<Beere>();
            
            if (_anyBeere == null) {
                return true;
            }
            else {
                return false;
            }
        }
        
        

        private IEnumerator BeerenGrowBack() {
            yield return new WaitForSeconds(_growBackTime);
            
            Debug.Log("growback");

            _inCoroutine = false;
        }
    }
}