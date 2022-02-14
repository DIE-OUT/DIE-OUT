using Sirenix.OdinInspector;
using UnityEngine;

namespace Afired.GameManagement.Sessions {
    
    [CreateAssetMenu]
    public class Character : ScriptableObject {
        
        [SerializeField] private string _displayName;
        [PreviewField] [SerializeField] private GameObject _model;
        [SerializeField] private Avatar _avatar;
        
        public string DisplayName => _displayName;
        public GameObject Model => _model;
        public Avatar Avatar => _avatar;
        
    }
    
}
