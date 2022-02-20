using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Afired.GameManagement.GameModes {
    
    [Serializable]
    public class Map {
        
        [HideLabel] [HideReferenceObjectPicker]
        [SerializeField] private SceneField _scene = new SceneField();
        [HideLabel]
        [SerializeField] private string _displayName;
        
        /// <returns>the unity scene of this map</returns>>
        public SceneField Scene => _scene;
        /// <returns>the display name of this map</returns>>
        public string DisplayName => _displayName;
        
    }
    
}
