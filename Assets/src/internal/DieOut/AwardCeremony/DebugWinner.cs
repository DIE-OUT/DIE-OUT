using System.Linq;
using Afired.GameManagement.Sessions;
using TMPro;
using UnityEngine;

namespace DieOut.AwardCeremony {
    
    [RequireComponent(typeof(TMP_Text))]
    public class DebugWinner : MonoBehaviour {

        [SerializeField] private string _prefix;
        [SerializeField] private string _suffix;
        private Player[] Player => Session.Current.Player;
        
        
        private void Awake() {
            TMP_Text text = GetComponent<TMP_Text>();
            text.text = $"{_prefix}{Player.OrderByDescending(player => player.Score).FirstOrDefault()?.DisplayName}{_suffix}";
        }
        
    }
    
}
