using System.Threading.Tasks;
using Afired.GameManagement.Sessions;
using UnityAsync;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.UI.Scoreboard {
    
    public class ScoreboardManager : MonoBehaviour {

        [SerializeField] private float _afterGameEndedShowScoreboardForSeconds = 5f;
        [SerializeField] private GameObject _scoreboardRoot;
        private InputTable _inputTable;
        
        
        private void Awake() {
            _scoreboardRoot.SetActive(false);
            Session.Current.GameModeInstance.OnGameModeStart += OnGameModeStart;
            Session.Current.GameModeInstance.OnGameModeEnd += OnGameModeEnd;
        }

        private Task OnGameModeStart() {
            EnableInput();
            return Task.CompletedTask;
        }

        private async Task OnGameModeEnd() {
            DisableInput();
            await Await.Seconds(1f);
            Show();
            await Await.Seconds(_afterGameEndedShowScoreboardForSeconds);
            Hide();
            await Await.Seconds(1f);
        }

        private void EnableInput() {
            _inputTable = new InputTable();
            _inputTable.Enable();
            _inputTable.Navigation.Scoreboard.performed += (_) => Show();
            _inputTable.Navigation.Scoreboard.canceled += (_) => Hide();
        }
        
        private void DisableInput() {
            _inputTable.Disable();
            _inputTable.Dispose();
        }

        private void Hide() {
            _scoreboardRoot.SetActive(false);
        }

        private void Show() {
            _scoreboardRoot.SetActive(true);
        }
        
    }
    
}
