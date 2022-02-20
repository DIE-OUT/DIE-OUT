using System;
using System.Collections.Generic;
using Afired.GameManagement.GameModes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.Editor {
    
    [Serializable]
    public struct GameModeMapCollection {
        
        private GameMode _gameMode;
        [ListDrawerSettings(DraggableItems = false, Expanded = true, HideAddButton = true, HideRemoveButton = true)]
        [LabelText("@GetTitle()")]
        [SerializeField] private List<LoadableMap> _loadableMaps;
        
        private string GetTitle() {
            return string.IsNullOrEmpty(_gameMode.DisplayName) ? "Untitled Game Mode" : _gameMode.DisplayName;
        }
        
        public GameModeMapCollection(GameMode gameMode) {
            _gameMode = gameMode;
            _loadableMaps = new List<LoadableMap>();
            foreach(Map gameModeMap in gameMode.Maps) {
                _loadableMaps.Add(new LoadableMap(gameMode, gameModeMap));
            }
        }
        
    }
    
}
