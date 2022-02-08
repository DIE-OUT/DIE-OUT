using Afired.GameManagement.Sessions;
using UnityEngine;

namespace DieOut.UI.Scoreboard {
    
    public class ScoreboardPlayerEntryManager : MonoBehaviour {

        [SerializeField] private GameObject _scoreboardPlayerEntryPrefab;
        
        
        private void Awake() {
            for(int i = 0; i < Session.Current.PlayerCount; i++) {
                GameObject scoreboardPlayerEntry = Instantiate(_scoreboardPlayerEntryPrefab, transform);
                scoreboardPlayerEntry.GetComponent<ScoreboardPlayerEntry>().Init(Session.Current.Player[i]);
            }
        }
        
    }
    
}
