using System;
using Afired.SceneManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Afired.GameManagement.GameModes {
    
    [Serializable]
    public class Map {
        
        [HideLabel] [HideReferenceObjectPicker]
        [SerializeField] private SceneRef _scene = new SceneRef();
        [HideLabel]
        [SerializeField] private string _displayName;
        
        /// <returns>the unity scene of this map</returns>>
        public SceneRef Scene => _scene;
        /// <returns>the display name of this map</returns>>
        public string DisplayName => _displayName;
        
    }
    
}
