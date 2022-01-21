using System;
using UnityEngine;

namespace DieOut.GameMode.Interactions {
    
    [RequireComponent(typeof(CharacterController))]
    public class Movable : MonoBehaviour {

        private CharacterController _characterController;
        private Vector3 _currentVelocity;
        private Vector3 _move;
        
        private void Awake() {
            _characterController = GetComponent<CharacterController>();
        }
        
        private void Update() {
            Vector3 direction = default;
            direction += _currentVelocity;
            direction += _move;
            _characterController.Move(direction);
            
            _move = Vector3.zero;
            _currentVelocity = _currentVelocity / 2;
        }

        public void Move(Vector3 direction) {
            _move += direction;
        }
        
        public void AddVelocity(Vector3 velocity) {
            _currentVelocity += velocity;
        }
        
        public void SetVelocity(Vector3 velocity) {
            _currentVelocity = velocity;
        }
        
    }
    
}
