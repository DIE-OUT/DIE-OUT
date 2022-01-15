using System.Collections.Generic;
using System.ComponentModel;
using DieOut.Helper;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace DieOut.GameMode.Management {
    
    /// <summary>
    /// a register for all game mode properties
    /// contains useful methods to retrieve properties of game modes
    /// this singleton should be instantiated in the startup sequence of the game
    /// </summary>
    public class GameModeRegister : SerializedMonoBehaviour {
        
        #region Odin
        private void InitDictionary() {
            _gameModeInfos ??= new Dictionary<GameMode, GameModeProperties>();
            
            IEnumerable<GameMode> gameModes = EnumHelper.GetAllEnumValuesOfType<GameMode>();
            
            foreach(GameMode gameMode in gameModes) {
                if(!_gameModeInfos.ContainsKey(gameMode))
                    _gameModeInfos.Add(gameMode, new GameModeProperties());
            }
        }
        [DictionaryDrawerSettings(KeyLabel = "Game Mode", ValueLabel = "Properties", DisplayMode = DictionaryDisplayOptions.OneLine)]
        [ListDrawerSettings(HideAddButton = true, Expanded = true, AlwaysAddDefaultValue = true, HideRemoveButton = true)]
        [DisableContextMenu(DisableForCollectionElements = true, DisableForMember = true)]
        [OnInspectorInit("InitDictionary")]
        [HideLabel]
        [HideReferenceObjectPicker()]
        #endregion
        [OdinSerialize] private Dictionary<GameMode, GameModeProperties> _gameModeInfos = new Dictionary<GameMode, GameModeProperties>();
        private static SingletonInstance<GameModeRegister> _instance;
        
        private void Awake() {
            _instance.Init(this);
        }
        
        /// <summary>
        /// returns all properties of a game mode
        /// </summary>
        /// <param name="gameMode">the game mode of which properties to be returned</param>
        /// <returns>returns all properties of the specified game mode</returns>
        /// <exception cref="InvalidEnumArgumentException">thrown when the specified game mode is not registered</exception>
        public static GameModeProperties GetGameModeProperties(GameMode gameMode) {
            _instance.Get()._gameModeInfos.TryGetValue(gameMode, out GameModeProperties gameModeInfo);
            return gameModeInfo ?? throw new InvalidEnumArgumentException($"the provided game mode '{gameMode.ToString()}' has not been defined in {nameof(GameModeRegister)}");
        }
        
    }
    
}
