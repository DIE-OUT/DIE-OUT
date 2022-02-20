using Sirenix.OdinInspector;
using UnityEngine;

namespace Afired.GameManagement.Characters {
    
    [CreateAssetMenu]
    public class Character : SerializedScriptableObject {
        
        /// <summary>a prefab containing a model of the character</summary>
        public GameObject Model => _model;
        /// <summary>the display name of the character</summary>
        public string DisplayName => _displayName;
        /// <summary>a color of the character in RGBA representation</summary>
        public Color Color => _color;
        
        [BoxGroup("General")]
        [HorizontalGroup("General/Horizontal", Width = 130)]
        [PreviewField(Height = 125, Alignment = ObjectFieldAlignment.Left)] [BoxGroup("General")] [VerticalGroup("General/Horizontal/Left")] [HideLabel] [AssetsOnly]
        [NeedsComponentInChildren(typeof(Animator), typeof(ItemPositionTag))]
        [SerializeField] private GameObject _model;
        [VerticalGroup("General/Horizontal/Right")] [LabelWidth(100)]
        [SerializeField] private string _displayName;
        [VerticalGroup("General/Horizontal/Right")] [LabelWidth(100)]
        [SerializeField] private Color _color;
        
    }
    
}
