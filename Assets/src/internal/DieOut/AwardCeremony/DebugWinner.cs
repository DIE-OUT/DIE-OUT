using System.Linq;
using Afired.GameManagement.Sessions;
using UnityEngine;

namespace DieOut.AwardCeremony {
    
    public class DebugWinner : MonoBehaviour {
        
        private Player[] Player => Session.Current.Player;
        
        
        private void Awake() {
            Debug.Log($"Session ended, a player won {Player.OrderByDescending(player => player.Score).FirstOrDefault()?.InputDevices.FirstOrDefault()?.displayName} with a score of {Player.OrderByDescending(player => player.Score).FirstOrDefault()?.Score}");
        }
        
    }
    
}
