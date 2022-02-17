﻿using Afired.GameManagement.Sessions;
using UnityEngine;

namespace DieOut.UI.Scoreboard {
    
    public class ScoreboardPlayerEntryManager : MonoBehaviour {

        [SerializeField] private GameObject _scoreboardPlayerEntryPrefab;
        
        
        private void Awake() {
            Refresh();
        }

        public void Refresh() {
            for(int i = 0; i < transform.childCount; i++) {
                Destroy(transform.GetChild(i).gameObject);
            }
            
            for(int i = 0; i < Session.Current.PlayerCount; i++) {
                GameObject scoreboardPlayerEntry = Instantiate(_scoreboardPlayerEntryPrefab, transform);
                scoreboardPlayerEntry.GetComponent<ScoreboardPlayerEntry>().Init(Session.Current.Player[i]);
            }
        }
        
    }
    
}
