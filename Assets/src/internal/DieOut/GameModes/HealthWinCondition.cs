using System.Collections.Generic;
using System.Linq;
using Afired.GameManagement.Sessions;
using UnityEngine;

namespace DieOut.GameModes {
    
    public class HealthWinCondition : MonoBehaviour {
        
        [SerializeField] private GenericPlayerSpawner _genericPlayerSpawner;
        private List<Player> _playersStillAlive;
        
        private void Awake() {
            _genericPlayerSpawner.OnPlayersSpawned += OnPlayersSpawned;
        }

        private void OnPlayersSpawned(GameObject[] playerGameObjects) {
            foreach(GameObject playerGameObject in playerGameObjects) {
                playerGameObject.GetComponent<Health>().OnDeath += OnPlayerDeath;
            }
            _playersStillAlive = Session.Current.Players.ToList();
        }

        private void OnPlayerDeath(Player player) {
            _playersStillAlive.Remove(player);
            player.AddScore(_playersStillAlive.Count);
            if(_playersStillAlive.Count <= 1) {
                Session.Current.GameModeInstance.EndGameMode();
            }
        }
        
    }
    
}
