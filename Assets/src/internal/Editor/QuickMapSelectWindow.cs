using System;
using System.Collections.Generic;
using DieOut.GameModes.Management;
using Afired.SessionManagement;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.Editor {
    
    [InfoBox("This will show a selection of all maps once in play mode", VisibleIf = "@!EditorApplication.isPlaying")]
    [InfoBox("Startup Scene hasn't been initialized - Start Play Mode with Auto Scene Loader enabled", VisibleIf = "@EditorApplication.isPlaying && !StartUp.HasBeenLoaded")]
    public class QuickMapSelectWindow : OdinEditorWindow {
        
        [MenuItem("DieOut/Quick Map Select")]
        public static void OpenWindow() {
            GetWindow<QuickMapSelectWindow>("Quick Map Select").Show();
        }
        
        [ListDrawerSettings(DraggableItems = false, Expanded = true, HideAddButton = true, HideRemoveButton = true, ShowItemCount = false)]
        [LabelText("Select a Map to load..")]
        [HideIf("@!EditorApplication.isPlaying || !StartUp.HasBeenLoaded")]
        [SerializeField] private List<GameModeMapCollection> _gamModeMapCollections;

        protected override void Initialize() {
            base.Initialize();
            _gamModeMapCollections = new List<GameModeMapCollection>();
            foreach(GameMode gameMode in LoadAssetsFromAssetBrowser<GameMode>()) {
                _gamModeMapCollections.Add(new GameModeMapCollection(gameMode));
            }
        }
        
        /// <summary>
        /// Returns one asset of type T from asset browser.
        /// Expects to find exactly one asset!
        /// </summary>
        public static IEnumerable<T> LoadAssetsFromAssetBrowser<T>() where T : ScriptableObject {
            // get all GUIDs of type T
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T)); // use typeof(T) instead of nameof(T) to prevent duplicate naming

            foreach(string guid in guids) {
                // get path from first GUID in guids
                string path = AssetDatabase.GUIDToAssetPath(guid);
                // load asset at path
                T asset = AssetDatabase.LoadAssetAtPath<T>(path);
                yield return asset;
            }
        }
    }

    [Serializable]
    public struct GameModeMapCollection {
        
        private GameMode _gameMode;
        [ListDrawerSettings(DraggableItems = false, Expanded = true, HideAddButton = true, HideRemoveButton = true)]
        [LabelText("@GetTitle()")]
        [SerializeField] private List<LoadableMap> _loadableMaps;

        private string GetTitle() {
            return string.IsNullOrEmpty(_gameMode.Name) ? "Untitled Game Mode" : _gameMode.Name;
        }
        
        public GameModeMapCollection(GameMode gameMode) {
            _gameMode = gameMode;
            _loadableMaps = new List<LoadableMap>();
            foreach(Map gameModeMap in gameMode.Maps) {
                _loadableMaps.Add(new LoadableMap(gameMode, gameModeMap));
            }
        }
        
    }

    [Serializable]
    public struct LoadableMap {

        private GameMode _gameMode;
        private Map _map;
        
        public LoadableMap(GameMode gameMode, Map map) {
            _map = map;
            _gameMode = gameMode;
        }
        
        private string GetTitle() {
            return string.IsNullOrEmpty(_map.DisplayName) ? "Untitled Map" : _map.DisplayName;
        }
        
        [Button("@GetTitle()")]
        public void Load() {
            Session.SetNew(new Session(CreatePlayers(), new HashSet<GameMode>(), 1, 1));
            Session.Current.LoadGameMode(_gameMode , _map);
        }
        
        private Player[] CreatePlayers() {
            
            List<Player> players = new List<Player>();
            
            if(Keyboard.current != null && Mouse.current != null)
                players.Add(new Player(new InputDevice[] { Keyboard.current, Mouse.current }));
            
            for(int i = 0; i < Gamepad.all.Count; i++) {
                players.Add(new Player(new InputDevice[] { Gamepad.all[0] }));
            }
            
            return players.ToArray();
        }
        
    }
    
}
