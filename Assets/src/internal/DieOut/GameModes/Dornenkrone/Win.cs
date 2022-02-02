using System;
using System.Collections.Generic;
using System.Linq;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace DieOut.GameModes.Dornenkrone {
    
    public class Win : MonoBehaviour {
        
        private GameObject _deadPlayer;
        private DornenkronePlayerSpawner _dornenkronePlayerSpawner;
        private List<GameObject> players;

        private void Awake() {
            _dornenkronePlayerSpawner = GetComponent<DornenkronePlayerSpawner>();
        }

        private void Update() {
            if (CheckHealth()) {
                Debug.Log("Winner is:" + _deadPlayer);
                players.Remove(_deadPlayer);
                _deadPlayer.SetActive(false);
            }
        }

        private bool CheckHealth() {
            players = _dornenkronePlayerSpawner._players;
            
            if (players.Any(player => player.GetComponent<Health>()._health <= 0)) {
                foreach (GameObject player in players) {
                    float health = player.GetComponent<Health>()._health;
                    if (health <= 0) {
                        _deadPlayer = player;
                    }
                }
                return true;
            }
            else {
                return false;
            }
        }

        /*private void Score(GameObject _player) {
            _player.
        }*/
    }
    
}
