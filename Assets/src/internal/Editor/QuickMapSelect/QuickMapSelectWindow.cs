using System.Collections.Generic;
using Afired.GameManagement.GameModes;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

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
    
}
