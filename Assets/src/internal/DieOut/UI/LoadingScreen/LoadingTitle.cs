using Afired.GameManagement.Sessions;
using UnityEngine;
using TMPro;

namespace DieOut.UI.LoadingScreen {
    
    [RequireComponent(typeof(TMP_Text))]
    public class LoadingTitle : MonoBehaviour {
        
        private void Awake() {
            TMP_Text text = GetComponent<TMP_Text>();
            if(!Session.HasCurrent)
                return;
            string description = Session.Current?.GameModeInstance?.GameMode.DisplayName;
            if(description is null)
                return;
            text.text = description;
        }
        
    }
    
}
