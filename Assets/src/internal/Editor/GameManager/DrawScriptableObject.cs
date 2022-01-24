using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace DieOut.Editor.GameManager {
    
    public class DrawScriptableObject<T> where T : ScriptableObject {
        
        [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
        public T Selected;
        [LabelWidth(100)]
        [PropertyOrder(-2)]
        [HorizontalGroup("CreateNew")]
        public string NameForNew;
        private string _path;
        
        [HorizontalGroup("CreateNew")]
        [GUIColor(0.7f, 0.7f, 1.0f)]
        [Button]
        public void CreateNew() {
            if(string.IsNullOrEmpty(NameForNew) || string.IsNullOrWhiteSpace(NameForNew))
                return;

            T newItem = ScriptableObject.CreateInstance<T>();

            if(string.IsNullOrEmpty(NameForNew) || string.IsNullOrWhiteSpace(NameForNew))
                _path = "Assets/ScriptableObjects/";
            
            AssetDatabase.CreateAsset(newItem, _path + "\\" + NameForNew + ".asset");
            AssetDatabase.SaveAssets();

            NameForNew = "";
        }
        
        [HorizontalGroup("CreateNew")]
        [GUIColor(1.0f, 0.7f, 0.7f)]
        [Button]
        public void DeleteSelected() {
            if(Selected == null)
                return;
            string path = AssetDatabase.GetAssetPath(Selected);
            AssetDatabase.DeleteAsset(path);
            AssetDatabase.SaveAssets();
        }
        
        [PropertySpace(20)]
        [ReadOnly]
        [HideLabel]
        [ShowInInspector]
        [PropertyOrder(-1)]
        private string _spacer => Selected?.name ?? "";

        public void SetSelected(object item) {
            if(item is T newSelected) {
                Selected = newSelected;
            }
        }

        public void SetPath(string path) {
            _path = path;
        }
        
    }
    
}
