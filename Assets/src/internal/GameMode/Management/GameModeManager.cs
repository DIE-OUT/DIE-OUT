using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace DieOut.GameMode.Management {
    
    public class GameModeManager : SerializedMonoBehaviour {
        
        private static GameModeManager v_instance;
        private static GameModeManager _instance {
            get {
                if(v_instance == null)
                    Debug.LogWarning("there is no GameModeManager instance initialized");
                return v_instance;
            }
        }

        [DictionaryDrawerSettings(KeyLabel = "Game Mode", ValueLabel = "Info", DisplayMode = DictionaryDisplayOptions.OneLine)]
        [ListDrawerSettings(HideAddButton = true, Expanded = true, AlwaysAddDefaultValue = true)]
        [DisableContextMenu()]
        [OdinSerialize] private Dictionary<GameMode, GameModeInfo> _gameModeInfos = new Dictionary<GameMode, GameModeInfo>();
        
        
        private void Awake() {
            if(v_instance != null) {
                Debug.LogWarning("only one GameModeManager can be active at once");
                return;
            }
            v_instance = this;
        }
        
        public static GameModeInfo GetGameModeInfo(GameMode gameMode) {
            _instance._gameModeInfos.TryGetValue(gameMode, out GameModeInfo gameModeInfo);
            return gameModeInfo ?? throw new InvalidEnumArgumentException($"the provided game mode '{gameMode.ToString()}' has not been defined in game mode manager");
        }
        
    }
    
}
