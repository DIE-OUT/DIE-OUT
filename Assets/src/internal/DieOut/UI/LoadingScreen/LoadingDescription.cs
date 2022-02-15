using Afired.GameManagement.Sessions;
using UnityEngine;
using TMPro;

namespace DieOut.UI.LoadingScreen {
    
    [RequireComponent(typeof(TMP_Text))]
    public class LoadingDescription : MonoBehaviour {
        
        private void Awake() {
            if(!Session.HasCurrent || !Session.Current.IsRunning)
                return;
            
            TMP_Text text = GetComponent<TMP_Text>();
            text.text = Session.Current?.GameModeInstance?.GameMode.Description;
        }
        
    }
    
}
