using Afired.Helper;
using UnityEngine;

namespace Afired.GameManagement.Sessions {
    
    public class CharacterRegister : MonoBehaviour {
        
        private static SingletonInstance<CharacterRegister> _instance;
        public static Character[] Characters => _instance.Get()._characters;
        [SerializeField] private Character[] _characters;
        
        
        private void Awake() {
            _instance.Init(this);
        }
        
    }
    
}
