using System;
using DieOut.GameMode.Management;
using DieOut.Sessions;
using UnityEngine;

namespace DieOut.GameMode.Dornenkrone {
    
    public class DornenkronePlayerSpawner : PlayerSpawner {

        [SerializeField] private GameObject _dornenkronePlayerPrefab;
        
        
        protected override void OnGameModePrepare(Player[] players, PlayerSpawnpoint[] playerSpawnpoints) {
            for(int i = 0; i < players.Length; i++) {
                GameObject player = Instantiate(_dornenkronePlayerPrefab, playerSpawnpoints[i].transform.position, Quaternion.identity);
                //todo: more initialization
            }
        }
        
    }
    
}
