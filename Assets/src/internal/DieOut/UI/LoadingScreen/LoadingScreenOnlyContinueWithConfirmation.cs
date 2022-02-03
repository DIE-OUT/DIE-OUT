using System.Threading.Tasks;
using Afired.GameManagement.Sessions;
using Afired.SceneManagement;
using Sirenix.OdinInspector;
using UnityAsync;
using UnityEngine;

namespace DieOut.UI.LoadingScreen {
    
    public class LoadingScreenOnlyContinueWithConfirmation : MonoBehaviour {
        
        [SerializeField] private GameObject _gameObjectToBeEnabled;
        private bool _confirmed;
        
        
        private void Awake() {
            _gameObjectToBeEnabled.SetActive(false);
            
            // dont require confirmation if not loading into a game mode
            if(!Session.HasCurrent || Session.Current.GameModeInstance == null) {
                return;
            }
            SceneManager.TaskOnEndAsyncLevelLoading += EnableConfirmationButton;
            SceneManager.TaskOnEndAsyncLevelLoading += WaitForConfirmation;
        }

        private Task EnableConfirmationButton() {
            _gameObjectToBeEnabled.SetActive(true);
            return Task.CompletedTask;
        }
        
        private async Task WaitForConfirmation() {
            InputTable inputTable = new InputTable();
            inputTable.Enable();
            inputTable.Navigation.AnyButton.performed += (_) => _confirmed = true;
            while(!_confirmed) {
                await Await.NextUpdate();
            }
            inputTable.Disable();
            inputTable.Dispose();
        }
        
        [Button]
        public void Confirm() {
            _confirmed = true;
        }
        
    }
    
}
