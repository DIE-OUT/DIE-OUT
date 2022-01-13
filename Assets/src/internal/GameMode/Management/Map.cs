using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.GameMode.Management {
    
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
        
        public SceneField Scene => _scene;
        public string DisplayName => _displayName;

    }
    
}
