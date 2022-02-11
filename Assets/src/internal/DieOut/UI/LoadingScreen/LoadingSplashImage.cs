using Afired.GameManagement.Sessions;
using UnityEngine;
using UnityEngine.UI;

namespace DieOut.UI.LoadingScreen {
    
    [RequireComponent(typeof(Image))]
    public class LoadingSplashImage : MonoBehaviour {
        
        private void Awake() {
            Image image = GetComponent<Image>();
            if(!Session.HasCurrent)
                return;
            Sprite splashScreen = Session.Current?.GameModeInstance?.GameMode.SplashScreen;
            if(splashScreen is null)
                return;
            image.sprite = splashScreen;
        }
        
    }
    
}
