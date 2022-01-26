using System;
using UnityEngine;

namespace DieOut.GameMode.Interactions {
    
    [RequireComponent(typeof(CharacterController))]
    public class Movable : MonoBehaviour {
        
        
        //TODO: [SerializeField] private float _inAirGravityForceUp = 9.81f;
        [SerializeField] public float _health = 100;
        // - [Serialize Field] Name ist nur zum testen, wird noch verändert
        [SerializeField] public string _name;
        [SerializeField] private float _inAirGravityForceDown = 0.5f;
        [SerializeField] private float _groundGravityForce = 0.01f;
        [SerializeField] private bool _hasGravity = true;
        private CharacterController _characterController;
        private Vector3 _currentVelocity;
        private Vector3 _move;
        
        private void Awake() {
            _characterController = GetComponent<CharacterController>();
        }
        
        private void LateUpdate() {
            Vector3 direction = CalcNextFrame();
            _characterController.Move(direction);
            PostMove();
        }

        private Vector3 CalcNextFrame() {
            Vector3 direction = default;
            direction += _currentVelocity;
            direction += _move;
            if(_hasGravity)
                ApplyGravity();
            ApplyHorizontalDrag();
            return direction;
        }
        
        private void PostMove() {
            _move = Vector3.zero;
            if(_characterController.isGrounded)
                _currentVelocity = new Vector3(_currentVelocity.x, -_groundGravityForce, _currentVelocity.z);
        }

        private void ApplyGravity() {
            _currentVelocity += new Vector3(0, -_inAirGravityForceDown * Time.deltaTime, 0);
        }
        
        //TODO: better drag implementation
        private void ApplyHorizontalDrag() {
            _currentVelocity = new Vector3(_currentVelocity.x / 1.1f, _currentVelocity.y, _currentVelocity.z / 1.1f);
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

        public bool IsGrounded => _characterController.isGrounded;

        public void TriggerDamage(float damage) {
            _health -= damage;
        }

    }
    
}
