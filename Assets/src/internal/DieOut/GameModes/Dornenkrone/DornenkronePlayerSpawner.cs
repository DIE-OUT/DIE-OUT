using Afired.GameManagement.GameModes;
using Afired.GameManagement;
using Afired.GameManagement.Sessions;
using UnityEngine;

namespace DieOut.GameModes.Dornenkrone {

    public delegate void OnPlayersSpawned(GameObject[] playerGameObjects);
    
    public class DornenkronePlayerSpawner : PlayerSpawner {
        
        public event OnPlayersSpawned OnPlayersSpawned;
        //todo: use a model register to retrieve the models instead of having multiple player prefab varients
        [SerializeField] private GameObject[] _dornenkronePlayerPrefabs;
        
        protected override void OnPlayerInitialization(Player[] players, PlayerSpawnpoint[] playerSpawnpoints) {
            GameObject[] playerGameObjects = new GameObject[players.Length];
            
            for(int i = 0; i < players.Length; i++) {
                GameObject playerGameObject = Instantiate(_dornenkronePlayerPrefabs[i], playerSpawnpoints[i].transform.position, Quaternion.identity);
                
                IDeviceReceiver[] deviceReceivers = playerGameObject.GetComponentsInChildren<IDeviceReceiver>(true);
                foreach(IDeviceReceiver deviceReceiver in deviceReceivers) {
                    deviceReceiver.SetDevices(players[i].InputDevices);
                }
                
                IPlayerReceiver[] playerReceivers = playerGameObject.GetComponentsInChildren<IPlayerReceiver>(true);
                foreach(IPlayerReceiver deviceReceiver in playerReceivers) {
                    deviceReceiver.SetPlayer(players[i]);
                }

                playerGameObjects[i] = playerGameObject;
            }
            
            OnPlayersSpawned?.Invoke(playerGameObjects);
        }
        
    }
    
}
