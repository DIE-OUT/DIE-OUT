using Afired.Helper;
using Afired.SceneManagement;
using UnityEngine;

namespace Afired.GameManagement.Sessions {
    
    public class SceneRegister : MonoBehaviour {

        public static SceneRef MainMenu => _instance.Get()._mainMenu;
        public static SceneRef AwardCeremony => _instance.Get()._awardCeremony;
        
        [SerializeField] private SceneRef _mainMenu;
        [SerializeField] private SceneRef _awardCeremony;
        
        private static SingletonInstance<SceneRegister> _instance;
        
        
        private void Awake() {
            _instance.Init(this);
        }
        
    }
    
}
