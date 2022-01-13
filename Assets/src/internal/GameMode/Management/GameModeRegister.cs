using System.Collections.Generic;
using System.ComponentModel;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace DieOut.GameMode.Management {
    
    public class GameModeRegister : SerializedMonoBehaviour {
        
        private static GameModeRegister v_instance;
        private static GameModeRegister _instance {
            get {
                if(v_instance == null)
                    Debug.LogWarning($"there is no {nameof(GameModeRegister)} instance initialized");
                return v_instance;
            }
        }

        #region Serialization
        [DictionaryDrawerSettings(KeyLabel = "Game Mode", ValueLabel = "Properties", DisplayMode = DictionaryDisplayOptions.OneLine)]
        [ListDrawerSettings(HideAddButton = true, Expanded = true, AlwaysAddDefaultValue = true, HideRemoveButton = true)]
        [DisableContextMenu(DisableForCollectionElements = true, DisableForMember = true)]
        [OnInspectorInit("InitDictionary")]
        [HideLabel]
        [HideReferenceObjectPicker()]
        private void InitDictionary() {
            _gameModeInfos ??= new Dictionary<GameMode, GameModeProperties>();
            
            IEnumerable<GameMode> gameModes = EnumHelper.GetAllEnumValuesOfType<GameMode>();
            
            foreach(GameMode gameMode in gameModes) {
                if(!_gameModeInfos.ContainsKey(gameMode))
                    _gameModeInfos.Add(gameMode, new GameModeProperties());
            }
        }
        #endregion
        [OdinSerialize] private Dictionary<GameMode, GameModeProperties> _gameModeInfos = new Dictionary<GameMode, GameModeProperties>();
        
        private void Awake() {
            if(v_instance != null) {
                Debug.LogWarning($"only one {nameof(GameModeRegister)} can be active at once");
                return;
            }
            v_instance = this;
        }
        
        public static GameModeProperties GetGameModeProperties(GameMode gameMode) {
            _instance._gameModeInfos.TryGetValue(gameMode, out GameModeProperties gameModeInfo);
            return gameModeInfo ?? throw new InvalidEnumArgumentException($"the provided game mode '{gameMode.ToString()}' has not been defined in {nameof(GameModeRegister)}");
        }
        
    }
    
}
