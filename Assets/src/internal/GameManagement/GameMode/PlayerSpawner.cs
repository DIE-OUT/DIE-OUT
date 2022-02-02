﻿using System;
using Afired.GameManagement.Sessions;
using UnityEngine;

namespace Afired.GameManagement.GameModes {
    
    public abstract class PlayerSpawner : MonoBehaviour {
        
        private void Awake() {
            Session.Current.GameModeInstance.OnGameModePrepare += InvokeGameModePrepare;
        }

        private void InvokeGameModePrepare() {
            PlayerSpawnpoint[] playerSpawnpoints = FindObjectsOfType<PlayerSpawnpoint>();
            Player[] players = Session.Current.Player;
            
            if(players.Length > playerSpawnpoints.Length)
                throw new Exception("map has less player spawns than players that are playing!");
            
            OnPlayerInitialization(players, playerSpawnpoints);
        }

        protected abstract void OnPlayerInitialization(Player[] players, PlayerSpawnpoint[] playerSpawnpoints);
        
    }
    
}