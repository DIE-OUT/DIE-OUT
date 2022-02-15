using Sirenix.OdinInspector;
using UnityEngine;

namespace Afired.GameManagement.Sessions {
    
    [CreateAssetMenu]
    public class Character : ScriptableObject {
        
        [BoxGroup("General")]
        [HorizontalGroup("General/Horizontal", Width = 130)]
        [PreviewField(Height = 125, Alignment = ObjectFieldAlignment.Left)] [BoxGroup("General")] [VerticalGroup("General/Horizontal/Left")] [HideLabel] [AssetsOnly]
        [SerializeField] private GameObject _model;
        [VerticalGroup("General/Horizontal/Right")] [LabelWidth(100)]
        [SerializeField] private string _displayName;
        [VerticalGroup("General/Horizontal/Right")] [LabelWidth(100)]
        [SerializeField] private Color _color;
        [VerticalGroup("General/Horizontal/Right")] [LabelWidth(100)]
        [SerializeField] private Avatar _avatar;
        
        public GameObject Model => _model;
        public string DisplayName => _displayName;
        public Color Color => _color;
        public Avatar Avatar => _avatar;
        
    }
    
}
