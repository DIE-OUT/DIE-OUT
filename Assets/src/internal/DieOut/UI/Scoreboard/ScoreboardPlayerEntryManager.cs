using System.Linq;
using Afired.GameManagement.Sessions;
using UnityEngine;

namespace DieOut.UI.Scoreboard {
    
    public class ScoreboardPlayerEntryManager : MonoBehaviour {

        [SerializeField] private GameObject _scoreboardPlayerEntryPrefab;
        
        
        private void OnEnable() {
            Refresh();
        }

        public void Refresh() {
            for(int i = 0; i < transform.childCount; i++) {
                Destroy(transform.GetChild(i).gameObject);
            }
            
            foreach(Player player in Session.Current.Player.OrderByDescending(player => player.Score)) {
                GameObject scoreboardPlayerEntry = Instantiate(_scoreboardPlayerEntryPrefab, transform);
                scoreboardPlayerEntry.GetComponent<ScoreboardPlayerEntry>().Init(player);
            }
            
        }
        
    }
    
}
