using Afired.Helper;
using UnityEngine;

namespace DieOut.GameModes.Management {
    
    public class GameModeRegister : MonoBehaviour {
        
        private static SingletonInstance<GameModeRegister> _instance;
        public static GameMode[] GameModes => _instance.Get()._gameModes;
        [SerializeField] private GameMode[] _gameModes;
        
        
        private void Awake() {
            _instance.Init(this);
        }
        
    }
    
}
