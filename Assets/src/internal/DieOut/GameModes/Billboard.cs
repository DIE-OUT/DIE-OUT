using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DieOut.GameModes {
    public class Billboard : MonoBehaviour {
        private Camera _camera;

        private void Awake() {
            _camera = Camera.main;
        }

        private void Update() {
            transform.LookAt(transform.position + _camera.transform.rotation * Vector3.back,
                _camera.transform.rotation * Vector3.up);
        }
    }
}
