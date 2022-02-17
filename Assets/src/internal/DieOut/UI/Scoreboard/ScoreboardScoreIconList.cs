using System;
using UnityEngine;

namespace DieOut.UI.Scoreboard {
    
    public class ScoreboardScoreIconList : MonoBehaviour {

        [SerializeField] private GameObject _scoreIconPrefab;

        public void SetScore(int score) {
            
            for(int i = 0; i < transform.childCount; i++) {
                Destroy(transform.GetChild(i).gameObject);
            }

            for(int i = 0; i < score; i++) {
                Instantiate(_scoreIconPrefab, transform);
            }
            
        }
        
    }
    
}
