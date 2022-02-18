using Afired.GameManagement.Sessions;
using UnityEngine;

namespace DieOut.UI.Scoreboard {
    
    public class ScoreboardScoreIconList : MonoBehaviour {

        [SerializeField] private GameObject _scoreIconPrefabTrue;
        [SerializeField] private GameObject _scoreIconPrefabFalse;

        public void SetScore(int score) {
            
            for(int i = 0; i < transform.childCount; i++) {
                Destroy(transform.GetChild(i).gameObject);
            }
            
            for(int i = 0; i < Session.Current.WinningScore; i++) {
                Instantiate(i < score ? _scoreIconPrefabTrue : _scoreIconPrefabFalse, transform);
            }
            
        }
        
    }
    
}
