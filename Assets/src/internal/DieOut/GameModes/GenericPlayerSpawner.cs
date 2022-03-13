using System.Threading.Tasks;
using Afired.GameManagement.GameModes;
using Afired.GameManagement;
using Afired.GameManagement.Characters;
using Afired.GameManagement.Sessions;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace DieOut.GameModes {

    public delegate void OnPlayersSpawned(GameObject[] playerGameObjects);
    
    public class GenericPlayerSpawner : PlayerSpawner {
        
        public event OnPlayersSpawned OnPlayersSpawned;
        [SerializeField] private GameObject _playerControllerPrefab;
        private GameObject[] _playerGameObjects;
        
        protected override void OnPlayerInitialization(Player[] players, PlayerSpawnpoint[] playerSpawnpoints) {
            _playerGameObjects = new GameObject[players.Length];
            
            for(int i = 0; i < players.Length; i++) {
                GameObject playerControllerGameObject = Instantiate(_playerControllerPrefab, playerSpawnpoints[i].transform.position, Quaternion.identity);
                IDeviceReceiver[] deviceReceivers = playerControllerGameObject.GetComponentsInChildren<IDeviceReceiver>(true);
                foreach(IDeviceReceiver deviceReceiver in deviceReceivers) {
                    deviceReceiver.ReceiveDevices(players[i].InputDevices);
                }
                IPlayerReceiver[] playerReceivers = playerControllerGameObject.GetComponentsInChildren<IPlayerReceiver>(true);
                foreach(IPlayerReceiver deviceReceiver in playerReceivers) {
                    deviceReceiver.ReceivePlayer(players[i]);
                }
                
                
                GameObject playerModelGameObject = Instantiate(players[i].Character.Model, playerControllerGameObject.transform);
                Animator animator = playerModelGameObject.GetComponentInChildren<Animator>();
                ItemPositionTag itemPositionTag = playerModelGameObject.GetComponentInChildren<ItemPositionTag>();
                
                IAnimatorReceiver[] animatorReceivers = playerControllerGameObject.GetComponentsInChildren<IAnimatorReceiver>(true);
                foreach(IAnimatorReceiver animatorReceiver in animatorReceivers) {
                    animatorReceiver.ReceiveAnimator(animator);
                }
                IItemPositionTagReceiver[] itemPositionTagReceivers = playerControllerGameObject.GetComponentsInChildren<IItemPositionTagReceiver>(true);
                foreach(IItemPositionTagReceiver itemPositionTagReceiver in itemPositionTagReceivers) {
                    itemPositionTagReceiver.ReceiveItemPositionTag(itemPositionTag);
                }
                
                
                PlayerControls playerControls = playerControllerGameObject.GetComponent<PlayerControls>();
                playerControls.HasControl = false;
                
                _playerGameObjects[i] = playerControllerGameObject;
            }
            
            OnPlayersSpawned?.Invoke(_playerGameObjects);
            Session.Current.GameModeInstance.OnGameModeStart += GiveControl;
        }

        private Task GiveControl() {
            foreach(GameObject playerGameObject in _playerGameObjects) {
                playerGameObject.GetComponent<PlayerControls>().HasControl = true;
            }
            return Task.CompletedTask;
        }
    }
    
}
