using Afired.GameManagement.Characters;
using Afired.Helper;
using UnityEngine;

namespace Afired.GameManagement.Sessions {
    
    /// <summary>
    /// singleton register for all characters
    /// </summary>
    public class CharacterRegister : MonoBehaviour {
        
        public static Character[] Characters => _instance.Get()._characters;
        
        [SerializeField] private Character[] _characters;
        
        private static SingletonInstance<CharacterRegister> _instance;
        
        
        private void Awake() {
            _instance.Init(this);
        }
        
    }
    
}
