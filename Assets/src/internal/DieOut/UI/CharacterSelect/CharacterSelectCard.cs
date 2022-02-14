using System;
using Afired.UI.Elements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace DieOut.UI.CharacterSelect {
    
    [RequireComponent(typeof(AssignUIControl))]
    public class CharacterSelectCard : MonoBehaviour {
        
        [SerializeField] private Switcher _colorSwitcher;
        [SerializeField] private ModelPreviewManager _modelPreviewManager;
        [SerializeField] private RawImage _renderTextureDisplay;
        [SerializeField] private Camera _renderTextureCamera;
        [SerializeField] private GameObject _gameObjectToActivateWhenControlAssigned;
        [SerializeField] private GameObject _gameObjectToDeactivateWhenControlAssigned;
        public bool IsAssigned => _inputDevice != null;
        private AssignUIControl _assignUIControl;
        private InputDevice _inputDevice;
        [SerializeField] public PlayerColor PlayerColor;
        private ISwitchControl _colorSwitchControl;
        private RenderTexture _renderTexture;
        
        private void Awake() {
            _assignUIControl = GetComponent<AssignUIControl>();
            _gameObjectToActivateWhenControlAssigned.SetActive(false);
            _gameObjectToDeactivateWhenControlAssigned.SetActive(true);
            
            _colorSwitchControl = new EnumSwitchControl<PlayerColor>(PlayerColor);
            _colorSwitchControl.OnValueChanged += (value, valueAsText) => PlayerColor = (PlayerColor) value;
            _colorSwitchControl.OnValueChanged += (value, valueAsText) => _modelPreviewManager.Refresh((PlayerColor) value);
            _colorSwitcher.AssignControl(_colorSwitchControl);

            _renderTexture = new RenderTexture(256, 512, 16, RenderTextureFormat.ARGB32);
            _renderTexture.Create();
            _renderTextureDisplay.texture = _renderTexture;
            _renderTextureCamera.targetTexture = _renderTexture;
        }
        
        public void AssignDevice(InputDevice inputDevice) {
            _assignUIControl.SetDevice(inputDevice);
            _inputDevice = inputDevice;
            
            _gameObjectToActivateWhenControlAssigned.SetActive(true);
            _gameObjectToDeactivateWhenControlAssigned.SetActive(false);
            _modelPreviewManager.Refresh((PlayerColor) _colorSwitchControl.GetValue());
        }

        private void OnDisable() {
            Reset();
        }

        private void OnDestroy() {
            _renderTexture.DiscardContents();
        }

        private void Reset() {
            PlayerColor = default;
            _colorSwitchControl.SelectFirst();
            _inputDevice = null;
            _gameObjectToActivateWhenControlAssigned.SetActive(false);
            _gameObjectToDeactivateWhenControlAssigned.SetActive(true);
            _assignUIControl.DeactivateInput();
            _modelPreviewManager.Refresh(null);
        }
        
    }
    
}
