using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.GameMode {
    
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour {

        [SerializeField] private DeviceTypes _deviceTypes;
        [Header("Settings")]
        [SerializeField] private float _cameraAngle = 45f;
        [SerializeField] public float _movementSpeed = 5f;
        [SerializeField] private float _gravityForceUp = 50f;
        [SerializeField] private float _gravityForceDown = 70f;
        [SerializeField] public float _jumpForce = 15f;
        [SerializeField] private float _jumpInputBufferTime = 0.1f;

        private Vector3 _velocity;
        private Vector2 _moveInput;
        private bool _jumpInputBuffer;
        private IEnumerator _clearJumpInputBuffer;

        //references
        private CharacterController _characterController;
        private Camera _mainCamera;
        private InputTable _inputTable;


        private void Awake() {
            _characterController = GetComponent<CharacterController>();
            _mainCamera = Camera.main;

            _inputTable = new InputTable();

            if(_deviceTypes == DeviceTypes.Gamepad)
                _inputTable.devices = new[] { Gamepad.all[0] };
            else if(_deviceTypes == DeviceTypes.Keyboard)
                _inputTable.devices = new InputDevice[] { Keyboard.current, Mouse.current };
            
            _inputTable.CharacterControls.Jump.performed += OnJumpInput;
        }

        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }
        
        private void OnJumpInput(InputAction.CallbackContext ctx) {
            _jumpInputBuffer = true;
    
            if(_clearJumpInputBuffer != null)
                StopCoroutine(_clearJumpInputBuffer);
    
            _clearJumpInputBuffer = ClearJumpInputBuffer();
            
            StartCoroutine(_clearJumpInputBuffer);
        }

        private IEnumerator ClearJumpInputBuffer() {
            yield return new WaitForSeconds(_jumpInputBufferTime);
            _jumpInputBuffer = false;
        }

        private void Update() {
            UpdateInputs();
            UpdateVelocity();
            UpdateController();
        }

        private void UpdateInputs() {
            _cameraAngle = _mainCamera.transform.rotation.eulerAngles.y;
            _moveInput = _inputTable.CharacterControls.Move.ReadValue<Vector2>();
        }

        private void UpdateVelocity() {
            if(_characterController.isGrounded)
                _velocity.y = 0;
            if(_jumpInputBuffer && _characterController.isGrounded) {
                _velocity.y = _jumpForce;
                _jumpInputBuffer = false;
                if(_clearJumpInputBuffer != null)
                    StopCoroutine(_clearJumpInputBuffer);
            }
    
            _velocity.y -= (_velocity.y < 0 ? _gravityForceDown : _gravityForceUp) * Time.deltaTime;
            
            _velocity.x = _moveInput.x * _movementSpeed;
            _velocity.z = _moveInput.y * _movementSpeed;
        }
        
        private void UpdateController() {
            _characterController.Move(Quaternion.Euler(0, _cameraAngle, 0) * _velocity * Time.deltaTime);
        }
        
    }
    
    [Serializable]
    public enum DeviceTypes {
        Keyboard,
        Gamepad
    }

}
