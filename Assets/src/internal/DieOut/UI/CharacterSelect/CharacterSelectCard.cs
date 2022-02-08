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
        
        
        private void Awake() {
            _assignUIControl = GetComponent<AssignUIControl>();
            _gameObjectToActivateWhenControlAssigned.SetActive(false);
            _gameObjectToDeactivateWhenControlAssigned.SetActive(true);
            
            ISwitchControl color = new EnumSwitchControl<PlayerColor>(PlayerColor);
            color.OnValueChanged += (value, valueAsText) => PlayerColor = (PlayerColor) value;
            _colorSwitcher.AssignControl(color);
        }
        
        public void AssignDevice(InputDevice inputDevice) {
            _assignUIControl.SetDevice(inputDevice);
            _inputDevice = inputDevice;
            
            _gameObjectToActivateWhenControlAssigned.SetActive(true);
            _gameObjectToDeactivateWhenControlAssigned.SetActive(false);
        }
        
    }
    
}
