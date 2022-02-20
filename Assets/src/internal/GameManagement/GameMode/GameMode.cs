using Sirenix.OdinInspector;
using UnityEngine;

namespace Afired.GameManagement.GameModes {
    
    [CreateAssetMenu]
    public class GameMode : ScriptableObject {
        
        [HorizontalGroup("General/Horizontal", Width = 130)]
        [PreviewField(Height = 125, Alignment = ObjectFieldAlignment.Left)] [BoxGroup("General")] [VerticalGroup("General/Horizontal/Left")] [HideLabel]
        [SerializeField] private Sprite _splashScreen;
        [BoxGroup("General")] [VerticalGroup("General/Horizontal/Right")] [LabelWidth(110)]
        [SerializeField] private string _displayName;
        [TextArea(5, 5)] [BoxGroup("General")] [VerticalGroup("General/Horizontal/Right")]
        [SerializeField] private string _descriptionText;
        [BoxGroup("General")] [VerticalGroup("General/Horizontal/Right")] [LabelWidth(110)]
        [SerializeField] private Sprite _descriptionSprite;
        [TableList(AlwaysExpanded = true, DrawScrollView = false)] [HideReferenceObjectPicker]
        [SerializeField] private Map[] _maps = { new Map() };
        [HideReferenceObjectPicker] [ListDrawerSettings(Expanded = true)]
        [SerializeField] private SceneField[] _additionalScenes = { new SceneField() };
        
        /// <returns>the display name of this game mode</returns>
        public string DisplayName => _displayName;
        
        /// <returns>a description of this game mode in text form</returns>
        public string DescriptionText => _descriptionText;
        
        /// <returns>a description of this game mode in text form</returns>
        public Sprite DescriptionSprite => _descriptionSprite;
        
        /// <returns>all maps registered for this game mode</returns>>
        public Map[] Maps => _maps;
        
        /// <returns>a splash screen sprite for this game mode</returns>
        public Sprite SplashScreen => _splashScreen;
        
        /// <returns>all additional scenes that should be loaded along side a map of this game mode</returns>>
        public SceneField[] AdditionalScenes => _additionalScenes;
        
    }
    
}
