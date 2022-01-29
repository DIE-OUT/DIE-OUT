using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.GameModes.Management {
    
    [CreateAssetMenu]
    public class GameMode : ScriptableObject {
        
        [SerializeField] private string _displayName;
        [PreviewField(100, ObjectFieldAlignment.Left)]
        [SerializeField] private Sprite _splashScreen;
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
        public string Name => _displayName;
        /// <summary>
        /// returns all maps for this game mode
        /// </summary>
        /// <returns>all maps for this game mode</returns>>
        public Map[] Maps => _maps;
        /// <summary>
        /// returns all additional scenes for this game mode
        /// these scenes should be loaded along side the map
        /// </summary>
        /// <returns>all additional scenes for this game mode</returns>>
        public SceneField[] AdditionalScenes => _additionalScenes;
        
    }
    
}
