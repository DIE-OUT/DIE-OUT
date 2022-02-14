using Afired.GameManagement.GameModes;
using TMPro;
using UnityEngine;

namespace DieOut.UI.QuickPlay {
    
    public class QuickMapSelectHeader : MonoBehaviour {

        [SerializeField] private TMP_Text _headerTextElement;
        
        public void Init(GameMode gameMode) {
            _headerTextElement.text = gameMode.DisplayName;
        }
        
    }
    
}
