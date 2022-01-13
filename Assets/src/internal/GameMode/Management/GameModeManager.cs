using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        [ListDrawerSettings(HideAddButton = true, Expanded = true, AlwaysAddDefaultValue = true, HideRemoveButton = true)]
        [DisableContextMenu(DisableForCollectionElements = true, DisableForMember = true)]
        [OnInspectorInit("InitDictionary")]
        [HideLabel]
        [HideReferenceObjectPicker()]
        [OdinSerialize] private Dictionary<GameMode, GameModeProperties> _gameModeInfos = new Dictionary<GameMode, GameModeProperties>();
        
        private void InitDictionary() {
            _gameModeInfos ??= new Dictionary<GameMode, GameModeProperties>();
            
            IEnumerable<GameMode> gameModes = GetAllEnumValuesOfType<GameMode>();

            foreach(GameMode gameMode in gameModes) {
                if(!_gameModeInfos.ContainsKey(gameMode))
                    _gameModeInfos.Add(gameMode, new GameModeProperties());
            }
        }

        private IEnumerable<T> GetAllEnumValuesOfType<T>() where T : Enum {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
        
        private void Awake() {
            if(v_instance != null) {
                Debug.LogWarning("only one GameModeManager can be active at once");
                return;
            }
            v_instance = this;
        }
        
        public static GameModeProperties GetGameModeProperties(GameMode gameMode) {
            _instance._gameModeInfos.TryGetValue(gameMode, out GameModeProperties gameModeInfo);
            return gameModeInfo ?? throw new InvalidEnumArgumentException($"the provided game mode '{gameMode.ToString()}' has not been defined in game mode manager");
        }
        
    }
    
}
