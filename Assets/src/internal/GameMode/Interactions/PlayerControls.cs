using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.GameMode.Interactions {
    
    [RequireComponent(typeof(Movable))]
    public class PlayerControls : MonoBehaviour {
        
        [SerializeField] private DieOut.GameMode.DeviceTypes _deviceTypes;
        [Header("Settings")]
        [SerializeField] private float _cameraAngle = 45f;
        [SerializeField] [Range(0f, 0.1f)] public float _movementSpeed = 0.1f;
        [SerializeField] private float _gravityForceUp = 50f;
        [SerializeField] private float _gravityForceDown = 70f;
        [SerializeField] public float _jumpForce = 15f;
        [SerializeField] private float _jumpInputBufferTime = 0.1f;

        private Vector3 _velocity;
        private Vector2 _moveInput;
        private bool _jumpInputBuffer;
        private IEnumerator _clearJumpInputBuffer;
        private Movable _movable;

        //references
        private CharacterController _characterController;
        private Camera _mainCamera;
        private InputTable _inputTable;


        private void Awake() {
            _characterController = GetComponent<CharacterController>();
            _mainCamera = Camera.main;

            _inputTable = new InputTable();

            if(_deviceTypes == DieOut.GameMode.DeviceTypes.Gamepad)
                _inputTable.devices = new[] { Gamepad.all[0] };
            else if(_deviceTypes == DieOut.GameMode.DeviceTypes.Keyboard)
                _inputTable.devices = new InputDevice[] { Keyboard.current, Mouse.current };
            
            _inputTable.CharacterControls.Jump.performed += OnJumpInput;
            _movable = GetComponent<Movable>();
        }

        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }
        
        private void OnJumpInput(InputAction.CallbackContext ctx) {
            
            _movable.AddVelocity(new Vector3(0, 1, 0));
            
//            _jumpInputBuffer = true;
//    
//            if(_clearJumpInputBuffer != null)
//                StopCoroutine(_clearJumpInputBuffer);
//    
//            _clearJumpInputBuffer = ClearJumpInputBuffer();
//            
//            StartCoroutine(_clearJumpInputBuffer);
        }

        private IEnumerator ClearJumpInputBuffer() {
            yield return new WaitForSeconds(_jumpInputBufferTime);
            _jumpInputBuffer = false;
        }

        private void Update() {
            UpdateInputs();
            UpdateMovable();
        }

        private void UpdateInputs() {
            _cameraAngle = _mainCamera.transform.rotation.eulerAngles.y;
            _moveInput = _inputTable.CharacterControls.Move.ReadValue<Vector2>();
        }

        private void UpdateMovable() {
            _movable.Move(Quaternion.Euler(0, _cameraAngle, 0) * new Vector3(_moveInput.x, 0, _moveInput.y) * _movementSpeed);
        }
        
    }
    
    [Serializable]
    public enum DeviceTypes {
        Keyboard,
        Gamepad
    }
    
}
