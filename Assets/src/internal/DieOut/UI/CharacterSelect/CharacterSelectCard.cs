using System.Linq;
using Afired.GameManagement.Characters;
using Afired.GameManagement.Sessions;
using Afired.UI.Elements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace DieOut.UI.CharacterSelect {
    
    [RequireComponent(typeof(AssignUIControl))]
    public class CharacterSelectCard : MonoBehaviour {
        
        [SerializeField] private Switcher _characterSwitcher;
        [SerializeField] private CharacterModelPreview _characterModelPreview;
        [SerializeField] private RawImage _renderTextureDisplay;
        [SerializeField] private Camera _renderTextureCamera;
        [SerializeField] private GameObject _gameObjectToActivateWhenControlAssigned;
        [SerializeField] private GameObject _gameObjectToDeactivateWhenControlAssigned;
        public bool IsAssigned => _inputDevice != null;
        private AssignUIControl _assignUIControl;
        private InputDevice _inputDevice;
        public Character Character { get; private set; }
        private ISwitchControl _characterSwitchControl;
        private RenderTexture _renderTexture;
        
        private void Awake() {
            _assignUIControl = GetComponent<AssignUIControl>();
            _gameObjectToActivateWhenControlAssigned.SetActive(false);
            _gameObjectToDeactivateWhenControlAssigned.SetActive(true);
            
            _characterSwitchControl = new SwitchControl<Character>(CharacterRegister.Characters, CharacterRegister.Characters.FirstOrDefault(), character => character.DisplayName);
            _characterSwitchControl.OnValueChanged += (value, valueAsText) => Character = (Character) value;
            _characterSwitchControl.OnValueChanged += (value, valueAsText) => _characterModelPreview.Refresh((Character) value);
            _characterSwitcher.AssignControl(_characterSwitchControl);

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
            Character = (Character) _characterSwitchControl.GetValue();
            _characterModelPreview.Refresh((Character) _characterSwitchControl.GetValue());
        }

        private void OnDisable() {
            Reset();
        }

        private void OnDestroy() {
            _renderTexture.DiscardContents();
        }

        private void Reset() {
            CharacterRegister.Characters.FirstOrDefault();
            _characterSwitchControl.SelectFirst();
            _inputDevice = null;
            _gameObjectToActivateWhenControlAssigned.SetActive(false);
            _gameObjectToDeactivateWhenControlAssigned.SetActive(true);
            _assignUIControl.DeactivateInput();
            _characterModelPreview.Refresh(null);
        }
        
    }
    
}
