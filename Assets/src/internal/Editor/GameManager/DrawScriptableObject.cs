using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace DieOut.Editor.GameManager {
    
    public class DrawScriptableObject<T> where T : ScriptableObject {
        
        [ShowIf("@_myObject != null")]
        [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
        public T _myObject;
        private string _path;
        
        [ShowIf("@_myObject == null")]
        [ReadOnly]
        [HideLabel]
        [ShowInInspector]
        [PropertyOrder(-1)]
        [InfoBox("Notify Conor plss")]
        private string _ = string.Empty;
        
        
        public DrawScriptableObject(string path) {
            _path = path;
        }

        public void FindTarget() {
            _myObject = LoadAssetFromAssetBrowser<T>();
        }
        
        /// <summary>
        /// Returns one asset of type T from asset browser.
        /// Expects to find exactly one asset!
        /// </summary>
        public static T LoadAssetFromAssetBrowser<T>() where T : ScriptableObject {
            // get all GUIDs of type T
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T)); // use typeof(T) instead of nameof(T) to prevent duplicate naming

            // handle exceptions
            if(guids.Length == 0) {
                Debug.LogWarning($"No {typeof(T).Name} Asset found!");
                return null;
            }
            if(guids.Length > 1)
                Debug.LogWarning($"Multiple {typeof(T).Name} assets found, but expected to find only one! Returned first found asset! This can lead to unexpected behaviour! Make sure there is only one asset of type {typeof(T).Name} in the asset browser!");

            // get path from first GUID in guids
            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            // load asset at path
            T asset = AssetDatabase.LoadAssetAtPath<T>(path);
            return asset;
        }
        
    }
    
}
