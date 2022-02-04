using Afired.GameManagement.Sessions;
using TMPro;
using UnityEngine;

namespace DieOut.UI.Scoreboard {
    
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreboardDisplayWinningScore : MonoBehaviour {

        [SerializeField] private string _prefix = "Winning Score: ";
        [SerializeField] private string _postfix;
        private TMP_Text _text;
        
        
        private void Awake() {
            _text = GetComponent<TMP_Text>();
        }

        private void OnEnable() {
            _text.text = $"{_prefix}{Session.Current.WinningScore}{_postfix}";
        }
        
    }
    
}
