using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.GameMode.Management {
    
    [Serializable]
    public class Level {
        
        [SerializeField] private SceneField _scene;
        [SerializeField] private string _levelName;
        
        public SceneField Scene => _scene;
        public string LevelName => _levelName;

    }
    
}
