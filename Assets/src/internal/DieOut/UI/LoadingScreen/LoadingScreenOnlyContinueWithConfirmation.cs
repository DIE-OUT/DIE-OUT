using System.Threading.Tasks;
using Afired.GameManagement.Sessions;
using Afired.SceneManagement;
using Sirenix.OdinInspector;
using UnityAsync;
using UnityEngine;

namespace DieOut.UI.LoadingScreen {
    
    public class LoadingScreenOnlyContinueWithConfirmation : MonoBehaviour {

        [SerializeField] private GameObject _confirmationButtonRoot;
        private bool _confirmed;


        private void Awake() {
            _confirmationButtonRoot.SetActive(false);
            
            // dont require confirmation if not loading into a game mode
            if(!Session.HasCurrent || Session.Current.GameModeInstance == null) {
                return;
            }
            SceneManager.TaskOnEndAsyncLevelLoading += EnableConfirmationButton;
            SceneManager.TaskOnEndAsyncLevelLoading += WaitForConfirmation;
        }

        private Task EnableConfirmationButton() {
            _confirmationButtonRoot.SetActive(true);
            return Task.CompletedTask;
        }
        
        private async Task WaitForConfirmation() {
            while(!_confirmed) {
                await Await.NextUpdate();
            }
        }
        
        [Button]
        public void Confirm() {
            _confirmed = true;
        }
        
    }
    
}
