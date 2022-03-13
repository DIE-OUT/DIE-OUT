using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace DieOut.Editor.GameManager {
    
    public class DrawScriptableObjectTree<T> where T : ScriptableObject {
        
        [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
        [SerializeField] private T _selected;
        [LabelWidth(100)] [PropertyOrder(-2)] [HorizontalGroup("CreateNew")]
        [SerializeField] private string _nameForNew;
        private string _path;
        
        
        public DrawScriptableObjectTree(string path) {
            _path = path;
        }
        
        public void SetSelected(object item) {
            if(item is T newSelected) {
                _selected = newSelected;
            }
        }
        
        [HorizontalGroup("CreateNew")] [GUIColor(0.7f, 0.7f, 1.0f)]
        [Button] public void CreateNew() {
            if(string.IsNullOrEmpty(_nameForNew) || string.IsNullOrWhiteSpace(_nameForNew))
                return;

            T newItem = ScriptableObject.CreateInstance<T>();

            if(string.IsNullOrEmpty(_nameForNew) || string.IsNullOrWhiteSpace(_nameForNew))
                _path = "Assets/ScriptableObjects/";
            
            AssetDatabase.CreateAsset(newItem, _path + "\\" + _nameForNew + ".asset");
            AssetDatabase.SaveAssets();

            _nameForNew = "";
        }
        
        [HorizontalGroup("CreateNew")] [GUIColor(1.0f, 0.7f, 0.7f)]
        [Button] public void DeleteSelected() {
            if(_selected == null)
                return;
            string path = AssetDatabase.GetAssetPath(_selected);
            AssetDatabase.DeleteAsset(path);
            AssetDatabase.SaveAssets();
            _selected = null;
        }
        
        [PropertySpace(20)] [HideLabel] [ShowInInspector] [PropertyOrder(-1)]
        [ReadOnly] private string _spacer => _selected?.name ?? "";
        
    }
    
}
