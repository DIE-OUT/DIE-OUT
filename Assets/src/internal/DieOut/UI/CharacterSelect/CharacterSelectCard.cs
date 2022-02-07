using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.UI.CharacterSelect {
    
    [RequireComponent(typeof(AssignUIControl))]
    public class CharacterSelectCard : MonoBehaviour {
        
        [SerializeField] private GameObject _gameObjectToActivateWhenControlAssigned;
        [SerializeField] private GameObject _gameObjectToDeactivateWhenControlAssigned;
        public bool IsAssigned => _inputDevice != null;
        private AssignUIControl _assignUIControl;
        private InputDevice _inputDevice;
        
        
        private void Awake() {
            _assignUIControl = GetComponent<AssignUIControl>();
            _gameObjectToActivateWhenControlAssigned.SetActive(false);
            _gameObjectToDeactivateWhenControlAssigned.SetActive(true);
        }
        
        public void AssignDevice(InputDevice inputDevice) {
            _assignUIControl.SetDevice(inputDevice);
            _inputDevice = inputDevice;
            
            _gameObjectToActivateWhenControlAssigned.SetActive(true);
            _gameObjectToDeactivateWhenControlAssigned.SetActive(false);
        }
        
    }
    
}
