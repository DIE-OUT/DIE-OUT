using System;
using System.Threading.Tasks;
using Afired.GameManagement.Sessions;
using Sirenix.OdinInspector;

namespace Afired.GameManagement.GameModes {
    
    /// <summary>
    /// abstract base class for a player spawner of a game mode
    /// </summary>
    public abstract class PlayerSpawner : SerializedMonoBehaviour {
        
        private void Awake() {
            Session.Current.GameModeInstance.OnGameModePrepare += InvokeGameModePrepare;
        }

        private Task InvokeGameModePrepare() {
            PlayerSpawnpoint[] playerSpawnpoints = FindObjectsOfType<PlayerSpawnpoint>();
            
            if(Session.Current.PlayerCount > playerSpawnpoints.Length)
                throw new Exception("map has less player spawns than players that are playing!");
            
            OnPlayerInitialization(Session.Current.Players, playerSpawnpoints);
            return Task.CompletedTask;
        }

        protected abstract void OnPlayerInitialization(Player[] players, PlayerSpawnpoint[] playerSpawnpoints);
        
    }
    
}
