using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.GameMode.Management {
    
    [Serializable]
    public class GameModeProperties {
        
        [SerializeField] private string _displayName;
        
        [PreviewField]
        [SerializeField] private Texture2D _splashScreen;

        [TableList(AlwaysExpanded = true, DrawScrollView = false)]
        [HideReferenceObjectPicker()]
        [SerializeField] private Map[] _maps = { new Map() };
        
        [HideReferenceObjectPicker()]
        [ListDrawerSettings(Expanded = true)]
        [SerializeField] private SceneField[] _additionalScenes = { new SceneField() };
        
        public string Name => _displayName;
        public Map[] Maps => _maps;
        public SceneField[] AdditionalScenes => _additionalScenes;

    }
    
}
