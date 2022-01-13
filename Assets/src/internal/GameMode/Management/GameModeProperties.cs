using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.GameMode.Management {
    
    [Serializable]
    public class GameModeProperties {
        
        [SerializeField] private string _displayName;
        [SerializeField] private Texture2D _splashScreen;
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
        
        public string Name => _displayName;
        public Map[] Maps => _maps;
        public SceneField[] AdditionalScenes => _additionalScenes;

    }
    
}
