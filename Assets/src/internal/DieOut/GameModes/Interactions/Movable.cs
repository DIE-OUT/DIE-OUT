using UnityEngine;

namespace DieOut.GameModes.Interactions {
    
    [RequireComponent(typeof(CharacterController))]
    public class Movable : MonoBehaviour {
        
        [SerializeField] private float _inAirGravityForceUp = 50f;
        [SerializeField] private float _inAirGravityForceDown = 50f;
        [SerializeField] private float _groundGravityForce = 1f;
        [SerializeField] private float _horizontalDrag = 15f;
        private bool _hasGravity = true;
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
            Vector3 direction = Vector3.zero;
            if(_hasGravity)
                ApplyGravity();
            direction += _currentVelocity * Time.deltaTime;
            direction += _move;
            ApplyHorizontalDrag();
            return direction;
        }
        
        private void PostMove() {
            _move = Vector3.zero;
            if(_characterController.isGrounded)
                _currentVelocity = new Vector3(_currentVelocity.x, -_groundGravityForce, _currentVelocity.z);
        }

        private void ApplyGravity() {
            if(_currentVelocity.y >= 0)
                _currentVelocity += new Vector3(0, -_inAirGravityForceUp * Time.deltaTime, 0);
            else
                _currentVelocity += new Vector3(0, -_inAirGravityForceDown * Time.deltaTime, 0);
        }
        
        private void ApplyHorizontalDrag() {
            Vector3 newVelocity = _currentVelocity * ( 1 - Time.deltaTime * _horizontalDrag);
            _currentVelocity = new Vector3(newVelocity.x, _currentVelocity.y, newVelocity.z);
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
    }
    
}
