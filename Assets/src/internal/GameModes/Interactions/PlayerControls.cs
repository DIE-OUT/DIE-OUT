using System;
using System.Collections;
using DieOut.GameModes.Management;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.GameModes.Interactions {
    
    [RequireComponent(typeof(Movable))]
    public class PlayerControls : MonoBehaviour, IDeviceReceiver {

        public bool HasControl = true;
        [SerializeField] private DieOut.GameModes.DeviceTypes _deviceTypes;
        [Header("Settings")]
        [SerializeField] private float _cameraAngle = 45f;
        [SerializeField] [Range(0f, 10f)] public float _movementSpeed = 5f;
        [SerializeField] public float _jumpForce = 15f;
        [SerializeField] private float _jumpInputBufferTime = 0.1f;
        
        private Vector2 _moveInput;
        private bool _jumpInputBuffer;
        private IEnumerator _clearJumpInputBuffer;
        private Movable _movable;

        //references
        private Camera _mainCamera;
        private InputTable _inputTable;

        public Quaternion _direction;


        private void Awake() {
            _mainCamera = Camera.main;
            _movable = GetComponent<Movable>();

            _inputTable = new InputTable();

            if(_deviceTypes == DieOut.GameModes.DeviceTypes.Gamepad)
                _inputTable.devices = new[] { Gamepad.all[0] };
            else if(_deviceTypes == DieOut.GameModes.DeviceTypes.Keyboard)
                _inputTable.devices = new InputDevice[] { Keyboard.current, Mouse.current };
            
            _inputTable.CharacterControls.Jump.performed += OnJumpInput;
        }
        
        public void SetDevices(InputDevice[] devices) {
            _inputTable.devices = devices;
        }
        
        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }
        
        private void OnJumpInput(InputAction.CallbackContext ctx) {
            if(!HasControl)
                return;
            
            if(_movable.IsGrounded)
                _movable.AddVelocity(new Vector3(0, _jumpForce, 0));
            
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
            UpdateRotation();
        }

        private void UpdateInputs() {
            _cameraAngle = _mainCamera.transform.rotation.eulerAngles.y;
            _moveInput = _inputTable.CharacterControls.Move.ReadValue<Vector2>();
        }

        private void UpdateMovable() {
            if(!HasControl)
                return;
            _movable.Move(Quaternion.Euler(0, _cameraAngle, 0) * new Vector3(_moveInput.x, 0, _moveInput.y) * _movementSpeed * Time.deltaTime);
        }

        private void UpdateRotation() {
            if(!HasControl)
                return;
            if (_moveInput.magnitude != 0) {
                _direction = Quaternion.LookRotation(Quaternion.Euler(0, _cameraAngle, 0) *
                                                     new Vector3(_moveInput.x, 0, _moveInput.y));
                transform.SetPositionAndRotation(transform.position, _direction);
            }
        }
        
    }
    
    [Serializable]
    public enum DeviceTypes {
        Keyboard,
        Gamepad
    }
    
}
