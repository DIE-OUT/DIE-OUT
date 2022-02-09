using System;
using Afired.UI.Elements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.UI.CharacterSelect {
    
    [RequireComponent(typeof(AssignUIControl))]
    public class CharacterSelectCard : MonoBehaviour {
        
        [SerializeField] private Switcher _colorSwitcher;
        [SerializeField] private GameObject _gameObjectToActivateWhenControlAssigned;
        [SerializeField] private GameObject _gameObjectToDeactivateWhenControlAssigned;
        public bool IsAssigned => _inputDevice != null;
        private AssignUIControl _assignUIControl;
        private InputDevice _inputDevice;
        [SerializeField] public PlayerColor PlayerColor;
        private ISwitchControl _colorSwitchControl;
        
        private void Awake() {
            _assignUIControl = GetComponent<AssignUIControl>();
            _gameObjectToActivateWhenControlAssigned.SetActive(false);
            _gameObjectToDeactivateWhenControlAssigned.SetActive(true);
            
            _colorSwitchControl = new EnumSwitchControl<PlayerColor>(PlayerColor);
            _colorSwitchControl.OnValueChanged += (value, valueAsText) => PlayerColor = (PlayerColor) value;
            _colorSwitcher.AssignControl(_colorSwitchControl);
        }
        
        public void AssignDevice(InputDevice inputDevice) {
            _assignUIControl.SetDevice(inputDevice);
            _inputDevice = inputDevice;
            
            _gameObjectToActivateWhenControlAssigned.SetActive(true);
            _gameObjectToDeactivateWhenControlAssigned.SetActive(false);
        }

        private void OnDisable() {
            Reset();
        }

        private void Reset() {
            PlayerColor = default;
            _colorSwitchControl.SelectFirst();
            _inputDevice = null;
            _gameObjectToActivateWhenControlAssigned.SetActive(false);
            _gameObjectToDeactivateWhenControlAssigned.SetActive(true);
            _assignUIControl.DeactivateInput();
        }
        
    }
    
}
