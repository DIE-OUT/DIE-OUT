using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.GameMode.Management {
    
    [Serializable]
    public class GameModeInfo {
        
        [SerializeField] private string _displayName;
        [SerializeField] private SceneField[] _scenesToBeLoadedWith;
        [SerializeField] private Level[] _levels;
        
        public string Name => _displayName;
        public SceneField[] ScenesToBeLoadedWith => _scenesToBeLoadedWith;
        public Level[] Levels => _levels;

    }
    
}
