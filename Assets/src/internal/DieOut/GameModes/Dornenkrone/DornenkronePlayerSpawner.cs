using Afired.GameManagement.GameModes;
using System.Collections.Generic;
using Afired.GameManagement.Sessions;
using UnityEngine;

namespace DieOut.GameModes.Dornenkrone {
    
    public class DornenkronePlayerSpawner : PlayerSpawner {

        [SerializeField] private GameObject _dornenkronePlayerPrefab;

        private List<GameObject> _players;

        protected override void OnPlayerInitialization(Player[] players, PlayerSpawnpoint[] playerSpawnpoints) {
            _players = new List<GameObject>();
            
            for(int i = 0; i < players.Length; i++) {
                GameObject player = Instantiate(_dornenkronePlayerPrefab, playerSpawnpoints[i].transform.position, Quaternion.identity);
                _players.Add(player);
                IDeviceReceiver[] deviceReceivers = player.GetComponentsInChildren<IDeviceReceiver>(true);
                foreach(IDeviceReceiver deviceReceiver in deviceReceivers) {
                    deviceReceiver.SetDevices(players[i].InputDevices);
                }
            }
            Debug.Log(players.Length);
        }
        
    }
    
}
