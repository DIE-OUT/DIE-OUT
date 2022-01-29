using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.GameModes.Management {
    
    [Serializable]
    public class Map {
        
        #region Odin
        [HideLabel]
        [HideReferenceObjectPicker]
        #endregion
        [SerializeField] private SceneField _scene = new SceneField();
        
        #region Odin
        [HideLabel]
        #endregion
        [SerializeField] private string _displayName;
        
        /// <summary>
        /// returns the scene for this map
        /// </summary>
        /// <returns>the Scene for this map</returns>>
        public SceneField Scene => _scene;
        /// <summary>
        /// the display name for this map 
        /// </summary>
        /// <returns>the display name for this map</returns>>
        public string DisplayName => _displayName;
        
    }
    
}
