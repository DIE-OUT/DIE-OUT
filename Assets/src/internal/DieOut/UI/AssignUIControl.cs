using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace DieOut.UI {
    
    [RequireComponent(typeof(PlayerInput), typeof(MultiplayerEventSystem), typeof(InputSystemUIInputModule))]
    public class AssignUIControl : MonoBehaviour {
        
        private PlayerInput _playerInput;
        private MultiplayerEventSystem _multiplayerEventSystem;
        private InputSystemUIInputModule _inputSystemUIInputModule;
        
        
        private void Awake() {
            _playerInput = GetComponent<PlayerInput>();
            _multiplayerEventSystem = GetComponent<MultiplayerEventSystem>();
            _inputSystemUIInputModule = GetComponent<InputSystemUIInputModule>();
            DeactivateInput();
        }
        
        public void SetDevice(InputDevice inputDevice) {
            _playerInput.SwitchCurrentControlScheme(new InputDevice[] { inputDevice });
            _multiplayerEventSystem.enabled = true;
        }

        public void DeactivateInput() {
            _playerInput.SwitchCurrentControlScheme(new InputDevice[] { });
            _multiplayerEventSystem.enabled = false;
        }
        
    }
    
}
