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
        
        #region Odin
        [TableList(AlwaysExpanded = true, DrawScrollView = false)]
        [HideReferenceObjectPicker()]
        #endregion
        [SerializeField] private Map[] _maps = { new Map() };
        #region Odin
        [HideReferenceObjectPicker()]
        [ListDrawerSettings(Expanded = true)]
        #endregion
        [SerializeField] private SceneField[] _additionalScenes = { new SceneField() };
        
        /// <summary>
        /// returns the display name for this game mode
        /// </summary>
        /// <returns>the display name for this game mode</returns>>
        public string DisplayName => _displayName;

        public string DescriptionText => _descriptionText;
        public Sprite DescriptionSprite => _descriptionSprite;
        /// <summary>
        /// returns all maps for this game mode
        /// </summary>
        /// <returns>all maps for this game mode</returns>>
        public Map[] Maps => _maps;

        public Sprite SplashScreen => _splashScreen;
        /// <summary>
        /// returns all additional scenes for this game mode
        /// these scenes should be loaded along side the map
        /// </summary>
        /// <returns>all additional scenes for this game mode</returns>>
        public SceneField[] AdditionalScenes => _additionalScenes;
        
    }
    
}
