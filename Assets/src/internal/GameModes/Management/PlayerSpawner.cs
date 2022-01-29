using System;
using DieOut.Sessions;
using UnityEngine;

namespace DieOut.GameModes.Management {
    
    public abstract class PlayerSpawner : MonoBehaviour {
        
        private void Awake() {
            Sessions.Sessions.Current.OnGameModePrepare += InvokeGameModePrepare;
        }

        private void InvokeGameModePrepare() {
            PlayerSpawnpoint[] playerSpawnpoints = FindObjectsOfType<PlayerSpawnpoint>();
            Player[] players = Sessions.Sessions.Current.Player;
            
            if(players.Length > playerSpawnpoints.Length)
                throw new Exception("map has less player spawns than players that are playing!");
            
            OnPlayerInitialization(players, playerSpawnpoints);
        }

        protected abstract void OnPlayerInitialization(Player[] players, PlayerSpawnpoint[] playerSpawnpoints);
        
    }
    
}
