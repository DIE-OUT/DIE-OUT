using System.Collections.Generic;
using Afired.GameManagement.GameModes;
using Afired.GameManagement;
using Afired.GameManagement.Sessions;
using DieOut.GameModes.Interactions;
using DieOut.UI.CharacterSelect;
using Sirenix.Serialization;
using UnityEngine;

namespace DieOut.GameModes.Gewitterwolke {

    public delegate void OnPlayersSpawned(GameObject[] playerGameObjects);
    
    public class GewitterwolkePlayerSpawner : PlayerSpawner {
        
        public event OnPlayersSpawned OnPlayersSpawned;
        [OdinSerialize] private Dictionary<PlayerColor, GameObject> _gewitterwolkePlayerPrefabs = new Dictionary<PlayerColor, GameObject>();
        private GameObject[] _playerGameObjects;
        
        protected override void OnPlayerInitialization(Player[] players, PlayerSpawnpoint[] playerSpawnpoints) {
            _playerGameObjects = new GameObject[players.Length];
            
            for(int i = 0; i < players.Length; i++) {
                GameObject playerGameObject = Instantiate(_gewitterwolkePlayerPrefabs[players[i].PlayerColor], playerSpawnpoints[i].transform.position, Quaternion.identity);
                
                IDeviceReceiver[] deviceReceivers = playerGameObject.GetComponentsInChildren<IDeviceReceiver>(true);
                foreach(IDeviceReceiver deviceReceiver in deviceReceivers) {
                    deviceReceiver.SetDevices(players[i].InputDevices);
                }
                
                IPlayerReceiver[] playerReceivers = playerGameObject.GetComponentsInChildren<IPlayerReceiver>(true);
                foreach(IPlayerReceiver deviceReceiver in playerReceivers) {
                    deviceReceiver.SetPlayer(players[i]);
                }

                PlayerControls playerControls = playerGameObject.GetComponent<PlayerControls>();
                playerControls.HasControl = false;
                
                _playerGameObjects[i] = playerGameObject;
            }
            
            OnPlayersSpawned?.Invoke(_playerGameObjects);
            Session.Current.GameModeInstance.OnGameModeStart += GiveControl;
        }

        private void GiveControl() {
            foreach(GameObject playerGameObject in _playerGameObjects) {
                playerGameObject.GetComponent<PlayerControls>().HasControl = true;
            }
        }
    }
    
}
