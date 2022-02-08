using System.Collections.Generic;
using System.Linq;
using Afired.GameManagement.Sessions;
using DieOut.GameModes.Beerenbusch;
using UnityEngine;

namespace DieOut.GameModes.Gewitterwolke {
    
    public class BeerenbuschWincondition : MonoBehaviour {
        
        [SerializeField] private BeerenbuschPlayerSpawner _beerenbuschPlayerSpawner;
        private List<Player> _playersStillAlive;
        
        private void Awake() {
            _beerenbuschPlayerSpawner.OnPlayersSpawned += OnPlayersSpawned;
        }

        private void OnPlayersSpawned(GameObject[] playerGameObjects) {
            foreach(GameObject playerGameObject in playerGameObjects) {
                playerGameObject.GetComponent<Health>().OnDeath += OnPlayerDeath;
            }
            _playersStillAlive = Session.Current.Player.ToList();
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
