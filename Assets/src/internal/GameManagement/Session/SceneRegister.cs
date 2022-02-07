using Afired.Helper;
using UnityEngine;

namespace Afired.GameManagement.Sessions {
    
    public class SceneRegister : MonoBehaviour {

        public static SceneField MainMenu => _instance.Get()._mainMenu;
        public static SceneField AwardCeremony => _instance.Get()._awardCeremony;
        [SerializeField] private SceneField _mainMenu;
        [SerializeField] private SceneField _awardCeremony;
        private static SingletonInstance<SceneRegister> _instance;
        
        
        private void Awake() {
            _instance.Init(this);
        }
        
    }
    
}
