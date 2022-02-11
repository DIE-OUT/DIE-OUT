using Afired.GameManagement.Sessions;
using TMPro;
using UnityEngine;

namespace DieOut.UI.Scoreboard {
    
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreboardDisplayRoundInfo : MonoBehaviour {

        [SerializeField] private string _prefix = "Round ";
        [SerializeField] private string _infix = " / ";
        [SerializeField] private string _postfix;
        private TMP_Text _text;
        
        
        private void Awake() {
            _text = GetComponent<TMP_Text>();
        }

        private void OnEnable() {
            _text.text = $"{_prefix}{Session.Current.CurrentRound}{_infix}{Session.Current.MaxRounds}{_postfix}";
        }
        
    }
    
}
