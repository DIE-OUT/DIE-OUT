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

//            bool firstPlaceHasBeenAssigned = false;
//            foreach(Player player in Session.Current.Player.OrderByDescending(player => player.Score)) {
//                GameObject scoreboardPlayerEntry = Instantiate(_scoreboardPlayerEntryPrefab, transform);
//                scoreboardPlayerEntry.GetComponent<ScoreboardPlayerEntry>().Init(player, !firstPlaceHasBeenAssigned);
//                firstPlaceHasBeenAssigned = true;
//            }

            Player[] orderedPlayers = Session.Current.Players.OrderByDescending(player => player.Score).ToArray();
            for(int i = 0; i < orderedPlayers.Length; i++) {
                GameObject scoreboardPlayerEntry = Instantiate(_scoreboardPlayerEntryPrefab, transform);
                scoreboardPlayerEntry.GetComponent<ScoreboardPlayerEntry>().Init(orderedPlayers[i], i);
            }

        }
        
    }
    
}
