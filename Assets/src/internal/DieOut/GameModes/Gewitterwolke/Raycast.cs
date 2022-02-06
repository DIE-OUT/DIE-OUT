using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DieOut.GameModes.Gewitterwolke {
    public class Raycast : MonoBehaviour {

        public GameObject _lastHit;
        public Vector3 _collision = Vector3.zero;
        private Vector3 _height = new Vector3(0, 1, 0);
        public LayerMask _layer;
        
        void Update() {
            var ray = new Ray(this.transform.position - _height, -this.transform.up);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)) {
                _lastHit = hit.transform.gameObject;
                _collision = hit.point;
            }
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_collision, 0.2f);
        }
    }
}
