using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.GameMode.Management {
    
    [Serializable]
    [InlineProperty]
    public class Map {
        
        [HideLabel]
        [HideReferenceObjectPicker]
        [SerializeField] private SceneField _scene = new SceneField();
        
        [HideLabel]
        [SerializeField] private string _displayName;
        
        public SceneField Scene => _scene;
        public string DisplayName => _displayName;

    }
    
}
