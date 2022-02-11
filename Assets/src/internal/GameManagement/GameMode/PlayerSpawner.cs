using System;
using System.Threading.Tasks;
using Afired.GameManagement.Sessions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Afired.GameManagement.GameModes {
    
    public abstract class PlayerSpawner : SerializedMonoBehaviour {
        
        private void Awake() {
            Session.Current.GameModeInstance.OnGameModePrepare += InvokeGameModePrepare;
        }

        private Task InvokeGameModePrepare() {
            PlayerSpawnpoint[] playerSpawnpoints = FindObjectsOfType<PlayerSpawnpoint>();
            Player[] players = Session.Current.Player;
            
            if(players.Length > playerSpawnpoints.Length)
                throw new Exception("map has less player spawns than players that are playing!");
            
            OnPlayerInitialization(players, playerSpawnpoints);
            return Task.CompletedTask;
        }

        protected abstract void OnPlayerInitialization(Player[] players, PlayerSpawnpoint[] playerSpawnpoints);
        
    }
    
}
