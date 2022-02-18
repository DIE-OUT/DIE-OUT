using Afired.GameManagement.Sessions;
using Afired.UI;
using UnityEngine;
using Screen = Afired.UI.Screen;

namespace DieOut.UI.LoadingScreen {
    
    public class LoadingScreenSwitch : ScreenManager {
        
        [SerializeField] private Screen _normalLoadingScreen;
        [SerializeField] private Screen _gameModeLoadingScreen;

        private void Awake() {
            bool shouldDisplayNormalLoadingScreen = !Session.HasCurrent || !Session.Current.IsRunning;
            
            Activate(shouldDisplayNormalLoadingScreen ? _normalLoadingScreen : _gameModeLoadingScreen);
        }
        
    }
    
}
