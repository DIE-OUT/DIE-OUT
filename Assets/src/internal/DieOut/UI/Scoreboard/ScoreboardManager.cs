using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.UI.Scoreboard {
    
    public class ScoreboardManager : MonoBehaviour {

        [SerializeField] private GameObject _scoreboardRoot;
        private InputTable _inputTable;
        
        private void Awake() {
            _scoreboardRoot.SetActive(false);
            _inputTable = new InputTable();
            _inputTable.Enable();
            _inputTable.Navigation.Scoreboard.performed += Show;
            _inputTable.Navigation.Scoreboard.canceled += Hide;
        }
        
        private void Hide(InputAction.CallbackContext obj) {
            _scoreboardRoot.SetActive(false);
        }

        private void Show(InputAction.CallbackContext _) {
            _scoreboardRoot.SetActive(true);
        }

        private void OnDestroy() {
            _inputTable.Disable();
            _inputTable.Dispose();
        }
        
    }
    
}
