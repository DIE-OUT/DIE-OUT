using System;
using Afired.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Screen = Afired.UI.Screen;

namespace DieOut.UI.MainMenu {
    
    public class GoBack : MonoBehaviour {
        
        [SerializeField] private Screen _screenToGoBackTo;
        [SerializeField] private ScreenManager _screenManager;
        private InputTable _inputTable;
        
        private void Awake() {
            _inputTable = new InputTable();
            _inputTable.Navigation.Back.performed += Back;
        }
        
        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }
        
        private void OnDestroy() {
            _inputTable.Dispose();
        }
        
        private void Back(InputAction.CallbackContext _) {
            _screenManager.Activate(_screenToGoBackTo);
        }
        
    }
    
}
